using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Practico_Tsi.Models;

namespace Practico_Tsi.Services.Usuarios;

public interface IUsuarioService
{
    bool AgregarUsuario(Usuario usuario);
    bool ModificarUsuario(int id, Usuario usuario);
    bool BorrarUsuario(int id);
    Usuario ObtenerPorId(int id);
    UsuarioList listarUsuarios(string term ="",bool paginacion = false, int paginaActual = 0);
    Usuario BuscarPorAlias(string alias);

}
