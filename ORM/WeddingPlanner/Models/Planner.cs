using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace WeddingPlanner.Models
{
    public class Planner : BaseEntity
    {
        [Key]
        // These must match the columns in your database's table!
        public int WeddingId {get; set;}
        public int UserId {get;set;}
        public DateTime WeddingDate {get;set;}
        public string WedderOne {get;set;}
        public string WedderTwo {get;set;}
        public string Address {get;set;}
        public User user {get;set;} 
        public List<Guest> Guests {get;set;}
        public Planner()
        {
            Guests = new List<Guest>();
        }
    }
}