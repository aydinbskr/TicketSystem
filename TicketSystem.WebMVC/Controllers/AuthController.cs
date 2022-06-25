using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TicketSystem.Business.Abstract;
using TicketSystem.Core.Concrete.Entities.Enums;
using TicketSystem.Entities.Dtos;
using TicketSystem.WebMVC.Utilities.Extentions;

namespace TicketSystem.WebMVC.Controllers
{
    public class AuthController : Controller
    {
        readonly IAuthService _authService;
        readonly IMapper _mapper;

        public AuthController(IAuthService authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult LogIn()
        {
            return View(new LoginDto());
        }
        [HttpPost]
        public async Task<IActionResult> LogIn(LoginDto loginDto, bool rememberMe = false)
        {
            if (ModelState.IsValid)
            {
                var createResponse = await _authService.Signin(loginDto);
                if (createResponse.Success)
                {
                    await ConfigureCookie(createResponse.Data, rememberMe);
                    return RedirectToAction("GetAll", "Movie");
                }
            }
            return RedirectToAction("LogIn", "Auth");
        }

        //<param name = "id" > This id is for determine the enrolling type (Employee|Customer) </param>
        [HttpGet]
        public IActionResult SignUp(int id)
        {
            ViewData["RegisterType"] = id == 0 ? (int)UserTypes.Customer : (int)UserTypes.Employee;
            return View(new UserCreateDto());
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserCreateDto userCreateDto, int id = 2)
        {
            var result = await this.CreateUser(_authService, _mapper, userCreateDto, id);

            if (result != null)
            {
                await ConfigureCookie(result);
            }

            return RedirectToAction("GetAll", "Movie");
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        private async Task ConfigureCookie(List<Claim> claims, bool rememberMe = false)
        {
            var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = rememberMe,
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity), authProperties);
        }
    }
}
