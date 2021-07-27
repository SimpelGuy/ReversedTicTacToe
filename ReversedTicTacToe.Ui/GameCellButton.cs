using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace ReversedTicTacToe.Ui
{
    class GameCellButton : Button
    {
        private const int k_ButtonHeight = 50;
        private const int k_ButtonWeight = 60;
        private readonly int r_Row;
        private readonly int r_Col; 

        public delegate void CellSelectionEventHandler(GameCellButton cellButton);
        public event CellSelectionEventHandler CellSelection;

        public GameCellButton(int i_Row ,int i_Col)
        {
            r_Row = i_Row;
            r_Col = i_Col;
            Width = k_ButtonWeight;
            Height = k_ButtonHeight;
            Enabled = true;
        }

        public int Row
        {
            get
            {
                return r_Row;
            }
        }
        public int Col
        {
            get
            {
                return r_Col;
            }
        }
    }
}
