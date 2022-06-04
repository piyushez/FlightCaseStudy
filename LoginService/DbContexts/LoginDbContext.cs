using LoginService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace LoginService.DbContexts
{
    public class LoginDbContext:DbContext
    {
        public LoginDbContext(DbContextOptions<LoginDbContext> options):base(options)
        {

        }

        public DbSet<UserDetail> Userdetail { get; set; }
    }
}
