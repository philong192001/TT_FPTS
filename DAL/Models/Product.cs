using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Models
{
    public class Product
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "Enter Your Name")]
        [StringLength(15, ErrorMessage = "Name should be less than or equal to Fifteen characters.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter Your Price")]       
        public float? Price { get; set; }
        [Required(ErrorMessage = "Enter Your Quantity")]
        public int? Quantity { get; set; } = 0;
        [Required(ErrorMessage = "Enter Your ID_Categories")]
        public int? Id_categories { get; set; }
        [Required(ErrorMessage = "Enter Your ID_Brands")]
        public int? Id_brands { get; set; }
        [Required(ErrorMessage = "Enter Your Date")]
        public DateTime Created_Date { get; set; }
        public string brand { get; set; } = "";
        public string category { get; set; } = "";
    }
}
