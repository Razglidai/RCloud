using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Threading.Tasks;

namespace RCloud.Models
{
    public class User
    {
        public User(string username, string email, string hashPassword)
        {
            Username = username;
            Email = email;
            HashPassword = hashPassword;
            RegisterTime = DateTime.UtcNow;
        }
        
        public Guid Id{ get; init; }
        public string Username{ get; set; }
        public string HashPassword{ get; set; }

        public string Email{ get; set; }

        public DateTime RegisterTime{ get; init; }

    }
}