using System;
using System.Collections.Generic;
using Biblioteca.ML;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Biblioteca.DAL.DataContext
{
    public partial class Biblioteca_prueba1Context : DbContext
    {
        public Biblioteca_prueba1Context()
        {
        }

        public Biblioteca_prueba1Context(DbContextOptions<Biblioteca_prueba1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Libro> Libros { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
