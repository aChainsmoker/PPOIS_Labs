using TrainScheduler.ViewModel;

namespace TrainScheduler;

public partial class FindWindow : Window
{
    public FindWindow(FindWindowViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

}