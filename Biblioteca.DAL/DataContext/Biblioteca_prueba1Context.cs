using System;
using System.Collections.Generic;
using Biblioteca.ML;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Biblioteca.DAL.DataContext
{
    //public class ApplicationUser : IdentityUser
    //{
    //    // Agrega propiedades personalizadas si las necesitas
    //}
    public partial class Biblioteca_prueba1Context : IdentityDbContext
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
            // Es importante llamar a base.OnModelCreating para que Identity configure las tablas correctamente
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityUser>().ToTable("AspNetUsers");

            OnModelCreatingPartial(modelBuilder);

        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
