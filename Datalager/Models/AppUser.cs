

using System;

namespace Datalager.Models
{
    public class AppUser
    {
        public bool IsAdministrator { get; set; }
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Pwd { get; set; }
        public string UserN { get; set; }

    }
}