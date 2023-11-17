using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticoMobile.Models.Backend;

public class UsuarioResponse
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Alias { get; set; }
    public string Email { get; set; }
    public string Biografia { get; set; }

    public UsuarioResponse(string nombre, string alias, string email, string biografia)
    {
        Nombre = nombre;
        Alias = alias;
        Email = email;
        Biografia = biografia;
    }
}
