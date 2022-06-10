using Core.BusinessLayer;
using Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC.Helper;
using MVC.Models;

namespace MVC.Controllers
{
    public class MenuController : Controller
    {
        private readonly IBusinessLayer _BL;

        public MenuController(IBusinessLayer bl)
        {
            _BL = bl;
        }


     //   [Authorize(Policy = "Adm")]
        [HttpGet]
        public IActionResult IndexMenu()
        {

            List<Menu> menu = _BL.GetAllMenu();
            List<MenuViewModel> menuViewModel = new List<MenuViewModel>();
            foreach (var item in menu)
            {
                menuViewModel.Add(item.ToMenuViewModel());
            }
            return View(menuViewModel);
        }

      
        public IActionResult DetailsMenu(int id)
        {
            var menu = _BL.GetAllMenu().FirstOrDefault(m => m.ID == id);

            var menuViewModel = menu.ToMenuViewModel();

            return View(menuViewModel);
        }

        [HttpGet]
        public IActionResult CreateMenu() 
        {

            return View();
        }

      [Authorize(Policy = "Adm")]
        [HttpPost]
        public IActionResult CreateMenu(MenuViewModel menuViewModel)
        {
            if (ModelState.IsValid)
            {
                 
                Menu menu = menuViewModel.ToMenu();
                Esito esito = _BL.AggiungiMenu(menu);
                if (esito.IsOk == true)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.MessaggioErrore = esito.Messaggio;
                    return View("ErroreDiBusiness");
                }
            }

            return View(menuViewModel);
        }



    }
}
