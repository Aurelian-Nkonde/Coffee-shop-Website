using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MvcCoffee.Models;

namespace MvcOrder.Models
{
    public class Order
    {
        [Key]
        public int Id {get;set;}
        [Required]
        [StringLength(200)]
        [Display(Name = "Customer Name")]
        public string Name {get;set;}
        // [Required]
        [Display(Name = "Phone Number")]
        // [Phone]
        public int Phone {get;set;}
        [Required]
        [EmailAddress]
        [Display(Name = "Your Email")]
        public string Email {get;set;}
        [Required]
        [Display(Name = "Total number of people")]
        public int TotalPeople {get;set;}
        [Required]
        [Display(Name = "Name of Coffee")]
        public string CoffeeNames {get;set;}
        [Required]
        [Display(Name = "Total cups")]
        public int TotalCoffees {get;set;}
        [Required]
        [Display(Name = "Date of Booking")]
        public DateTime DateBooking {get;set;}
        [Required]
        [Display(Name = "Time of Booking")]
        public DateTime TimeBooking {get;set;}
        public IEnumerable<Coffee> Coffees {get;set;}
    } 
}