using Microsoft.EntityFrameworkCore;
using Practico_Tsi.Models;
using Practico_Tsi.Services.Usuarios;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IUsuarioService, UsuarioService>(); //Automaticamente se genera el método cuando se referencia a la clase 

builder.Services.AddDbContext<DatabaseContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



using (var ambiente = app.Services.CreateScope())
{
    var services = ambiente.ServiceProvider;
    try{
    var context = services.GetRequiredService<DatabaseContext>();

    await CargarDb.InsertarDatos(context);
    
    }catch(Exception e)
    {
        var log = services.GetRequiredService<ILogger<Program>>();
        log.LogError(e, "Ocurrio un error en la carga de datos");
    }
}

app.Run();
