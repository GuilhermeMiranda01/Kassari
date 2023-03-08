using KassariV2.Context;
using KassariV2.Entities;
using KassariV2.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace KassariV2.Repository
{
    public class JWTManagerRepository : IJWTManagerRepository
    {
        private readonly IConfiguration iconfiguration;
        private KassariContext _context;
        public JWTManagerRepository(IConfiguration iconfiguration, KassariContext context)
        {
            this.iconfiguration = iconfiguration;
            _context = context;
        }


        Dictionary<string, string> UsersRecords = new Dictionary<string, string>();
        public void FillUsersRecords()
        {
            var users = _context.Users.ToList();
            foreach (var user in users)
            {
                UsersRecords.Add(user.Username, user.Password);
            }
        }

        public Tokens Authenticate(Users users)
        {
            FillUsersRecords();
            if (!UsersRecords.Any(x => x.Key == users.Username && x.Value == users.Password))
            {
                return null;
            }

            // Else we generate JSON Web Token
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(iconfiguration["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
              {
             new Claim(ClaimTypes.Name, users.Username)
              }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            //tokenDescriptor.Expires.Value.AddMinutes(20.0); pra ter expiração de sessão
            return new Tokens { Token = tokenHandler.WriteToken(token) };

        }
    }
}
