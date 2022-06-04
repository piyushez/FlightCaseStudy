using LoginService.DbContexts;
using LoginService.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginService.Repository
{
    public class UserDetailRepository : IUserDetailRepository
    {
        private LoginDbContext _loginDbContext;
        public UserDetailRepository(LoginDbContext loginDbContext)
        {
            _loginDbContext = loginDbContext;
        }
        public IActionResult Login(UserDetail userDetail)
        {
            try
            {
                var user = _loginDbContext.Userdetail.Find(userDetail.UserName);

                if (user != null)
                {
                    if (user.Password == userDetail.Password)
                    {
                        return new JsonResult("Login successfully");
                    }
                    
                }
                
            return new JsonResult("Login failed");
               
            }
            catch(Exception ex)
            {
                return new JsonResult("Login failed: "+ex.Message);
            }
        }

        public IActionResult Register(UserDetail userDetail)
        {
            try
            {
                var userData = _loginDbContext.Userdetail.Find(userDetail.UserName);
                if (userData != null)
                {
                    return new JsonResult("User Already Exists");
                }
                else
                {
                  
                    _loginDbContext.Userdetail.Add(userDetail);
                    _loginDbContext.SaveChanges();
                    return new JsonResult("User Succesfully register");

                }
            }catch(Exception ex)
            {
                throw;
            }
        }
    }
}
