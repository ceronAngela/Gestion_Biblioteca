using System;
using System.Collections.Generic;

namespace Biblioteca.ML
{
    public partial class Libro
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = null!;
        public string Autor { get; set; } = null!;
        public DateTime FechaPublicacion { get; set; }
    }
}
