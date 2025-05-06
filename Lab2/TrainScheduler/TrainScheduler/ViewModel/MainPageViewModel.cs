using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using System.Xml;
using TrainScheduler.DatabaseControl;
using TrainScheduler.Model;
using TrainScheduler.Utilities;

namespace TrainScheduler.ViewModel;

public partial class MainPageViewModel : ObservableObject
{
    public TrainListViewModel TrainListViewModel { get; }

    public MainPageViewModel()
    {
        TrainListViewModel = new TrainListViewModel("trains.db");
    }

    [RelayCommand]
    private void OpenAddDialogueWindow()
    {
        var addWindowViewModel = new AddWindowViewModel(TrainListViewModel);
    }

    [RelayCommand]
    private void OpenFindDialogueWindow()
    {
        var findWindowViewModel = new FindWindowViewModel(TrainListViewModel);
    }

    [RelayCommand]
    private void OpenDeleteDialogueWindow()
    {
        var deleteWindowViewModel = new DeleteWindowViewModel(TrainListViewModel);
    }

    [RelayCommand]
    private void LoadToXML()
    {
        try
        {
            XmlParser.LoadToXML(TrainListViewModel.Trains.ToList());
        }
        catch (XmlException ex)
        {
            Application.Current?.Windows[0].Page?.DisplayAlert("Error!",
                "Something went wrong during file saving process. Please try again.", "Close");
            return;
        }
    }

    [RelayCommand]
    private async void LoadFromXML()
    {
        try
        {
            List<TrainModel> trains = await XmlParser.LoadFromXML();
            if (trains == null) return;
            TrainListViewModel.ClearTracking();
            TrainListViewModel.Trains.AddRange(trains);
            TrainListViewModel.SaveDbChanges();
        }
        catch (XmlException ex)
        {
            Application.Current?.Windows[0].Page?.DisplayAlert("Error!",
                "Something went wrong during file loading process. Please try again.", "Close");
            return;
        }
        TrainListViewModel.UpdateTrainList();
    }
}