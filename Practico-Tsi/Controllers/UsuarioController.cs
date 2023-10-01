using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Practico_Tsi.Models;
using Practico_Tsi.Services.Usuarios;

namespace Practico_Tsi.Controllers;

//[Route("[controller]")]
public class UsuarioController : Controller
{
    private readonly IUsuarioService usuarioService;

    public UsuarioController(IUsuarioService usuarioServiceAux)
    {
        usuarioService = usuarioServiceAux;
    }

    public IActionResult Index(string term = "", int paginaActual = 1)
    {
        var usuarios = usuarioService.listarUsuarios(term, true, paginaActual);
        return View(usuarios);
    }

    [HttpPost]
    public IActionResult Agregar(Usuario usuario)
    {
        if(!ModelState.IsValid)
        {
            return View(usuario);
        }
        var resultado = usuarioService.AgregarUsuario(usuario);
        if(resultado)
        {
            TempData["msg"] = "Se agrego el usuario";
            return RedirectToAction(nameof(Agregar));
        }
        TempData["msg"] = "Error agregando al usuario";
        return View(usuario);
    }
    public IActionResult Agregar()
    {
        return View();
    }


    [HttpPost]
    public IActionResult Modificar(Usuario usuario)
    {
        if(!ModelState.IsValid)
        {
            return View(usuario);
        }
        var resultado = usuarioService.ModificarUsuario(usuario.Id, usuario);
        if(resultado)
        {
            TempData["msg"] = "Se modificó el usuario";
            return RedirectToAction(nameof(Modificar));
        }
        TempData["msg"] = "Error modificando al usuario";
        return View(usuario);
    }

    public IActionResult Modificar(int id){
        var usuario = usuarioService.ObtenerPorId(id);

        return View(usuario);
    }

    [HttpPost]
public IActionResult BuscarPorAlias(Usuario usuario)
{
    if (!ModelState.IsValid)
    {
        return View(usuario);
    }

    var resultado = usuarioService.BuscarPorAlias(usuario.Alias);

    if (resultado != null)
    {
        TempData["msg"] = "Se encontró al usuario";
        return RedirectToAction(nameof(BuscarPorAlias), new { alias = usuario.Alias });
    }

    TempData["msg"] = "Error buscando al usuario";
    return View(usuario);
}

[HttpGet]
public IActionResult BuscarPorAlias(string alias)
{
    var usuario = usuarioService.BuscarPorAlias(alias);
    return View(usuario);
}
    public IActionResult Borrar(int id)
    {
        Console.WriteLine("HOLA entra al borrar");
        usuarioService.BorrarUsuario(id);
        return RedirectToAction(nameof(Index));
    }

}
