using Biblioteca.DAL.DataContext;
using Biblioteca.DAL.Repository;
using Biblioteca.ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.BLL.Service
{
    public class LibroService : ILibroService
    {
        private readonly IGenericRepository<Libro> _libroRepo;
        public LibroService(IGenericRepository<Libro> libroRepo)
        {
            _libroRepo = libroRepo;
        }
        public async Task<bool> Delete(int id)
        {
            return await _libroRepo.Delete(id);
        }

        public async Task<Libro> Get(int id)
        {
            return await _libroRepo.Get(id);
        }

        public async Task<IQueryable<Libro>> GetAll()
        {
            return await _libroRepo.GetAll();
        }

        public async Task<Libro> GetForName(string name)
        {
            IQueryable<Libro> queryLibroSql = await _libroRepo.GetAll();
            Libro libro = queryLibroSql.Where(x => x.Titulo == name).FirstOrDefault();
            return libro;
        }

        public async Task<bool> Insert(Libro model)
        {
           return await (_libroRepo.Insert(model));
        }

        public async Task<bool> Update(Libro model)
        {
            return await _libroRepo.Update(model);
           
        }
    }
}
