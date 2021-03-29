using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Jwt_Api_demo.Models
{
    public class UsersJWT
    {
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public byte[] Password { get; set; }

        public byte[] PasswordKey { get; set; }
    }
}
