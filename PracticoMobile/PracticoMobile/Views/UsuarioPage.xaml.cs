using PracticoMobile.ViewModel;

namespace PracticoMobile.Views;

public partial class UsuarioPage : ContentPage
{
	public UsuarioPage(UsuarioViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}