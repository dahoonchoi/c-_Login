using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApplication4.Controllers;

namespace WebApplication4.Models
{
    public interface IUserRepository
    {
        ClaimsPrincipal GetClaimsPrincipal(UserLoginModel model);

        User ReadUser(string id);

        
        bool isCorrectUser(UserLoginModel model);
      

    }
}
