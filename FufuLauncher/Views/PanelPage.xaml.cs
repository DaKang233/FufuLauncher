using FufuLauncher.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;

namespace FufuLauncher.Views;

public sealed partial class PanelPage : Page
{
    public ControlPanelModel ViewModel
    {
        get;
    }

    public MainViewModel MainViewModel
    {
        get;
    }

    public PanelPage()
    {
        ViewModel = App.GetService<ControlPanelModel>();
        MainViewModel = App.GetService<MainViewModel>();
        DataContext = ViewModel;
        InitializeComponent();
    }

    private void ContentScrollViewer_Tapped(object sender, TappedRoutedEventArgs e)
    {
        ContentScrollViewer.Focus(FocusState.Programmatic);
    }

    private void NumberBox_GotFocus(object sender, RoutedEventArgs e)
    {
    }

    private void NumberBox_LostFocus(object sender, RoutedEventArgs e)
    {
    }

    private void NavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
    {
        if (args.SelectedItem is NavigationViewItem selectedItem)
        {
            string tag = selectedItem.Tag?.ToString();

            switch (tag)
            {
                case "BasicSettings":
                    BasicSettingsPage.Visibility = Visibility.Visible;
                    AdvancedSettingsPage.Visibility = Visibility.Collapsed;
                    break;

                case "AdvancedSettings":
                    BasicSettingsPage.Visibility = Visibility.Collapsed;
                    AdvancedSettingsPage.Visibility = Visibility.Visible;
                    break;
            }
        }
    }
}