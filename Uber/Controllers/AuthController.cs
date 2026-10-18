using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Uber.DTOs;
using Uber.Repos;

namespace Uber.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork UnitOfWork;
        public AuthController(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }
        [HttpPost]
        public IActionResult Login(LoginDTO login)
        {
            var User = UnitOfWork.Users.GetByName(login.FullName);
           string token =  UnitOfWork.Users.Login(User);
            return Ok(token);
        }
    }
}
