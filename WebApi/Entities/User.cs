using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

#nullable disable

namespace WebApi.Entities
{
    public partial class User
    {
        public User()
        {
            Issues = new HashSet<Issue>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] Uhash { get; set; }
        public byte[] Usalt { get; set; }

        public virtual ICollection<Issue> Issues { get; set; }

        public void GeneratePassword(string password)
        {
            using (var hmac = new HMACSHA512())
            {
                Usalt = hmac.Key;
                Uhash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            }
        }

        public bool ValidatePassword(string password)
        {
            using (var hmac = new HMACSHA512(Usalt))
            {
                var _hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < _hash.Length; i++)
                {
                    if (_hash[i] != Uhash[i])
                        return false;
                }
            }

            return true;
        }
    }
}
