namespace Biblioteca.AppWeb.Models.ViewModels
{
    public class VMLibro
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = null!;
        public string Autor { get; set; } = null!;
        public string? FechaPublicacion { get; set; }
    }
}
