using System.Collections;

namespace TrainScheduler.Controls;

public partial class CustomTrainScrollView : ContentView
{

    public static readonly BindableProperty ItemsSourceProperty =
        BindableProperty.Create(nameof(ItemsSource), typeof(IEnumerable), typeof(CustomTrainScrollView));

    public IEnumerable ItemsSource
    {
        get => (IEnumerable)GetValue(ItemsSourceProperty);
        set => SetValue(ItemsSourceProperty, value);
    }

    public CustomTrainScrollView()
    {
        InitializeComponent();
    }
}