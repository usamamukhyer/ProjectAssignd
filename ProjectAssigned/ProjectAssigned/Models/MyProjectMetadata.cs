using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace ProjectAssigned.Models
{
    public class CreateDeveloperMetadata
    {
        
        public int Developer_Id { get; set; }
        [Required(ErrorMessage ="this First name is required")]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        public string Lastname { get; set; }
        [Required(ErrorMessage = "image is required")]
        public string Image { get; set; }
        [Required(ErrorMessage = "Designation is required")]
        public string Designation { get; set; }
        [Required(ErrorMessage = "Date time is required")]
        public System.DateTime Joindate { get; set; }
        [Required(ErrorMessage = "salary is required")]
        public string Salary { get; set; }
        [Required(ErrorMessage = "email is required")]
        [DataType(DataType.EmailAddress,ErrorMessage ="must b include @")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Phone is required")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Experience is required")]
        public string Experience { get; set; }
        [Required(ErrorMessage = "cv is required")]
        public string Cv { get; set; }
        [Required(ErrorMessage = "Bio is required")]
        public string Bio { get; set; }
    }
}