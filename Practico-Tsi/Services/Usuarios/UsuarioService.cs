using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Practico_Tsi.Models;

namespace Practico_Tsi.Services.Usuarios;

public class UsuarioService : IUsuarioService
{
    //Inyección de la DbContext
    private readonly DatabaseContext database;
    

    public UsuarioService(DatabaseContext databaseAux)
    {
        database = databaseAux;
    }

    public bool AgregarUsuario(Usuario usuario)
    {
        try
        {
            database.Usuarios!.Add(usuario);
            database.SaveChanges();
            return true;
        }
        catch (Exception)
        {

            throw new Exception("Error agregando al Usuario");
        }
    }

    public bool ModificarUsuario(int id, Usuario usuario)
    {
        try
        {
            Usuario user = database.Usuarios!.Find(id)!;
            if (user is null)
            {
                throw new Exception("El usuario con id " + id + " no existe");
            }
            user.Nombre = usuario.Nombre;
            user.Alias = usuario.Alias;
            user.Email = usuario.Email;
            user.Biografia = usuario.Biografia;
            Console.WriteLine("Llegó aca a modificar");
            database.Usuarios.Update(user);
            database.SaveChanges();
            return true;

        }
        catch (Exception)
        {
            throw new Exception("Error a la hora de modificar al usuario");
        }
    }

    public bool BorrarUsuario(int id)
    {
        try
        {
            var aux = database.Usuarios!.Find(id)!;
            if (aux is null)
            {
                throw new Exception("No se encuentra el usuario con id: " + id);
            }
            database.Usuarios.Remove(aux);
            database.SaveChanges();
            return true;

        }
        catch (Exception)
        {
            throw new Exception("Ocurrió un error intentando eliminar al usuario");
        }
    }

    public Usuario ObtenerPorId(int id)
    {
        try
        {
            Usuario user = database.Usuarios!.Find(id)!;
            return user;

        }
        catch (Exception)
        {
            throw new Exception("Error en la búsqueda del Usuario");
        }

    }

    public List<Usuario> GetAllUsuarios()
    {
        var list = database.Usuarios.ToList();
        return list;
    }
    public UsuarioList listarUsuarios(string term = "", bool paginacion = false, int paginaActual = 0)
    {
        try
        {

            var data = new UsuarioList();
            var list = database.Usuarios.ToList();

            if (string.IsNullOrEmpty(term))
            {
                term = term.ToLower();
                list = list.Where(a => a.Alias.ToLower().StartsWith(term)).ToList(); //Aplicar un filtrado por Alias
            }

            if (paginacion)
            {
                int tamaño = 5;
                int cantidad = list.Count;
                int paginasTotales = (int)Math.Ceiling(cantidad / (Double)tamaño);
                list.Skip((paginaActual - 1) * tamaño).Take(tamaño).ToList();
                data.TamañoPagina = tamaño;
                data.PaginaActual = paginaActual;
                data.TotalPaginas = paginasTotales;
            }

            data.ListaUsuarios = list.AsQueryable();
            return data;
        }
        catch (SqlException exception)
        {
            Console.WriteLine($"Error de SQL: {exception.Number} - {exception.Message}");
            throw new Exception("Error sql");
        }
    }

    public Usuario BuscarPorAlias(string alias)
    {
        try
        {
            Usuario usuario = database.Usuarios.SingleOrDefault(u => u.Alias == alias)!;
            Console.WriteLine(usuario.Alias);
            return usuario;
        }
        catch(Exception)
        {
            throw new Exception("Error en la búsqueda por Alias del usuario");
        }

    }

    public async Task<IEnumerable<Usuario>> GetUsuarios(string busqueda)
    {
        var usuarios = from c in database.Usuarios!
                        where EF.Functions.Like(c.Alias!, $"%{busqueda}%")
                        select c;
        return await usuarios.ToListAsync();
    }
}
