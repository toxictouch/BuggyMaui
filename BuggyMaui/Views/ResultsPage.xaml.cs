using BuggyMaui.Models;
using BuggyMaui.ViewModels;
using Microsoft.Extensions.Logging;

namespace BuggyMaui.Views;

public partial class ResultsPage : ContentPage
{
	private ILogger<ResultsPage> _logger;

	public ResultsPage(ResultsViewModel vm, ILogger<ResultsPage> logger)
	{
		BindingContext = vm;

		_logger = logger;

		InitializeComponent();

		_logger.LogInformation("constructor initialized");
	}

	private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
        _logger.LogInformation("checking if selection is valid");

        if (e.CurrentSelection != null)
		{
            _logger.LogInformation("selection VALID. creating person object from it and redirectign to review");

			Person person = PeopleCollectionView.SelectedItem as Person;

            //Person person = e.CurrentSelection.FirstOrDefault() as Person;

			await Shell.Current.GoToAsync($"{nameof(ReviewPage)}?", 
				new Dictionary<string, object>
				{
					["Selection"] = person
				});
		}
	}

	private async void Button_Clicked(object sender, EventArgs e)
	{
		_logger.LogInformation("Go back button clicked");

		await Shell.Current.GoToAsync("..");
	}
}