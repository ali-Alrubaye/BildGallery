using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LabEtt.Models
{
    public class AppUserViewModel
    {
        public bool IsAdministrator { get; set; }
        public Guid Id { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Pwd { get; set; }
        [Required]
        [Display(Name = "UserName")]
        public string UserN { get; set; }
    }
}