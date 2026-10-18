using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Uber.Models;

namespace Uber.Repos
{
    public class AuthRepo : GenericRepo<User>, IAuthRepo
    {
        private readonly IConfiguration configuration;
        private readonly AppDbContext context;
        public AuthRepo(IConfiguration configuration, AppDbContext context) : base(context)
        {
            this.configuration = configuration;
            this.context = context;
        }

        public string Login(User user)
        {
           return GenerateToken(user);
        }
        private string GenerateToken(User user)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role),
            };
            var Key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["JWT:Key"]));
            var Signature = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);
            var Token = new JwtSecurityToken(
                issuer: configuration["JWT:Issuer"],
                audience: configuration["JWT:Audience"],
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(configuration["JWT:ExpireDate"])),
                claims: claims,
                signingCredentials: Signature
            );

            return new JwtSecurityTokenHandler().WriteToken(Token);


        }

        public User GetByName(string name)
        {
            return context.Users.FirstOrDefault(e => e.FullName == name);
        }
    }
}
