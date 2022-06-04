using LoginService.Models;
using LoginService.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginService.Controller
{
    public class LoginController : ControllerBase
    {
        private IUserDetailRepository _userDetailRepository;
        public LoginController(IUserDetailRepository userDetailRepository)
        {
            _userDetailRepository = userDetailRepository;
        }

        [HttpGet]
        [Route("Login/test")]
        public string testMethod()
        {
            return "Hello!";
        }
        [HttpPost]

        [Route("Login/Login")]
        public IActionResult Login([FromBody] UserDetail user)
        {
            try
            {
                return _userDetailRepository.Login(user);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("Login/Register")]
        public IActionResult Register([FromBody] UserDetail user)
        {
            try
            {
                return _userDetailRepository.Register(user);
            }catch(Exception ex)
            {
                return new JsonResult("Failed to register user");
            }
        }
    }
}
