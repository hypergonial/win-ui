using System.Windows;
using System.Windows.Input;
using Model;
using Persistence;

namespace WPFView.ViewModel;

public sealed class SaveDialog : Base
{
    private string _saveName = "";
    private readonly Game _game;
    public string SaveName { get => _saveName; set 
        {
            _saveName = value;
            OnPropertyChanged();
        }
    }

    public event Action? RequestClose;

    private DelegateCommand? _saveCommand;

    public ICommand SaveCommand
    {
        get => _saveCommand ??= new DelegateCommand(SaveGame);
    }

    private DelegateCommand? _cancelCommand;

    public ICommand CancelCommand
    {
        get => _cancelCommand ??= new DelegateCommand(_ => { RequestClose?.Invoke(); });
    }

    public SaveDialog(Game game)
    {
        _game = game;
    }

    public void SaveGame(object? _)
    {
        if (SaveName == "")
        {
            MessageBox.Show("Please enter a name for the save file", "Filename Missing", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        if (Serde.GetSaves().Contains(SaveName))
        {
            MessageBoxResult result = MessageBox.Show("A save with this name already exists. Are you sure you want to overwrite it?", "Save Exists", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.No)
                return;
        }

        Serde.Save(_game, SaveName);
        MessageBox.Show("Game saved!", "Game Saved", MessageBoxButton.OK, MessageBoxImage.Information);
        RequestClose?.Invoke();
    }
}
