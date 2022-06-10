using Core.BusinessLayer;
using Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.Helper;
using MVC.Models;

namespace MVC.Controllers
{
    public class PiattoController : Controller
    {
        private readonly IBusinessLayer _BL;

        public PiattoController(IBusinessLayer bl)
        {
            _BL = bl;
        }

 decimal somma = 0;
        [HttpGet]  
       
        public IActionResult IndexPiatto()
        {
          
            List<Piatto> piatti = _BL.GetAllPiatti();
            List<PiattoViewModel> piattoStudenteViewModel = new List<PiattoViewModel>();
            foreach (var item in piatti)
            {
                somma = somma + item.Prezzo;
             
                piattoStudenteViewModel.Add(item.ToPiattoViewModel());
                foreach (var itemV in piattoStudenteViewModel) {
                    itemV.Total = somma; 
                }
            }
            return View(piattoStudenteViewModel);
        }

        public IActionResult DetailsPiatto(int id)
        {
            var piatti = _BL.GetAllPiatti().FirstOrDefault(c => c.ID == id);
           
            var piattoViewModel = piatti.ToPiattoViewModel();
            return View(piattoViewModel);
        }

        [Authorize(Policy = "Adm")]
        [HttpGet]
       public IActionResult CreatePiatto()
        {
            LoadViewBag();
            return View();
        }
        [Authorize(Policy = "Adm")]
        [HttpPost]
        public IActionResult CreatePiatto(PiattoViewModel piattoViewModel)
        {
            if (ModelState.IsValid)
            {

                Piatto piatto = piattoViewModel.ToPiatto();
                Esito esito = _BL.InserisciNuovoPiatto(piatto);
                if (esito.IsOk == true)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {

                    ViewBag.MessaggioErrore = esito.Messaggio;
                    return View("ErroreDiBusiness");
                }
          
            }  else {
              
             LoadViewBag();
             return View(piattoViewModel);
            }
     }


        [Authorize(Policy = "Adm")]
        [HttpGet]
        public IActionResult EditPiatto(int id)
        {

            var piatto = _BL.GetAllPiatti().FirstOrDefault(p => p.ID == id);

            var piattoVM = piatto.ToPiattoViewModel();

            LoadViewBag();
            return View(piattoVM);

        }

        [Authorize(Policy = "Adm")]
        [HttpPost]
        public IActionResult EditPiatto(PiattoViewModel piattoViewModel)
        {
            if (ModelState.IsValid)
            {
                var piatto = piattoViewModel.ToPiatto();
               Esito esito = _BL.ModificaPiatto(piatto.ID, piatto.Nome, piatto.Descrizione, piatto.Tipologia, piatto.Prezzo, piatto.MenuId);
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
            LoadViewBag();
            return View(piattoViewModel);
        }


        [Authorize(Policy = "Adm")]
        [HttpGet]
        public IActionResult DeletePiatto(int id)
        {


            var piatto = _BL.GetAllPiatti().FirstOrDefault(p => p.ID == id);

            var piattoVM = piatto.ToPiattoViewModel();
            LoadViewBag();
            return View(piattoVM);
        }


        [Authorize(Policy = "Adm")]
        [HttpPost]
        public IActionResult DeletePiatto(PiattoViewModel piattoViewModel)
        {

            var piatto = piattoViewModel.ToPiatto();
            Esito esito = _BL.EliminaPiatto(piatto.ID); ;

            if (esito.IsOk == true)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.MessaggioErrore = esito.Messaggio;
                  LoadViewBag();
                return View("ErroreDiBusiness");
            }

            return View(piattoViewModel);
        }


        private void LoadViewBag()
        {
            ViewBag.Tipologia = new SelectList(new[]
            {
                new{Value="Primo", Text="Primo"},
                new{Value="Secondo", Text="Secondo"},
                new{Value="Contorno", Text="Contorno" },
                new{Value="Dolce", Text="Dolce"}

            }.OrderBy(x => x.Text), "Value", "Text");
        }
    }
}
