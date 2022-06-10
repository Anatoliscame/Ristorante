using Core.BusinessLayer;
using Core.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MVC.Helper;
using MVC.Models;
using System.Security.Claims;

namespace MVC.Controllers
{
    public class PersonController : Controller
    {
        private readonly IBusinessLayer BL;
        public PersonController(IBusinessLayer bl)
        {
            BL = bl;
        }



        [HttpGet]
        public IActionResult CreatePerson()
        {

            return View();
        }

        [HttpPost]
        public IActionResult CreatePerson(PersonViewModel personViewModel)
        {
            if (ModelState.IsValid)
            {
                 Person person = personViewModel.ToPerson();
                Esito esito = BL.AggiungiPerson(person);
                if (esito.IsOk == true)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    //Visualizzare la pagina d'errore in una pagina
                    ViewBag.MessaggioErrore = esito.Messaggio;
                    return View("ErroreDiBusiness");
                }

            }
          return View(personViewModel);
        }




        [HttpGet]
        public IActionResult Login(string returnUrl = "/")
        {
            return View(new PersonLoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(PersonLoginViewModel personLoginViewModel)
        {
            if (personLoginViewModel == null)
            {
                return View();
            }

            var person = BL.GetAccount(personLoginViewModel.Username);
            if (person != null && ModelState.IsValid)
            {
                if (person.Password == personLoginViewModel.Password)
                {
                    //l'utente è "autenticato"
                    var claim = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, person.Username),
                        new Claim(ClaimTypes.Role, person.Ruolo.ToString()),
                    };

                    var properties = new AuthenticationProperties
                    {
                        RedirectUri = personLoginViewModel.ReturnUrl,
                        ExpiresUtc = DateTimeOffset.UtcNow.AddHours(1) 
                    };

                    var claimIdentity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimIdentity),
                        properties
                        );
                    return Redirect("/");

                }
                else
                {
                    ModelState.AddModelError(nameof(personLoginViewModel.Password), "Password Errata");
                    return View(personLoginViewModel);
                }
            }
            else
            {
                return View(personLoginViewModel);
            }
            return View();
        }


        public IActionResult Forbidden() => View();
        //{
        //    return View();
        //}

        public async Task<IActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}
