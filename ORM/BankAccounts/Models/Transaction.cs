using System;
using System.ComponentModel.DataAnnotations;

namespace BankAccounts.Models
{
    public class Transaction : BaseEntity
    {
        // These must match the columns in your database's table!
        public int TransactionId { get; set; }
        public int UserId { get;set; }
        public double TransactionAmount { get;set; }
        public DateTime TransactionDate { get;set; }
        public User user { get;set; } 
    }
}