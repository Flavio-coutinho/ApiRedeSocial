using ApiRedeSocial.Models;
using ApiRedeSocial.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ApiRedeSocial.Controllers
{
    public class BaseController : ControllerBase
    {
        protected readonly IUserRepository _userRepository;

        public BaseController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        protected User ReadToken()
        {
            var idUser = User.Claims.Where(c => c.Type == ClaimTypes.Sid).Select(c => c.Value).FirstOrDefault();
            if(string.IsNullOrEmpty(idUser))
            {
                return null;
            }
            else
            {
                return _userRepository.GetUserById(int.Parse(idUser));
            }
        }
    }
}