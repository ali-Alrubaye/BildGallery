using System;

namespace Datalager.Models
{
    public class Photo
    {
        public Photo()
        {
            PhotoId = Guid.NewGuid();
        }


        public Guid PhotoId { get; set; }
        public string PhotoName { get; set; }

        public DateTime PhotoDate { get; set; }
        public string Description { get; set; }
        public string PhotoPath { get; set; }
      

    }
}
