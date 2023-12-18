using Persistence;
using Model;

namespace View;

public partial class LoadDialog : Form
{
    internal BoardForm? parent;
    public LoadDialog()
    {
        InitializeComponent();
        string[] saves = Serde.GetSaves();

        if (saves.Length == 0)
        {
            MessageBox.Show("No saved games found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Close();
            return;
        }

        foreach (string save in saves)
        {
            Button button = new()
            {
                Width = 160,
                Height = 50,
                Text = save,
                Anchor = AnchorStyles.None
            };
            button.Margin = new Padding((loadLayout.Width - button.Width) / 2, button.Margin.Top, 0, 0);
            button.Click += LoadGame;
            button.MouseDown += DeleteGame;
            loadLayout.Controls.Add(button);
        }
    }
    public void LoadGame(object? sender, EventArgs e)
    {
        if (sender is not Button)
        {
            MessageBox.Show("Sender is invalid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        Button button = (Button)sender;
        try
        {
            Game game = Serde.Load(button.Text) ?? throw new NullReferenceException("Deserialization failed");
            parent?.ReplaceModel(game);

            // Display dialog confirming load
            MessageBox.Show($"Game loaded: \"{button.Text}\"", "Loaded", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Failed to load saved game: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
    }

    public void DeleteGame(object? sender, MouseEventArgs e)
    {
        if (e.Button != MouseButtons.Right)
            return;

        if (sender is not Button)
        {
            MessageBox.Show("Sender is invalid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        Button button = (Button)sender;

        if (MessageBox.Show($"Are you sure you want to delete the save \"{button.Text}\"?", "Delete Save", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            return;

        try
        {
            Serde.Delete(button.Text);
            loadLayout.Controls.Remove(button);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Failed to delete saved game: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (loadLayout.Controls.Count == 0)
            Close();
    }

}
