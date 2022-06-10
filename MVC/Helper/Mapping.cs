using Core.Entities;
using MVC.Models;

namespace MVC.Helper
{
    public static class Mapping
    {
        public static MenuViewModel ToMenuViewModel(this Menu menu)
        {
            ICollection<PiattoViewModel> piattiViewModel = new List<PiattoViewModel>();
            foreach (var item in menu.Piatti)
            {
                piattiViewModel.Add(item?.ToPiattoViewModel());
            }


            return new MenuViewModel
            {
                ID = menu.ID_m,
                Nome = menu.Nome,
                Piatti = piattiViewModel 
            };
        }

        public static PiattoViewModel ToPiattoViewModel(this Piatto piatto)
        {
            //MenuViewModel menu  = new MenuViewModel();

            return new PiattoViewModel
            {
                ID = piatto.ID,
                Nome = piatto.Nome,
                Descrizione = piatto.Descrizione,
                Tipologia = piatto.Tipologia,
                Prezzo = piatto.Prezzo,
                MenuId = piatto.MenuId
            
            };
        }

  
        public static Menu ToMenu(this MenuViewModel menuViewModel)
        {
            ICollection<Piatto> piatti = new List<Piatto>();
            foreach (var item in menuViewModel.Piatti)
            {
                piatti.Add(item?.ToPiatto());
            }

            return new Menu
            {
                ID_m = menuViewModel.ID, 
                Nome = menuViewModel.Nome,
                Piatti = piatti

            };
        }


        public static Piatto ToPiatto(this PiattoViewModel piattoViewModel)
        {

            return new Piatto
            {
                ID = piattoViewModel.ID,
                Nome = piattoViewModel.Nome,
                Descrizione = piattoViewModel.Descrizione,
                Tipologia = piattoViewModel.Tipologia,
                Prezzo = piattoViewModel.Prezzo
               // MenuId = piattoViewModel.MenuId

            };
        }


         public static Person ToPerson(this PersonViewModel personViewModel)
        {

            return new Person
            {
                ID = personViewModel.Id,
                Username = personViewModel.Username,
                Password = personViewModel.Password,
                Ruolo = personViewModel.Ruolo


            };
        }
    }
}
