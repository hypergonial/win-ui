using System.Windows;
using System.Windows.Controls;
using WPFView.ViewModel;


namespace WPFView;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        Board board = new();
        KeyDown += board.ProcessKeyInput;
        DataContext = board;

        int tileIndex = 0;
        foreach (var item in Tiles.Children)
        {
            if (item is not Button) continue;

            var button = (Button)item;

            if (!button.Name.StartsWith("Tile")) continue;

            button.DataContext = board.Tiles[tileIndex];
            tileIndex += 1;
        }
    }
}
