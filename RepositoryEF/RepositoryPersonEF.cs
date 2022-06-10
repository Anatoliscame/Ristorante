using Core.Entities;
using Core.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryEF
{
    public class RepositoryPersonEF : IRepositoryPerson
    {
        public Person Add(Person item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.ArrayPerson.Add(item);
                ctx.SaveChanges();
            }
            return item;
        }

        public bool Delete(Person item)
        {
            throw new NotImplementedException();
        }

        public List<Person> GetAll()
        {
            using (var ctx = new MasterContext())
            {
             
                return ctx.ArrayPerson.ToList();
            }
        }

        public Person GetByPersonId(int id)
        {
            using (var ctx = new MasterContext())
            {
                return ctx.ArrayPerson.FirstOrDefault(u => u.ID == id);
            }
        }

        public Person GetByUsername(string username)
        {
            using (var ctx = new MasterContext())
            {
                if (string.IsNullOrEmpty(username))
                {
                    return null;
                }
                return ctx.ArrayPerson.FirstOrDefault(u => u.Username == username);
            }
        }

        public Person Update(Person item)
        {
            throw new NotImplementedException();
        }
    }
}
