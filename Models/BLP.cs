﻿using System;
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

        //Data normalization by breaking the full-name into first and last names
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
        //Set up ISBN validation using regular expression 
        [StringLength(14)]
        [RegularExpression("^(?:ISBN(?:-13)?:?\\ )?(?=[0-9]{13}$|(?=(?:[0-9]+[-\\ ]){4})[-\\ 0-9]{17}$)97[89][-\\ ]?[0-9]{1,5}[-\\ ]?[0-9]+[-\\ ]?[0-9]+[-\\ ]?[0-9]$", ErrorMessage = "Must be a valid ISBN number in format and 10 or 13 digits")]
        [Display(Description = "ISBN")]
        public string ISBN { get; set; }

        //Data normalization by breaking the original category into category 1 and 2
        [Required]
        [Display(Description = "Category 1")]
        public string Category1 { get; set; }

        [Required]
        [Display(Description = "Category 2")]
        public string Category2 { get; set; }

        [Required]
        [Display(Description = "Price")]
        [DataType(DataType.Currency)]
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Invalid Price")]
        public float Price { get; set; }

        // Added the PageNum variable to record and display total number of pages in each book 
        public string PageNum { get; set; }
    }
}
