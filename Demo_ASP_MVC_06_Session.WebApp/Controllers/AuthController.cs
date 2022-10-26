using Demo_ASP_MVC_06_Session.BLL.Exceptions;
using Demo_ASP_MVC_06_Session.BLL.Interfaces;
using Demo_ASP_MVC_06_Session.Domain.Entities;
using Demo_ASP_MVC_06_Session.WebApp.Models;
using Demo_ASP_MVC_06_Session.WebApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;

namespace Demo_ASP_MVC_06_Session.WebApp.Controllers
{
    public class AuthController : Controller
    {
        private IMemberService _memberService;
        private SessionService _sessionService;

        public AuthController(IMemberService memberService, SessionService sessionService)
        {
            _memberService = memberService;
            _sessionService = sessionService;
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(AuthRegisterViewModel authRegister)
        {
            if (!ModelState.IsValid)
            {
                return View(authRegister);
            }

            Member? member;
            try
            {
                member = _memberService.Register(new Member()
                {
                    Email = authRegister.Email,
                    Pseudo = authRegister.Pseudo,
                    Password = authRegister.Password
                });
            }
            catch (IdentifiantAlreadyExistsException e)
            {
                ModelState.AddModelError("Password", e.Message);
                return View(authRegister);
            }

            // Utilisation de la session via le service
            _sessionService.Login(member);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(AuthLoginViewModel authLogin)
        {
            if(!ModelState.IsValid)
            {
                return View(authLogin);
            }

            Member? member;
            try
            {
                member = _memberService.Login(authLogin.Idenfifiant, authLogin.Password);
            }
            catch (IdentifiantException e)
            {
                ModelState.AddModelError("Password", "Error login !");
                return View(authLogin);
            }

            // Utilisation de la session via le service
            _sessionService.Login(member);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            // Utilisation de la session via le service
            _sessionService.Logout();

            return RedirectToAction("Index", "Home");
        }


    }
}
