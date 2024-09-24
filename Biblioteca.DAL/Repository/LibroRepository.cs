using Biblioteca.DAL.DataContext;
using Biblioteca.ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.DAL.Repository
{
    public class LibroRepository : IGenericRepository<Libro>
    {
        private readonly Biblioteca_prueba1Context _dbConecction;
        public LibroRepository(Biblioteca_prueba1Context context)
        {
            _dbConecction = context;
        }


        public async Task<bool> Delete(int id)
        {
            try
            {
                Libro book = _dbConecction.Libros.First(x => x.Id == id);
                _dbConecction.Libros.Remove(book);
                await _dbConecction.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) { 
                return false;
            }
            
        }

        public async Task<Libro> Get(int id)
        {
           //validar cuando sea null
            return await _dbConecction.Libros.FindAsync(id);

        }

        public async Task<IQueryable<Libro>> GetAll()
        {
            IQueryable<Libro> queryLibroSQL = _dbConecction.Libros;
            return queryLibroSQL;
        }

        public async Task<bool> Insert(Libro model)
        {
            try
            {
                _dbConecction.Libros.Add(model);
                await _dbConecction.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                //implementar los logs
                return false;
            }
        }

        public async Task<bool> Update(Libro model)
        {
            try
            {
                _dbConecction.Update(model);
                await _dbConecction.SaveChangesAsync();
                return true;
            }
            catch { return false; }
        }
    }
}
