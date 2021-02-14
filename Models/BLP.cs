using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookList.Models
{
    // Make all fileds required 
    public class BLP
    {
        // Set BookId as the auto generated primary Key
        [Key]
        public int BookId { get; set; }

        // Set validation critira for all other fields below 
        [Required]
        [Display(Description ="Title")]
        public string Title { get; set; }

        [Required]
        [Display(Description ="Author First Name")]
        public string AuthorFirstName { get; set; }

        [Required]
        [Display(Description = "Author Last Name")]
        public string AuthorLastName { get; set; }

        [Required]
        [Display(Description = "Publisher")]
        public string Publisher { get; set; }

        [Required]
        //Restrict the length of ISBN to 14
        [StringLength(14)]
        [Display(Description = "ISBN")]
        public string ISBN { get; set; }

        [Required]
        [Display(Description = "Category 1")]
        public string Category1 { get; set; }

        [Required]
        [Display(Description = "Category 2")]
        public string Category2 { get; set; }

        [Required]
        [Display(Description = "Price")]
        [DataType(DataType.Currency)]
        /*[System.ComponentModel.DataAnnotations.Schema.Column(TypeName = "decimal(18,4)")]*/
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Invalid Price")]
        public float Price { get; set; }
    }
}
