using HoGentMaui.ViewModels;

namespace HoGentMaui;

public partial class JokeListPage : ContentPage
{
	public JokeListPage(JokeListViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
    }
}