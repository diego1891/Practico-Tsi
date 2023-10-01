using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practico_Tsi.Models;

public class UsuarioList
{
    public IQueryable<Usuario>? ListaUsuarios { get; set; }

    public int TamañoPagina { get; set; }
    public int PaginaActual { get; set; }
    public int TotalPaginas { get; set; }
    public string? Term { get; set; }
}
