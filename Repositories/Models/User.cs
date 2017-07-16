using System;
using System.Collections.Generic;

namespace Repositories.Models
{
    public class User
    {
        public User()
        {
            Id = Guid.NewGuid();
            Photos = new HashSet<Photo>();
            Comments = new HashSet<Comment>();
            Albums = new HashSet<Album>();
        }
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Pwd { get; set; }
        public string UserN { get; set; }
        public bool IsAdministrator { get; set; }

        public virtual ICollection<Photo> Photos { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Album> Albums { get; set; }
    }
}