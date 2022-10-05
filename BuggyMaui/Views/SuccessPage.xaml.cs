using BuggyMaui.Models;
using BuggyMaui.ViewModels;
using Microsoft.Extensions.Logging;

namespace BuggyMaui.Views;

public partial class SuccessPage : ContentPage
{
	private ILogger<SuccessPage> _logger;

	public SuccessPage(SuccessViewModel vm, ILogger<SuccessPage> logger)
	{
		BindingContext = vm;

		_logger = logger;

		InitializeComponent();

        _logger.LogInformation("constructor initialized");
    }

	private async void Button_Clicked(object sender, EventArgs e)
	{
		_logger.LogInformation("Going back to search page");

		await Shell.Current.Navigation.PopToRootAsync();
	}
}