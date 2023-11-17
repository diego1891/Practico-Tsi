using CommunityToolkit.Mvvm.ComponentModel;
using PracticoMobile.Models.Backend;
using PracticoMobile.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticoMobile.ViewModel;

public partial class UsuarioDetailViewModel : ViewModelGlobal
{
    [ObservableProperty]
    private UsuarioResponse usuario;

    private readonly UsuarioService _usuarioService;

    private readonly INavegacionService _navegacionService;

    public UsuarioDetailViewModel(UsuarioService usuarioService, INavegacionService navegacionService)
    {
        _usuarioService = usuarioService;
        _navegacionService = navegacionService;

    }
    
    public async Task LoadDataAsync(int usuarioId)
    {
        try
        {
            Usuario = await _usuarioService.GetUsuarioById(usuarioId);
        }
        catch (Exception e)
        {
            await Application.Current.MainPage.DisplayAlert("Error", e.Message, "Aceptar");
        }
        finally
        {
            IsBusy = false;
        }
    }

    public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        var id = int.Parse(query["id"].ToString());
        await LoadDataAsync(id);

    }

}
