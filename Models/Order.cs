using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SportStore.Models
{
    public class Order
    {
        [BindNever]
        public int OrderId { get; set; }

        [BindNever]
        public ICollection<CartItem> Items { get; set; }

        [Required(ErrorMessage = "Please Enter Your Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter Your Address")]
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }

        [Required(ErrorMessage = "Please Enter Your City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please Enter Your State")]
        public string State { get; set; }

        public string Zip { get; set; }

        [Required(ErrorMessage = "Please Enter Your Country")]
        public string Country { get; set; }

        public bool GiftWrap { get; set; }
    }
}
