using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using ReversedTicTacToe.Logic;

namespace ReversedTicTacToe.Ui
{
    public class GameBoardForm : Form
    {
        private readonly TicTacToeGameSettings r_Settings;
        private GameManager m_GameManager;
        private List<GameCellButton> m_ListOfButtons;
        private bool m_Player1TurnToPlay = true;
        private const int k_Space = 8;
        private const int k_ButtonHeight = 50;
        private const int k_ButtonWeight = 60;
        private const int k_Second = 1000;
        private const string k_Replay = "Would you like to play another round?";
        private const string k_GameOverTieTitle = "A Tie";
        private const string k_GameOverWinTitle = "A Win";
        private const string k_TieMessage = "Tie!";
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label player1Label;
        private Label Player2Lable;

        public GameBoardForm(TicTacToeGameSettings i_GameSettings)
        {
            r_Settings = i_GameSettings;
            m_GameManager = new GameManager(i_GameSettings);
            m_ListOfButtons = new List<GameCellButton>();
            InitializeComponent();
            generateUserInterfaceBoard();
        }

        

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.player1Label = new System.Windows.Forms.Label();
            this.Player2Lable = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(88, 335);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 15);
            this.label1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(217, 335);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 15);
            this.label2.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(94, 332);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 20);
            this.label3.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(223, 332);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 20);
            this.label4.TabIndex = 3;
            // 
            // player1Label
            // 
            this.player1Label.AutoSize = true;
            this.player1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.player1Label.Location = new System.Drawing.Point(94, 330);
            this.player1Label.Name = "player1Label";
            this.player1Label.Size = new System.Drawing.Size(41, 13);
            this.player1Label.TabIndex = 4;
            this.player1Label.Text = "label5";
            // 
            // Player2Lable
            // 
            this.Player2Lable.AutoSize = true;
            this.Player2Lable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.Player2Lable.Location = new System.Drawing.Point(244, 330);
            this.Player2Lable.Name = "Player2Lable";
            this.Player2Lable.Size = new System.Drawing.Size(35, 13);
            this.Player2Lable.TabIndex = 5;
            this.Player2Lable.Text = "label6";
            // 
            // GameBoardForm
            // 
            this.ClientSize = new System.Drawing.Size(399, 364);
            this.Controls.Add(this.Player2Lable);
            this.Controls.Add(this.player1Label);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameBoardForm";
            this.Text = "TicTacToeMisere";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void generateUserInterfaceBoard()
        {
            int boardSize = r_Settings.BoardSize;
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    GameCellButton cellButton = new GameCellButton(j, i);
                    cellButton.Location = new Point(i * (k_ButtonWeight + k_Space) + k_Space, j * (k_ButtonHeight+ k_Space) + k_Space);
                    cellButton.Click += cellButton_Click;
                    m_ListOfButtons.Add(cellButton);
                    Controls.Add(cellButton);

                }
            }
            int formWidth = boardSize * (k_ButtonWeight + k_Space) + k_Space;
            int formHeight = boardSize * (k_ButtonHeight + k_Space) + 4 * k_Space;
            initFormSize(formWidth, formHeight);
            initFormPlayersLabels(formWidth, formHeight);
        }

        private void initFormPlayersLabels(int i_FormWidth, int i_FormHeight)
        {
            int player1LabelWidth = 20 * i_FormWidth / 100;
            int player2LabelWidth = 58 * i_FormHeight / 100;
            int labelsHeight = i_FormHeight - 3 * k_Space;
            player1Label.Location = new System.Drawing.Point(player1LabelWidth, labelsHeight);
            Player2Lable.Location = new System.Drawing.Point(player2LabelWidth, labelsHeight);
            player1Label.Text = r_Settings.Player1Name + ": " + "0";
            Player2Lable.Text = r_Settings.Player2Name + ": " + "0";
        }

        private void initFormSize(int i_FormWidth, int i_FormHeight)
        {
            this.Size = new Size(i_FormWidth, i_FormHeight);
            ClientSize = new Size(i_FormWidth, i_FormHeight);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void cellButton_Click(object sender, EventArgs e)
        {
            bool isADraw = false;
            bool currentPlayerLost = false;
            GameCellButton buttonClicked = sender as GameCellButton;
            if (r_Settings.GameAgainstComputer)
            {
                humanPlaying(buttonClicked , ref isADraw , ref currentPlayerLost);
                drawOrLostOperations(isADraw, currentPlayerLost);
                updateLabelsAfterTurnTaken();
                if (!isADraw && !currentPlayerLost)
                {
                    computerPlaying(ref isADraw, ref currentPlayerLost);
                    drawOrLostOperations(isADraw, currentPlayerLost);
                    updateLabelsAfterTurnTaken();
                }
            }
            else
            {
                humanPlaying(buttonClicked, ref isADraw, ref currentPlayerLost);
                drawOrLostOperations(isADraw, currentPlayerLost);
                updateLabelsAfterTurnTaken();
            }
        }

        private void computerPlaying(ref bool io_isADraw, ref bool io_currentPlayerLost)
        {
            Update();
            Thread.Sleep(k_Second);
            computerTurn();
            io_isADraw = m_GameManager.CheckDraw();
            io_currentPlayerLost = m_GameManager.HasCurrentPlayerLost(m_Player1TurnToPlay);
        }

        private void humanPlaying(GameCellButton i_buttonClicked, ref bool io_isADraw, ref bool io_currentPlayerLost)
        {
            updateCellSignAndDisableCell(i_buttonClicked);
            m_GameManager.TakeTurn(m_Player1TurnToPlay, i_buttonClicked.Row, i_buttonClicked.Col);
            io_isADraw = m_GameManager.CheckDraw();
            io_currentPlayerLost = m_GameManager.HasCurrentPlayerLost(m_Player1TurnToPlay);
        }

        private void switchTurn()
        {
            m_Player1TurnToPlay = !m_Player1TurnToPlay;
        }

        private void drawOrLostOperations(bool i_isADraw, bool i_currentPlayerLost)
        {
            if (i_currentPlayerLost)
            {
                handelGameLost();
                if (DialogResult == DialogResult.Yes)
                {
                    replayAfterLost();
                }
                else if(DialogResult == DialogResult.No)
                {
                    Application.Exit();
                }
            }
            else if (i_isADraw)
            {

                handelGameDraw();
                if (DialogResult == DialogResult.Yes)
                {
                    replayAfterDraw();
                }
                else if (DialogResult == DialogResult.No)
                {
                    Application.Exit();
                }
            }
            else
            {
               switchTurn();
            }

        }

        private void replayAfterLost()
        {
            m_GameManager.RestartGameLogic();
            restartGameForm();
        }

        private void restartGameForm()
        {
            m_ListOfButtons.Clear();
            foreach (var CellButton in this.Controls.OfType<GameCellButton>())
            {
                CellButton.Enabled = true;
                CellButton.Text = "";
                m_ListOfButtons.Add(CellButton);
            }
            m_Player1TurnToPlay = true;

        }

        private void replayAfterDraw()
        {
            m_GameManager.RestartGameLogic();
            restartGameForm();
        }

        private void handelGameLost()
        {
            DialogResult = MessageBox.Show(setWinnerTitle(), k_GameOverWinTitle, MessageBoxButtons.YesNo);
        }

        private string setWinnerTitle()
        {
            string winnerMessage;
            string winnerName = m_Player1TurnToPlay ? r_Settings.Player2Name : r_Settings.Player1Name;
            winnerMessage = $@"The winner is {winnerName}!";
            string resultString = string.Format($@"{winnerMessage}
{k_Replay}");

            return resultString;
        }

        private void handelGameDraw()
        {
            DialogResult = MessageBox.Show(setDraw(), k_GameOverTieTitle, MessageBoxButtons.YesNo);
        }

        private string setDraw()
        {
            string resultString = string.Format($@"{k_TieMessage}
{k_Replay}");

            return resultString;
        }

 
        private void computerTurn()
        {
            Tuple<int, int> computerChoiceFromLogic = m_GameManager.ComputerTakeTurn();
            GameCellButton buttonClickedByCoumputer = getTheReleventButton(computerChoiceFromLogic);
            updateCellSignAndDisableCell(buttonClickedByCoumputer);
        }

        private GameCellButton getTheReleventButton(Tuple<int, int> i_ComputerChoiceFromLogic)
        {
            GameCellButton pcButton = null;
            foreach (GameCellButton unPressedButton in m_ListOfButtons)
            {
                bool ButtonMatch = (unPressedButton.Row == i_ComputerChoiceFromLogic.Item1) && (unPressedButton.Col == i_ComputerChoiceFromLogic.Item2);
                if (ButtonMatch)
                {
                    pcButton = unPressedButton;
                    break;
                }
            }

            return pcButton;
        }

        private void updateCellSignAndDisableCell(GameCellButton io_Button)
        {
            io_Button.Text = m_Player1TurnToPlay ? "X" : "O";
            io_Button.Enabled = false;
            m_ListOfButtons.Remove(io_Button);
        }

        private void updateLabelsAfterTurnTaken()
        {
            int[] playersScores = m_GameManager.GetScores();
            if (m_Player1TurnToPlay)
            {
                player1Label.Text = r_Settings.Player1Name + " :" + playersScores[0].ToString();
                Player2Lable.Text = r_Settings.Player2Name + " :" + playersScores[1].ToString();
                player1Label.Font = new Font(Label.DefaultFont, FontStyle.Bold);
                Player2Lable.Font = new Font(Label.DefaultFont, FontStyle.Regular);
            }
            else
            {
                player1Label.Text = r_Settings.Player1Name + " :" + playersScores[0].ToString();
                Player2Lable.Text = r_Settings.Player2Name + " :" + playersScores[1].ToString();
                player1Label.Font = new Font(Label.DefaultFont, FontStyle.Regular);
                Player2Lable.Font = new Font(Label.DefaultFont, FontStyle.Bold);
            }
        }
    }

}