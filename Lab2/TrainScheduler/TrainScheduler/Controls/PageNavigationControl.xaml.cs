using TrainScheduler.ViewModel;

namespace TrainScheduler.Controls;

public partial class PageNavigationControl : ContentView
{
    public static readonly BindableProperty ViewModelProperty =
        BindableProperty.Create(nameof(ViewModel), typeof(TrainListViewModel), typeof(PageNavigationControl));

    public TrainListViewModel ViewModel
    {
        get => (TrainListViewModel)GetValue(ViewModelProperty);
        set => SetValue(ViewModelProperty, value);
    }

    public PageNavigationControl()
	{
		InitializeComponent();
	}
}