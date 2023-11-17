using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Practico_Tsi.Models;
using Practico_Tsi.Services.Usuarios;

namespace PracticoApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuariosController : ControllerBase
{
    private readonly IUsuarioService _usuariosService;

    public UsuariosController(IUsuarioService usuarioService)
    {
        _usuariosService = usuarioService;
    }

    [HttpGet]
    public ActionResult<UsuarioList> ObtenerUsuarios()
    {
        return Ok(_usuariosService.GetAllUsuarios());
    }

    [HttpGet]
    [Route("todos/{busqueda}")]
    public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios(string busqueda){
        IEnumerable<Usuario> usuarios = await _usuariosService.GetUsuarios(busqueda);
        return Ok(usuarios);
    }

    [HttpGet("{id}")]
    public ActionResult<Usuario> Get(int id)
    {
        return Ok(_usuariosService.ObtenerPorId(id));
    }
    [HttpGet]
    [Route("ObtenerPorAlias/{alias}")]
    public ActionResult<Usuario> GetByAlias(string alias)
    {
        Console.WriteLine(_usuariosService.BuscarPorAlias(alias));
        return Ok (_usuariosService.BuscarPorAlias(alias));
    }

    [HttpPost]
    public ActionResult<Usuario> Post(Usuario usuario)
    {
        return Ok(_usuariosService.AgregarUsuario(usuario));
    }

    [HttpPut("{id}")]
    public ActionResult<Usuario> Put(int id, Usuario usuario)
    {
        return Ok(_usuariosService.ModificarUsuario(id, usuario));
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        _usuariosService.BorrarUsuario(id);
        return Ok();
    }


}
