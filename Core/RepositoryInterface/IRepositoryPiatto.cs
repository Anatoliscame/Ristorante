using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.RepositoryInterface
{
    public interface IRepositoryPiatto : IRepository<Piatto>
    {
        public Piatto GetByPiattoId(int id);
        public List<Piatto> GetAllPiattiByNomeMenu(string nome);


    }
}
