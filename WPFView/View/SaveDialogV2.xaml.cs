using Model;
using System.Windows;

namespace WPFView.View;

/// <summary>
/// Interaction logic for SaveDialogV2.xaml
/// </summary>
public partial class SaveDialogV2 : Window
{
    public SaveDialogV2(Game game)
    {
        InitializeComponent();
        var vm = new ViewModel.SaveDialog(game);
        DataContext = vm;
        vm.RequestClose += Close;
    }
}
