using CommunityToolkit.Mvvm.ComponentModel;
using PracticoMobile.Models.Backend;
using PracticoMobile.Services;
using PracticoMobile.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PracticoMobile.ViewModel;

public partial class UsuarioViewModel : ViewModelGlobal
{
    [ObservableProperty]
    ObservableCollection<UsuarioResponse> usuarios;

    [ObservableProperty]
    private UsuarioResponse usuarioSeleccionado;

    [ObservableProperty]
    private string searchText;

    private readonly UsuarioService _usuarioService;

    private readonly INavegacionService _navegacionService;

    public UsuarioViewModel(UsuarioService usuarioService, INavegacionService navegacionService)
    {
        _usuarioService = usuarioService;
        _navegacionService = navegacionService;
        PropertyChanged += UsuarioViewModel_PropertyChanged;

    }

    private async void UsuarioViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(UsuarioSeleccionado))
        {
            var uri = $"{nameof(UsuarioDetailPage)}?id={UsuarioSeleccionado.Id}";
            await _navegacionService.GoToAsync(uri);
        }
    }

    public ICommand EjecutarBusqueda => new Command(async () =>
    {
        var users = await _usuarioService.GetBusquedaUsuarios(SearchText);
        Usuarios = new ObservableCollection<UsuarioResponse>(users);
    });
}
