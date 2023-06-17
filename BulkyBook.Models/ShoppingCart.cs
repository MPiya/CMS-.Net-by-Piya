using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BulkyBook.Models
{
    public class ShoppingCart
    {

		[Key]
		public int Id { get; set; }

        public Product Product { get; set; }

		[ForeignKey("ProductId")]
		[ValidateNever]
		public int ProductId { get; set; }

        [Range(1, 1000, ErrorMessage = "Please enter a value between 1 and 1000")]
        public int Count { get; set; }

		[ForeignKey("ApplicationUserId")]
		[ValidateNever]
		public string ApplicationUserId  { get; set; }
      
      
        public ApplicationUser ApplicationUser { get; set; }

        [NotMapped]
        public double Price { get; set; }



    }
}
