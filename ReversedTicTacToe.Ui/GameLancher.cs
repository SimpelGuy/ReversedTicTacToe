using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace ReversedTicTacToe.Ui
{
    class GameLancher
    {
        private readonly GameSettingsForm r_SettingsForm;
        private GameBoardForm m_GameBoard;

        public GameLancher()
        {
            r_SettingsForm = new GameSettingsForm();
        }

        public void Start()
        {
            r_SettingsForm.ShowDialog();
            m_GameBoard = new GameBoardForm(r_SettingsForm.GameSettings);
            do
            {
                m_GameBoard.ShowDialog();
            } 
            while (m_GameBoard.DialogResult == DialogResult.Yes);
        }
    }
}
