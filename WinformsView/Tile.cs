using Model;
using System.ComponentModel;

namespace View
{
    internal delegate void TileInputDelegate(Tile tile);

    internal enum TileState
    {
        EMPTY,
        EMPTY_SEL,
        WHITE,
        WHITE_SEL,
        BLACK,
        BLACK_SEL
    }

    internal sealed class Tile : PictureBox
    {
        public event TileInputDelegate? TileUpdate;
        private TileState state;
        private int square;
        private int index;

        [Description("The current square of the tile"), Category("Data"), DefaultValue(0)]
        public int Square
        {
            get => square;
            set => square = value;
        }

        [Description("The current index of the tile"), Category("Data"), DefaultValue(0)]
        public int Index
        {
            get => index;
            set => index = value;
        }

        [Description("The current state of the tile"), Category("Data"), DefaultValue(TileState.EMPTY)]
        public TileState State
        {
            get => state;
            set
            {
                state = value;
                Image = state switch
                {
                    TileState.EMPTY => WinformsView.Properties.Resources.empty,
                    TileState.EMPTY_SEL => WinformsView.Properties.Resources.empty_sel,
                    TileState.WHITE =>  WinformsView.Properties.Resources.white,
                    TileState.WHITE_SEL => WinformsView.Properties.Resources.white_sel,
                    TileState.BLACK => WinformsView.Properties.Resources.black,
                    TileState.BLACK_SEL => WinformsView.Properties.Resources.black_sel,
                    _ => throw new NotImplementedException(),
                };
            }
        }

        public void SelectTile()
        {
            State = State switch
            {
                TileState.EMPTY => TileState.EMPTY_SEL,
                TileState.WHITE => TileState.WHITE_SEL,
                TileState.BLACK => TileState.BLACK_SEL,
                TileState.EMPTY_SEL => TileState.EMPTY_SEL,
                TileState.WHITE_SEL => TileState.WHITE_SEL,
                TileState.BLACK_SEL => TileState.BLACK_SEL,
                _ => throw new NotImplementedException(),
            };
            Enabled = true;
        }

        public void DeselectTile()
        {
            State = State switch
            {
                TileState.EMPTY_SEL => TileState.EMPTY,
                TileState.WHITE_SEL => TileState.WHITE,
                TileState.BLACK_SEL => TileState.BLACK,
                TileState.BLACK => TileState.BLACK,
                TileState.WHITE => TileState.WHITE,
                TileState.EMPTY => TileState.EMPTY,
                _ => throw new NotImplementedException(),
            };
            Enabled = false;
        }

        public Pos Pos
        {
            get => new (square, index);
        }

        public Tile() : base() {}

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            TileUpdate?.Invoke(this);
        }
    }
}
