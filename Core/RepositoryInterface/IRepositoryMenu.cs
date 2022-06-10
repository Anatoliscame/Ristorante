using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.RepositoryInterface
{
    public interface IRepositoryMenu : IRepository<Menu>
    {
        public Menu GetByMenuId(int id);
    }
}
