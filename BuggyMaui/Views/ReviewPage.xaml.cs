using BuggyMaui.ViewModels;
using Microsoft.Extensions.Logging;

namespace BuggyMaui.Views;

public partial class ReviewPage : ContentPage
{
	private ILogger<ReviewPage> _logger;

	public ReviewPage(ReviewViewModel vm, ILogger<ReviewPage> logger)
	{
		BindingContext = vm;

		_logger = logger;

		InitializeComponent();

		_logger.LogInformation("constructor initialized");
	}

	private async void GoBackButton_Clicked(object sender, EventArgs e)
	{
        _logger.LogInformation("Go back button clicked");

        await Shell.Current.GoToAsync("..");
    }

	private async void SubmitButton_Clicked(object sender, EventArgs e)
	{
		string message = "Changes saved successfully!";

		await Shell.Current.GoToAsync($"{nameof(SuccessPage)}?Message={message}");
	}
}