using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary.Models
{
    public class GetUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }
}
