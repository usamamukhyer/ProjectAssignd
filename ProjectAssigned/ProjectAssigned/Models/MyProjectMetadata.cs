using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.IO;

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
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public System.DateTime Joindate { get; set; }
        [Required(ErrorMessage = "salary is required")]
        [StringLength(15, ErrorMessage = "Must be between {2} and {1} characters", MinimumLength = 1)]
        [Range(300, 10000000, ErrorMessage = "Salary must be between 300 and 10000000")]
        public string Salary { get; set; }


        [Required(ErrorMessage = "email is required")]
        [DataType(DataType.EmailAddress, ErrorMessage = "must b include @")]
        [StringLength(30, ErrorMessage = "Must be between {2} and {1} characters", MinimumLength = 8)]
        [Remote("IsUserExists", "CreateDeveloper", ErrorMessage = "Email is already taken", AdditionalFields = "prevemail")]

        public string Email { get; set; }
        [Required(ErrorMessage = "Address is required")]
        [StringLength(100, ErrorMessage = "Must be between {2} and {1} characters", MinimumLength = 10)]
        public string Address { get; set; }
        [Required(ErrorMessage = "Phone is required")]
        
        [Range(0, 20, ErrorMessage = "Phone must be between 0 and 20")]
        [Remote("IsUserExists", "CreateDeveloper", ErrorMessage = "Phone is already taken", AdditionalFields = "prephone")]
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
        [Remote("IsUserExists", "CreateDeveloper", ErrorMessage = "User name is already taken", AdditionalFields = "prevname")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(10, ErrorMessage = "Must be between {2} and {1} characters", MinimumLength = 6)]
        [Remote("IsUserExists", "CreateDeveloper", ErrorMessage = "Password is already taken",AdditionalFields = "prevpass")]
        public string UserPassword { get; set; }
       

    }

    public class AspnetuserMetdata
    {
        [Required(ErrorMessage = "email is required")]
        [DataType(DataType.EmailAddress, ErrorMessage = "must b include @")]
        [StringLength(30, ErrorMessage = "Must be between {2} and {1} characters", MinimumLength = 8)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [StringLength(10, ErrorMessage = "Must be between {2} and {1} characters", MinimumLength = 6)]

        public string PasswordHash { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "the username is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "this First name is required")]
        [StringLength(8, ErrorMessage = "Must be between {2} and {1} characters", MinimumLength = 2)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(8, ErrorMessage = "Must be between {2} and {1} characters", MinimumLength = 2)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Designation is required")]
        [StringLength(10, ErrorMessage = "Must be between {2} and {1} characters", MinimumLength = 6)]
        public string Designation { get; set; }
        public string Address { get; set; }
        public string Salary { get; set; }
        public string Experience { get; set; }
        [Required(ErrorMessage = "Date time is required")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public System.DateTime JoinDate { get; set; }
        [Required(ErrorMessage = "cv is required")]
        public string CV{ get; set; }
        [Required(ErrorMessage = "Photo is required")]
        public string Photo { get; set; }
        [Required(ErrorMessage = "bio is required")]
        public string Bio { get; set; }

      
    }

        public class ProjectFeedbackMetedata
    {
        public int FeedId { get; set; }
        
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public System.DateTime Startdate { get; set; }
        public System.TimeSpan time { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public System.DateTime Enddate { get; set; }
        public string Discription { get; set; }
        public Nullable<int> Project_Id { get; set; }
        public Nullable<int> Developer_Id { get; set; }
        public Nullable<int> ModuleId { get; set; }


    }

    public static class Extension
    {
        public static string FetchUniquePath(this string directoryPath, string imageName)
        {
            string extension = Path.GetExtension(imageName);
            string fileName = DateTime.UtcNow.Ticks.ToString();

            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            int i = 0;
            while (File.Exists(directoryPath + "/" + fileName + i + extension))
                i++;

            return (fileName + i + extension);
        }
    }


}