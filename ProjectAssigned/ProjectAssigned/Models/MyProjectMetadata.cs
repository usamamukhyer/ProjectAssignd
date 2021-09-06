﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ProjectAssigned.Models
{
    public class CreateDeveloperMetadata
    {
      
        public int Developer_Id { get; set; }
        [Required(ErrorMessage = "this First name is required")]
        [StringLength(8, ErrorMessage = "Must be between {2} and {1} characters", MinimumLength = 2)]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(8, ErrorMessage = "Must be between {2} and {1} characters", MinimumLength = 2)]
        public string Lastname { get; set; }
        [Required(ErrorMessage = "image is required")]
        public string Image { get; set; }
        [Required(ErrorMessage = "Designation is required")]
        [StringLength(10, ErrorMessage = "Must be between {2} and {1} characters", MinimumLength = 6)]
        public string Designation { get; set; }
        [Required(ErrorMessage = "Date time is required")]
        public System.DateTime Joindate { get; set; }
        [Required(ErrorMessage = "salary is required")]
        [StringLength(15, ErrorMessage = "Must be between {2} and {1} characters", MinimumLength = 1)]
        [Range(300, 10000000, ErrorMessage = "Salary must be between 300 and 10000000")]
        public string Salary { get; set; }


        [Required(ErrorMessage = "email is required")]
        [DataType(DataType.EmailAddress, ErrorMessage = "must b include @")]
        [StringLength(30, ErrorMessage = "Must be between {2} and {1} characters", MinimumLength = 8)]
        [Remote("IsUserExists", "CreateDeveloper", ErrorMessage = "Email is already taken")]

        public string Email { get; set; }
        [Required(ErrorMessage = "Address is required")]
        [StringLength(100, ErrorMessage = "Must be between {2} and {1} characters", MinimumLength = 10)]
        public string Address { get; set; }
        [Required(ErrorMessage = "Phone is required")]
        
        [Range(0, 20, ErrorMessage = "Phone must be between 0 and 20")]
        [Remote("IsUserExists", "CreateDeveloper", ErrorMessage = "Phone is already taken")]
        public string Phone { get; set; }
        [StringLength(20, ErrorMessage = "Must be between {2} and {1} characters", MinimumLength = 6)]
        [Required(ErrorMessage = "Experience is required")]
        public string Experience { get; set; }
        [Required(ErrorMessage = "cv is required")]
        public string Cv { get; set; }
        [Required(ErrorMessage = "Bio is required")]
        [StringLength(200, ErrorMessage = "Must be between {2} and {1} characters", MinimumLength = 10)]
        public string Bio { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [StringLength(20, ErrorMessage = "Must be between {2} and {1} characters", MinimumLength = 4)]
        [Remote("IsUserExists", "CreateDeveloper", ErrorMessage = "User name is already taken")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(10, ErrorMessage = "Must be between {2} and {1} characters", MinimumLength = 6)]
        [Remote("IsUserExists", "CreateDeveloper", ErrorMessage = "Password is already taken")]
        public string UserPassword { get; set; }
       

    }

    
    
}