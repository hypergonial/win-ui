namespace MAUIView;

public partial class MainPage : ContentPage
{
    public MainPage(ViewModel.Board viewmodel)
    {
        InitializeComponent();

        BindingContext = viewmodel;

        ImageButton[] tiles = new ImageButton[24]
        {
            Tile0_0, Tile0_1, Tile0_2, Tile0_3, Tile0_4, Tile0_5, Tile0_6, Tile0_7,
            Tile1_0, Tile1_1, Tile1_2, Tile1_3, Tile1_4, Tile1_5, Tile1_6, Tile1_7,
            Tile2_0, Tile2_1, Tile2_2, Tile2_3, Tile2_4, Tile2_5, Tile2_6, Tile2_7,
        };

        for (int i = 0; i < 24; i++)
        {
            tiles[i].BindingContext = viewmodel.Tiles[i];
        }
    }

    protected override void OnSizeAllocated(double width, double height)
{
    base.OnSizeAllocated(width, height);
    if (width != height)
    {
        AmongUs.WidthRequest = Math.Min(width, height);
        AmongUs.HeightRequest = Math.Min(width, height);
    }
}

}
