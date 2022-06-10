using Core.Entities;
using Core.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.BusinessLayer
{
    public class MainBusinessLayer : IBusinessLayer
    {
        private readonly IRepositoryMenu _menuRepo;
        private readonly IRepositoryPiatto _piattiRepo;
        private readonly IRepositoryPerson _personsRepo;

        public MainBusinessLayer(IRepositoryMenu menu, IRepositoryPiatto piatti, IRepositoryPerson persons)
        {
            _menuRepo = menu;
            _piattiRepo = piatti;
            _personsRepo = persons;

        }
        public Esito AggiungiMenu(Menu nuovoMenu)
        {
            Menu menuRecuperato = _menuRepo.GetByMenuId(nuovoMenu.ID_m);
            if (menuRecuperato == null)
            {
                _menuRepo.Add(nuovoMenu);
                return new Esito() { IsOk = true, Messaggio = "Menu aggiunto correttamente" };
            }
            return new Esito() { IsOk = false, Messaggio = "Impossibile aggiungere il Menu perché esiste già un menu con quel id" };

        }

        public Esito AggiungiPerson(Person nuovoPerson)
        {
            var personEsistente = _personsRepo.GetByPersonId(nuovoPerson.ID);
            if (personEsistente == null)
            {
                _personsRepo.Add(nuovoPerson);
                return new Esito { Messaggio = "Person inserito correttamente", IsOk = true };

            }
            return new Esito { Messaggio = "Person corso errato", IsOk = false };

        }

    

    public Esito EliminaPiatto(int id)
        {
            var piattoEsistente = _piattiRepo.GetByPiattoId(id);
            if (piattoEsistente == null)
            {
                return new Esito { Messaggio = "Nessuno Piatto corrispondente all'id inserito", IsOk = false };
            }
            _piattiRepo.Delete(piattoEsistente);
            return new Esito { Messaggio = "Piatto eliminato correttamente", IsOk = true };

        }

        public Person GetAccount(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return null;
            }
            return _personsRepo.GetByUsername(username);
        }

        public List<Menu> GetAllMenu()
        {
            if (_menuRepo.GetAll() == null) { return null;}
             return _menuRepo.GetAll();
        }

        public List<Piatto> GetAllPiatti()
        {
            return _piattiRepo.GetAll();
        }

        public List<Piatto> GetAllPiattiByNomeMenuBL(string? nome)

        {
            List<Piatto> piattoRecuperato = _piattiRepo.GetAllPiattiByNomeMenu(nome);
            if (piattoRecuperato.Count == 0) { return null; }
            return piattoRecuperato;
        }

        public Esito InserisciNuovoPiatto(Piatto nuovoPiatto)
        {
            Menu menuEsistente = _menuRepo.GetByMenuId(nuovoPiatto.MenuId);
            if (menuEsistente == null)
            {
                return new Esito { Messaggio = "Piatto corso errato", IsOk = false };
            }
            _piattiRepo.Add(nuovoPiatto);
            //corsoEsistente.Studenti.Add(nuovoStudente);
            return new Esito { Messaggio = "Piatto inserito correttamente", IsOk = true };

        }

        public Esito ModificaPiatto(int id, string nome, string descr, string tipolog, decimal prezzo, int id_menu)
        {

            var piatto = _piattiRepo.GetByPiattoId(id);
            if (piatto == null)
            {
                return new Esito { Messaggio = "Id Piatto errato o inesistente", IsOk = false };
            }
            piatto.Nome = nome;
            piatto.Descrizione = descr;
            piatto.Tipologia = tipolog;
            piatto.Prezzo = prezzo;
            _piattiRepo.Update(piatto);
            return new Esito { Messaggio = "Piatto é aggiornata correttamente", IsOk = true };
        }
    }
}
