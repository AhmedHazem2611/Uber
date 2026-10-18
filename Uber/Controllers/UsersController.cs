using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Uber.Repos;

namespace Uber.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        public UsersController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet("drivers")]
        public async Task<IActionResult> GetDrivers()
        {
            var Drivers = await unitOfWork.Users.GetAll();
            return Ok(Drivers);
        }
    }
}
