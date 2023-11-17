using Newtonsoft.Json;
using PracticoMobile.Models.Backend;
using System.Net.Http.Headers;
using PracticoMobile.Models.Config;
using Microsoft.Extensions.Configuration;

namespace PracticoMobile.Services;

public class UsuarioService
{
    private  HttpClient client;

    private Settings settings;

    public UsuarioService(HttpClient client, IConfiguration configuration)
    {
        this.client = client;
    }

    public async Task<UsuarioResponse> GetUsuarioById(int usuarioId)
    {
        var uri = $"http://10.0.2.2:5208/api/Usuarios/{usuarioId}";
        
        var resultado = await client.GetStringAsync(uri);

        return JsonConvert.DeserializeObject<UsuarioResponse>(resultado);
    }

    public async Task<List<UsuarioResponse>> GetBusquedaUsuarios(string alias)
    {
        var uri = $"http://10.0.2.2:5208/api/Usuarios/todos/{alias}";

        var resultado = await client.GetStringAsync(uri);

        return JsonConvert.DeserializeObject<List<UsuarioResponse>>(resultado);
    }
}
