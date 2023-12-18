using Persistence;

namespace View
{
    public partial class SaveDialog : Form
    {
        internal BoardForm? parent;

        public SaveDialog()
        {
            InitializeComponent();
        }

        private void Save(object sender, EventArgs e)
        {
            if (parent == null)
            {
                MessageBox.Show("Parent not set");
                return;
            }

            string saveName = this.saveName.Text;

            if (saveName == "")
            {
                MessageBox.Show("Please enter a save name!", "Name Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Serde.GetSaves().Contains(saveName))
            {
                // Ask the user if they want to overwrite the file
                DialogResult result = MessageBox.Show($"Save with name \"{saveName}\" already exists. Overwrite?", "Save Exists", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                {
                    Close();
                    return;
                }
            }

            try
            {
                Serde.Save(parent.game, saveName);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to save game: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Display dialog confirming save
            MessageBox.Show($"Game saved as \"{saveName}\"", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Close();
        }

        private void Cancel(object sender, EventArgs e)
        {
            Close();
        }
    }
}
