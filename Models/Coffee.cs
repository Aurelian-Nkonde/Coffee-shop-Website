using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MvcOrder.Models;

namespace MvcCoffee.Models
{
    public class Coffee
    {
        [Key]
        public int Id {get;set;}
        [Required]
        [StringLength(100)]
        [Display(Name = "Coffee Name")]
        public string Name {get;set;}
        [Required]
        [StringLength(400)]
        public string Info {get;set;}
        [Required]
        [Display(Name = "Coffee-Price")]
        public decimal Price {get;set;}
        public string Image {get;set;}
        public Order Order {get;set;}
    }
}