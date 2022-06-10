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
    public class RepositoryMenuEF : IRepositoryMenu
    {
        public Menu Add(Menu item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.ArrayMenu.Add(item);
                ctx.SaveChanges();
            }
            return item;
        }
        public bool Delete(Menu item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.ArrayMenu.Remove(item);
                ctx.SaveChanges();
            }
            return true;
        }

        public List<Menu> GetAll()
        {
            using (var ctx = new MasterContext())
            {      
                return ctx.ArrayMenu.Include(p => p.Piatti).ToList();

            }
        }

        public Menu GetByMenuId(int id)
        {
            using (var ctx = new MasterContext())
            {
                return ctx.ArrayMenu.Include(p => p.Piatti).FirstOrDefault(m => m.ID == id); 
            }
        }

        public Menu Update(Menu item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.ArrayMenu.Update(item);
                ctx.SaveChanges();
            }
            return item;
           }


    }
}
