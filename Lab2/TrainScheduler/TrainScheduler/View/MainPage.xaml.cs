using TrainScheduler.ViewModel;

namespace TrainScheduler;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        BindingContext = new MainPageViewModel();
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        foreach (var window in Application.Current.Windows.ToList())
        {
            if (window != Application.Current.MainPage.GetParentWindow())
            {
                Application.Current.CloseWindow(window);
            }
        }
        Application.Current.Quit();
    }
}
