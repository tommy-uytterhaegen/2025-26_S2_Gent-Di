using HoGentMaui.ViewModels;

namespace HoGentMaui;

public partial class JokeDetailPage : ContentPage
{
	public JokeDetailPage(JokeDetailViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}