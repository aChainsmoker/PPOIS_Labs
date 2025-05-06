using TrainScheduler.ViewModel;

namespace TrainScheduler;

public partial class AddWindow : Window
{
	public AddWindow(AddWindowViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}