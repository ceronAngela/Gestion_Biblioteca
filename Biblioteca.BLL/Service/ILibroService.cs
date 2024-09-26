using Biblioteca.ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.BLL.Service
{
    public interface ILibroService
    {
        Task<bool> Insert(Libro model);
        Task<bool> Update(Libro model);
        Task<bool> Delete(int id);
        Task<Libro> Get(int id);
        Task<Libro> GetForName(string name);
        Task<IQueryable<Libro>> GetAll();
    }
}
