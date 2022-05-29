using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeedyHub.Shared
{
    public class ItemDetails
    {
        [Key]
        public int ItemId { get; set; }
        [Required]
        public string ItemName { get; set; } = string.Empty;
        public double Price { get; set; }
        public double TotalPrice { get; set; }
        public int Quantity { get; set; }
        public int TotalQuantity { get; set; }
        public string Description { get; set; } = string.Empty;
       
        public string Image { get; set; } = string.Empty ;
        public DateTime? DateOfTransaction { get; set; }
        public  Category?  category { get; set; }
        public int CategoryId { get; set; }
    }
}
