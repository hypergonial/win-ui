using System.Windows;
using WPFView.ViewModel;

namespace WPFView.View;

/// <summary>
/// Interaction logic for LoadDialogV2.xaml
/// </summary>
public partial class LoadDialogV2 : Window
{
    public LoadDialogV2(Board parent)
    {
        InitializeComponent();
        var vm = new LoadDialog(parent);
        DataContext = vm;
        vm.RequestClose += Close;
    }
}
