using Core.Entities;
using Core.RepositoryInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryEF
{
    public class RepositoryPiattoEF : IRepositoryPiatto
    {
        public Piatto Add(Piatto item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.ArrayPiatti.Add(item);
                ctx.SaveChanges();
            }
            return item;
        }

        public bool Delete(Piatto item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.ArrayPiatti.Remove(item);
                ctx.SaveChanges();
            }
            return true;
        }

        public List<Piatto> GetAll()
        {
            using (var ctx = new MasterContext())
            {
                return ctx.ArrayPiatti.Include(m => m.Menu).ToList();

            }
        }

        public Piatto GetByPiattoId(int id)
        {
            using (var ctx = new MasterContext())
            {
                return ctx.ArrayPiatti.Include(m => m.Menu).FirstOrDefault(s => s.ID == id);
            }
        }

        public List<Piatto> GetAllPiattiByNomeMenu(string nome)
        {
            try
            {
                using (var ctx = new MasterContext())
                {
                    return ctx.ArrayPiatti.Include(m => m.Menu).Where(r => r.Menu.Nome.Equals(nome)).ToList();
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Piatto>();
            }
        }

        public Piatto Update(Piatto item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.ArrayPiatti.Update(item);
                ctx.SaveChanges();
            }
            return item;
        }
    }
}
