using ApiRedeSocial.Dtos;
using ApiRedeSocial.Models;
using ApiRedeSocial.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiRedeSocial.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        private readonly ILogger<UserController> _logger;


        public UserController(ILogger<UserController > logger, 
            IUserRepository userRepository) : base(userRepository)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetUser()
        {
            try
            {
                User user = ReadToken();

                return Ok(new UserResponseDto
                {
                    Name = user.Name,
                    Email = user.Email,
                });
            } catch(Exception e) 
            {
                _logger.LogError("An error occurred while getting the user");
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponseDto()
                {
                    Description = "The following error occurred: " + e.Message,
                    Status = StatusCodes.Status500InternalServerError
                });
            }
        }

    }
}
