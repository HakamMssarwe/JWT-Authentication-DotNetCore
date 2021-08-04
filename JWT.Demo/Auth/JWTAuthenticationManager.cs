using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using JWT.Demo.Data;
using Microsoft.IdentityModel.Tokens;

namespace JWT.Demo.Auth
{
    public class JWTAuthenticationManager : IJWTAuthenticationManager
    {
        readonly string Key;    
        public JWTAuthenticationManager(string key)
        {
            this.Key = key;
        }


        public string Authenticate(string username, string password)
        {
            if (!DataAccess.Authorize(username, password))
                return null;


            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, username)
                }),
                //Expires in 24 hours  
                Expires = DateTime.UtcNow.AddHours(24),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256)

            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token); 
        }
    }
}
