using Model;
using Persistence;
using System.Windows.Input;
using System.Windows;
using System.Collections.ObjectModel;

namespace WPFView.ViewModel;

public sealed class LoadButton
{
    private DelegateCommand? _command;
    public ICommand LoadCommand { get => _command ??= new DelegateCommand(_ => Click?.Invoke(this));}

    private DelegateCommand? _deleteCommand;
    public ICommand DeleteCommand { get => _deleteCommand ??= new DelegateCommand(_ => Delete?.Invoke(this)); }

    public string Content { get; }

    public event Action<LoadButton>? Click;

    public event Action<LoadButton>? Delete;

    public LoadButton(string filename)
    {
        Content = filename;
    }
}

public sealed class LoadDialog
{
    private readonly Board parent;

    public event Action? RequestClose;

    public ObservableCollection<LoadButton> Buttons { get; } = new();

    public LoadDialog(Board parent)
    {
        string[] saves = Serde.GetSaves();
        this.parent = parent;

        if (saves.Length == 0)
        {
            MessageBox.Show("No saved games found!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            RequestClose?.Invoke();
            return;
        }

        foreach (string save in saves)
        {
            LoadButton button = new(save);
            button.Click += LoadGame;
            button.Delete += DeleteGame;
            Buttons.Add(button);
        }
    }
    public void LoadGame(LoadButton button)
    {
        try
        {
            Game game = Serde.Load(button.Content) ?? throw new NullReferenceException("Deserialization failed");
            parent?.ReplaceModel(game);

            // Display dialog confirming load
            MessageBox.Show($"Game loaded: \"{button.Content}\"", "Loaded", MessageBoxButton.OK, MessageBoxImage.Information);

            RequestClose?.Invoke();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Failed to load saved game: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }
    }

    public void DeleteGame(LoadButton button)
    {
        if (MessageBox.Show($"Are you sure you want to delete the save \"{button.Content}\"?", "Delete Save", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            return;

        try
        {
            Serde.Delete(button.Content);
            Buttons.Remove(button);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Failed to delete saved game: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        if (Buttons.Count == 0)
            RequestClose?.Invoke();
    }

}
