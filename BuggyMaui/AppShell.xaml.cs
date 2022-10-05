using BuggyMaui.Views;

namespace BuggyMaui;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(ResultsPage), typeof(ResultsPage));
        Routing.RegisterRoute(nameof(ReviewPage), typeof(ReviewPage));
        Routing.RegisterRoute(nameof(SuccessPage), typeof(SuccessPage));
    }
}
