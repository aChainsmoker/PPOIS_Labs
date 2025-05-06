using TrainScheduler.Model;

namespace TrainScheduler.Controls;

public partial class TreeView : ContentView
{
    public static readonly BindableProperty TrainsProperty =
            BindableProperty.Create(nameof(Trains), typeof(IEnumerable<TrainModel>), typeof(TreeView), default(IEnumerable<TrainModel>));

    public IEnumerable<TrainModel> Trains
    {
        get => (IEnumerable<TrainModel>)GetValue(TrainsProperty);
        set => SetValue(TrainsProperty, value);
    }

    public TreeView()
    {
        InitializeComponent();
    }
}