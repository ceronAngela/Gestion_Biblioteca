using Biblioteca.AppWeb.Models.ViewModels;
using Biblioteca.BLL.Service;
using Biblioteca.ML;
using Biblioteca.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Globalization;

namespace Biblioteca.Web.Controllers
{
    public class LibroController : Controller
    {
        //Inyeccion de dependencias
        private readonly ILibroService _libroService;

        public LibroController(ILibroService libroService)
        {
            _libroService = libroService;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            IQueryable<Libro> querylibros = await _libroService.GetAll();
            List<VMLibro> list = querylibros.Select(x => new VMLibro()
            {
                Id = x.Id,
                Titulo = x.Titulo,
                Autor = x.Autor,
                FechaPublicacion = x.FechaPublicacion.ToString("dd/MM/yyyy"),
            }).ToList();

            return StatusCode(StatusCodes.Status200OK, list);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] VMLibro libro)
        {
            try
            {
                Libro nuevoLibro = new Libro()
                {
                    Titulo = libro.Titulo,
                    Autor = libro.Autor,
                    FechaPublicacion = Convert.ToDateTime(libro.FechaPublicacion)
                };

                bool respuesta = await _libroService.Insert(nuevoLibro);

                return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { valor = 0 });
            }
            
        }


        [HttpPut]
        public async Task<IActionResult> Update([FromBody] VMLibro libro)
        {
            Libro nuevoLibro = new Libro()
            {
                Id=libro.Id,
                Titulo = libro.Titulo,
                Autor = libro.Autor,
                FechaPublicacion = DateTime.ParseExact(libro.FechaPublicacion, "dd/MM/yyy", CultureInfo.CreateSpecificCulture("es-CO"))
            };

            bool respuesta = await _libroService.Update(nuevoLibro);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
        }



        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {

            bool respuesta = await _libroService.Delete(id);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}