using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practico_Tsi.Models;
public class CargarDb
{
    public static async Task InsertarDatos(DatabaseContext context)
    {
        
        if (!context.Usuarios.Any())
        {
            var usuario = new Usuario
            {
                Nombre = "Diego Bronc",
                Email = "diegobronc.net",
                Alias = "d.bronc",
                Biografia = "Todo un tema"

            };

            var usuario2 = new Usuario
            {
                Nombre = "Daniela de la Sierra",
                Email = "danieladls.net",
                Alias = "d.dlsierra",
                Biografia = "12345"
            };

            var usuario3 = new Usuario
            {
                Nombre = "Adrian Gioda",
                Email = "adriangioda.net",
                Alias = "a.gioda",
                Biografia = "Vacia"
            };
            context.AddRange(usuario, usuario2, usuario3);
        }
        
        await context.SaveChangesAsync();
    }
}