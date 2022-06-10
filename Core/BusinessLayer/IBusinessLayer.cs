using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.BusinessLayer
{
    public interface IBusinessLayer
    {
        List<Menu> GetAllMenu();
        Esito AggiungiMenu(Menu nuovoMenu);
        List<Piatto> GetAllPiatti();
        Esito InserisciNuovoPiatto(Piatto nuovoPiatto);
        Esito ModificaPiatto(int id, string nome, string descr, string tipolog, decimal prezzo, int id_menu);
        Esito EliminaPiatto(int id);
        
       // Piatto GetPiattiByID(int id);
        Person GetAccount(string username);
         Esito AggiungiPerson(Person nuovoPerson);

        List<Piatto> GetAllPiattiByNomeMenuBL(string? nome);



    }
}
