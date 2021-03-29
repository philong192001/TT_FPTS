using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jwt_Api_demo.Models
{
    public class LoginReq
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
