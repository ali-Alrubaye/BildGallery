using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LabEtt.Models
{
    public class PhotoViewModel
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        [Display(Name = "PhotoName")]
        public string PhotoName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime PhotoDate { get; set; }
        [Required]
        [Display(Name = "PhotoPath")]
        public string PhotoPath { get; set; }
        [Required]
        [Display(Name = "PhotoDescription")]
        public string Description { get; set; }
    }
}