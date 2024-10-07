using Biblioteca.Web.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Biblioteca.DAL.DataContext;
using Biblioteca.DAL.Repository;
using Biblioteca.ML;
using Biblioteca.BLL.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<Biblioteca_prueba1Context>(options =>
    options.UseSqlServer(connectionString));

//cualquier controlador que use la interfaz lo va atrabajar dorectamente con librorepository
//ya no se usa instancia a objetos sino por inyeccion de dependencias
builder.Services.AddScoped<IGenericRepository<Libro>, LibroRepository>();

//Para poder usar en el resto del proyecto
builder.Services.AddScoped<ILibroService, LibroService>();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<Biblioteca_prueba1Context>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Libro/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Libro}/{action=Index}/{id?}");

    //endpoints.MapGet("/", context =>
    //{
    //    context.Response.Redirect("/Identity/Account/Login");
    //    return Task.CompletedTask;
    //});

    endpoints.MapRazorPages();
});


//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Account}/{action=Login}/{id?}");
//app.MapRazorPages();

app.Run();
