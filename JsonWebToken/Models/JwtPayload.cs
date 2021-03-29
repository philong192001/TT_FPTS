using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JsonWebToken.Models
{
    public class JwtPayload
    {
        public string Sub { get; set; } // Subject
        public string Iss { get; set; } // Issuer
        public string Aud { get; set; } // Audience
        public long Exp { get; set; } // Expiration time

        // Private claims
        public bool manager { get; set; }
        public bool admin { get; set; }
    }
}
