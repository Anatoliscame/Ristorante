using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.RepositoryInterface
{
    public interface IRepositoryPerson : IRepository<Person>
    {
        Person GetByUsername(string username);
        Person GetByPersonId(int id);
    }
}
