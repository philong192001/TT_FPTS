using JsonWebToken.Services.Interface;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace JsonWebToken.Services
{
    public class JwtServices : IJwtServices
    {
        //public string Encode(JwtPayload jwtPayload)
        //{
        //    var jwt = new JsonWebToken<JwtPayload>(payload, Signature());
        //    return jwt.ToEncodedString();
        //}
        //private HashSignatureProvider Signature()
        //{
        //    var secret = Environment.GetEnvironmentVariable("JWT_SECRET");
        //    return HashSignatureProvider.CreateHS256(secret ?? "secret");
        //}
        public string Encode(JwtPayload payload)
        {
            throw new NotImplementedException();
        }
    }
}
