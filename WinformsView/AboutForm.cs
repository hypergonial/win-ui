namespace View;

public partial class AboutForm : Form
{
    private int current = 0;
    internal BoardForm? parent;
    public AboutForm()
    {
        InitializeComponent();
        logoTimer.Start();
    }

    /// <summary>
    /// Called by the timer to update the logo
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void UpdateLogo(object sender, EventArgs e)
    {

        current = (current + 1) % 6;
        logo.State = (TileState)current;
        logo.Update();
        if (logoTimer.Interval > 400)
        {
            logoTimer.Interval -= 100;
        }
    }
}
