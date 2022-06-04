using LoginService.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginService.Repository
{
    public interface IUserDetailRepository
    {
        IActionResult Login(UserDetail userDetail);

        IActionResult Register(UserDetail userDetail);
    }
}
