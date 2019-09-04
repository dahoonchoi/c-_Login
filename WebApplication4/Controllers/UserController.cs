using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class UserController : Controller
    {

        private IUserRepository _repository;

        private IHttpContextAccessor _accessor;

        public UserController(IUserRepository repository, IHttpContextAccessor accessor)
        {
            _repository = repository;
            _accessor = accessor;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginModel model, string returnUrl = null)
        {
            //모델 상테가 유효할때 즉 데이터값이 있을때
            if (ModelState.IsValid)
            {
                if (_repository.isCorrectUser(model))
                {
                    var principal = _repository.GetClaimsPrincipal(model);
                    /*System.Diagnostics.Trace.WriteLine();*/
                    await HttpContext.SignInAsync(principal);

                    if (string.IsNullOrWhiteSpace(returnUrl))
                    {
                        return LocalRedirect("/");
                    }
                    else
                    {
                        
                        return LocalRedirect(returnUrl);
                    }
                }
                return View(model);
            }
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }

    }
}