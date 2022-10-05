using MetroLog;
using Microsoft.Extensions.Logging;
using BuggyMaui.Models;

namespace BuggyMaui.Views;

public partial class MainPage : ContentPage
{
	private readonly ILogger<MainPage> _logger;

	public MainPage(ILogger<MainPage> logger)
	{
		_logger = logger;

		InitializeComponent();

		_logger.LogInformation("constructor initialized");
	}

	private async void Button_Clicked(object sender, EventArgs e)
	{
		_logger.LogInformation("button clicked, getting person entry fields");

		string fName = FirstNameEntry.Text;
		string lName = LastNameEntry.Text;

		if (!string.IsNullOrWhiteSpace(fName) || !string.IsNullOrWhiteSpace(lName))
		{
			Person person = new()
			{
				FirstName = fName,
				LastName = lName
			};

			await Shell.Current.GoToAsync($"{nameof(ResultsPage)}?",
				new Dictionary<string, object>
				{
					["SearchPerson"] = person
				});
		}
		else
			await Shell.Current.GoToAsync(nameof(ResultsPage));
	}
}