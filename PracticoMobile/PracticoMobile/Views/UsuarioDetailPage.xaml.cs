using PracticoMobile.ViewModel;

namespace PracticoMobile.Views;

public partial class UsuarioDetailPage : ContentPage
{
	public UsuarioDetailPage(UsuarioDetailViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}