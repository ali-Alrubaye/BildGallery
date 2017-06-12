using System;
using System.ComponentModel;

namespace LabEtt.Models
{
    public class PhotoViewModel
    {
        [DisplayName("Gallery")]
        public Guid Id { get; set; }
        [DisplayName("Photo Name")]
        public string PhotoName { get; set; }
        public string ImagPath { get; set; }
        public string Description { get; set; }
    }
}