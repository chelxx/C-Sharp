using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BankAccounts.Models;
using System.Linq;

namespace BankAccounts.Controllers
{
    public class HomeController : Controller
    {
        private BankContext _context;
 
        public HomeController(BankContext context)
        {
            _context = context;
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpPost]
        [Route("register")]
        public IActionResult RegisterUser(RegUser newRegUser)
        {
            if (ModelState.IsValid)
            {
                // ADD IF STATEMENTS FOR AN EXISTING EMAIL
                User current = _context.Users.SingleOrDefault(RegUser => RegUser.Email == newRegUser.Email);
                if(current != null)
                {
                    // CHANGED ACCORDING TO LECTURE
                    // INSTEAD OF USING VIEWBAG
                    ModelState.AddModelError("Email", "Email already exists!");
                    return View("Index");
                }
                else
                {
                    PasswordHasher<RegUser> Hasher = new PasswordHasher<RegUser>();
                    string hashed = Hasher.HashPassword(newRegUser, newRegUser.Password);
                    User user = new User
                    {
                        FirstName = newRegUser.FirstName,
                        LastName = newRegUser.LastName,
                        Email = newRegUser.Email,  
                        Password = hashed,
                        Balance = 0.00
                        // MAYBE MAKE THE BALANCE INTO TYPE DOUBLE/FLOAT?
                    };
                    _context.Add(user);
                    _context.SaveChanges();
                    User sessionuser = _context.Users.Where(u => u.Email == newRegUser.Email).SingleOrDefault();
                    HttpContext.Session.SetInt32("userID", sessionuser.UserId);
                    HttpContext.Session.SetString("firstname", sessionuser.FirstName);
                    return RedirectToAction("BankOverview");
                }
            }
            else
            {
                return View("Index");
            }
        }

        [HttpGet]
        [Route("login")]
        public IActionResult LoginView()
        {
            return View("Login");
        }

        [HttpPost]
        [Route("login")]
        public IActionResult LoginUser(LoginUser loginUser)
        {
            if(ModelState.IsValid)
            {
                User current = _context.Users.Where(u => u.Email == loginUser.Email).SingleOrDefault();
                if(current == null)
                {
                    // CHANGED ACCORDING TO LECTURE
                    // INSTEAD OF USING VIEWBAG
                    ModelState.AddModelError("Email", "Email does not exist!");
                    return View("Login");
                }
                else
                {
                    var hasher = new PasswordHasher<User>();
                    if(hasher.VerifyHashedPassword(current, current.Password, loginUser.Password) == 0)
                    {
                        ModelState.AddModelError("Password", "Incorrect password!");
                        return View("Login");
                    }
                    else
                    {
                        HttpContext.Session.SetInt32("userID", current.UserId);
                        HttpContext.Session.SetString("firstname", current.FirstName);
                        return RedirectToAction("BankOverview");
                    }
                }
            }
            else
            {
                return View("Login");
            }
        }

        [HttpGet]
        [Route("overview")]
        public IActionResult BankOverview()
        {
            var id = HttpContext.Session.GetInt32("userID");
            List<User> userinfo = _context.Users.Where(u => u.UserId == id).ToList();
            ViewBag.UserInfo = userinfo;
            ViewBag.Name = HttpContext.Session.GetString("firstname");
            List<Transaction> transactioninfo = _context.Transactions.Where(t => t.UserId == id).OrderByDescending(t => t.TransactionDate).ToList();
            ViewBag.TransactionInfo = transactioninfo;
            return View("Overview");
        }

        [HttpPost]
        [Route("transaction")]
        public IActionResult TransactionProcess(double amount)
        {
            int? id = HttpContext.Session.GetInt32("userID");
            Transaction transaction = new Transaction
            {
                UserId = (int)id,
                TransactionAmount = amount,
                TransactionDate = DateTime.Now
            };
            User user = _context.Users.Where(u => u.UserId == transaction.UserId).SingleOrDefault();
            user.Balance += (double)transaction.TransactionAmount;
            _context.Add(transaction);
            _context.SaveChanges();
            return RedirectToAction("BankOverview");
        }

        [HttpPost]
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
