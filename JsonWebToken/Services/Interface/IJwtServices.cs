using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace JsonWebToken.Services.Interface
{
    public interface IJwtServices
    {
        string Encode(JwtPayload payload);
    }
}
