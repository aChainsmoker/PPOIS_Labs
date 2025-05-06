using TrainScheduler.ViewModel;

namespace TrainScheduler;

public partial class DeleteWindow : Window
{
	public DeleteWindow(DeleteWindowViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}