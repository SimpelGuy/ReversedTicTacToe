using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ReversedTicTacToe.Logic;

namespace ReversedTicTacToe.Ui
{
    internal class GameSettingsForm : Form
    {

        // $G$ CSS-002 (-5) Bad member variable name (should be m_CamelCased)
        private TicTacToeGameSettings m_GameSettings;
        private Label PlayersLabel;
        private Label Player1TextBox;
        private Label BoardSizeLabel;
        private Label RowsLabel;
        private TextBox textBox1;
        private TextBox Player2TextBox;
        private CheckBox checkBoxAgainstComputer;
        private Button StartButton;
        private NumericUpDown numericUpDownRows;
        private NumericUpDown numericUpDownCol;
        private Label ColLabel;
        private const string k_MissingFieldsMessage = "Some fields are missing!";
        private const string k_ErrorTitle = "Error";

        public GameSettingsForm()
        {
            InitializeComponent();
        }

        public TicTacToeGameSettings GameSettings
        {
            get
            {
                return m_GameSettings;
            }
        }

        private void InitializeComponent()
        {
            this.PlayersLabel = new System.Windows.Forms.Label();
            this.Player1TextBox = new System.Windows.Forms.Label();
            this.BoardSizeLabel = new System.Windows.Forms.Label();
            this.RowsLabel = new System.Windows.Forms.Label();
            this.ColLabel = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Player2TextBox = new System.Windows.Forms.TextBox();
            this.checkBoxAgainstComputer = new System.Windows.Forms.CheckBox();
            this.StartButton = new System.Windows.Forms.Button();
            this.numericUpDownRows = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownCol = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCol)).BeginInit();
            this.SuspendLayout();
            // 
            // PlayersLabel
            // 
            this.PlayersLabel.AutoSize = true;
            this.PlayersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.PlayersLabel.Location = new System.Drawing.Point(26, 19);
            this.PlayersLabel.Name = "PlayersLabel";
            this.PlayersLabel.Size = new System.Drawing.Size(53, 15);
            this.PlayersLabel.TabIndex = 0;
            this.PlayersLabel.Text = "Players :";
            // 
            // Player1TextBox
            // 
            this.Player1TextBox.AutoSize = true;
            this.Player1TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Player1TextBox.Location = new System.Drawing.Point(59, 57);
            this.Player1TextBox.Name = "Player1TextBox";
            this.Player1TextBox.Size = new System.Drawing.Size(60, 15);
            this.Player1TextBox.TabIndex = 1;
            this.Player1TextBox.Text = "Player 1 : ";
            // 
            // BoardSizeLabel
            // 
            this.BoardSizeLabel.AutoSize = true;
            this.BoardSizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.BoardSizeLabel.Location = new System.Drawing.Point(26, 161);
            this.BoardSizeLabel.Name = "BoardSizeLabel";
            this.BoardSizeLabel.Size = new System.Drawing.Size(73, 15);
            this.BoardSizeLabel.TabIndex = 2;
            this.BoardSizeLabel.Text = "Board Size :";
            // 
            // RowsLabel
            // 
            this.RowsLabel.AutoSize = true;
            this.RowsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.RowsLabel.Location = new System.Drawing.Point(48, 217);
            this.RowsLabel.Name = "RowsLabel";
            this.RowsLabel.Size = new System.Drawing.Size(47, 15);
            this.RowsLabel.TabIndex = 3;
            this.RowsLabel.Text = "Rows : ";
            // 
            // ColLabel
            // 
            this.ColLabel.AutoSize = true;
            this.ColLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.ColLabel.Location = new System.Drawing.Point(209, 217);
            this.ColLabel.Name = "ColLabel";
            this.ColLabel.Size = new System.Drawing.Size(40, 15);
            this.ColLabel.TabIndex = 4;
            this.ColLabel.Text = "Cols : ";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(180, 56);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(162, 20);
            this.textBox1.TabIndex = 5;
            // 
            // Player2TextBox
            // 
            this.Player2TextBox.Enabled = false;
            this.Player2TextBox.Location = new System.Drawing.Point(180, 101);
            this.Player2TextBox.Name = "Player2TextBox";
            this.Player2TextBox.Size = new System.Drawing.Size(162, 20);
            this.Player2TextBox.TabIndex = 6;
            this.Player2TextBox.Text = "[Computer]";
            // 
            // checkBoxAgainstComputer
            // 
            this.checkBoxAgainstComputer.AutoSize = true;
            this.checkBoxAgainstComputer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.checkBoxAgainstComputer.Location = new System.Drawing.Point(62, 101);
            this.checkBoxAgainstComputer.Name = "checkBoxAgainstComputer";
            this.checkBoxAgainstComputer.Size = new System.Drawing.Size(76, 19);
            this.checkBoxAgainstComputer.TabIndex = 7;
            this.checkBoxAgainstComputer.Text = "Player 2 :";
            this.checkBoxAgainstComputer.UseVisualStyleBackColor = true;
            this.checkBoxAgainstComputer.CheckedChanged += new System.EventHandler(this.checkBoxAgainstComputer_CheckedChanged);
            // 
            // StartButton
            // 
            this.StartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.StartButton.Location = new System.Drawing.Point(36, 276);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(306, 32);
            this.StartButton.TabIndex = 8;
            this.StartButton.Text = "Start!";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // numericUpDownRows
            // 
            this.numericUpDownRows.Location = new System.Drawing.Point(124, 217);
            this.numericUpDownRows.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.numericUpDownRows.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownRows.Name = "numericUpDownRows";
            this.numericUpDownRows.Size = new System.Drawing.Size(65, 20);
            this.numericUpDownRows.TabIndex = 9;
            this.numericUpDownRows.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownRows.ValueChanged += new System.EventHandler(this.numericUpDownRows_ValueChanged);
            // 
            // numericUpDownCol
            // 
            this.numericUpDownCol.Location = new System.Drawing.Point(276, 217);
            this.numericUpDownCol.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.numericUpDownCol.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownCol.Name = "numericUpDownCol";
            this.numericUpDownCol.Size = new System.Drawing.Size(65, 20);
            this.numericUpDownCol.TabIndex = 11;
            this.numericUpDownCol.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownCol.ValueChanged += new System.EventHandler(this.numericUpDownCol_ValueChanged);
            // 
            // GameSettingsForm
            // 
            this.ClientSize = new System.Drawing.Size(378, 344);
            this.Controls.Add(this.numericUpDownCol);
            this.Controls.Add(this.numericUpDownRows);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.checkBoxAgainstComputer);
            this.Controls.Add(this.Player2TextBox);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.ColLabel);
            this.Controls.Add(this.RowsLabel);
            this.Controls.Add(this.BoardSizeLabel);
            this.Controls.Add(this.Player1TextBox);
            this.Controls.Add(this.PlayersLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Settings";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCol)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void numericUpDownRows_ValueChanged(object sender, EventArgs e)
        {
            numericUpDownCol.Value = numericUpDownRows.Value;
        }

        private void numericUpDownCol_ValueChanged(object sender, EventArgs e)
        {
            numericUpDownRows.Value = numericUpDownCol.Value;
        }

        private void checkBoxAgainstComputer_CheckedChanged(object sender, EventArgs e)
        {

            if (Player2TextBox.Enabled)
            {
                Player2TextBox.Enabled = false;
                Player2TextBox.Text = "[Computer]";
            }
            else
            {
                Player2TextBox.Enabled = true;
                Player2TextBox.Text = "";
            }

        }

        private void StartButton_Click(object sender, EventArgs e)
        {

            bool oneOfTheFieldsAreEmpty = string.IsNullOrWhiteSpace(textBox1.Text) ||
                                          string.IsNullOrWhiteSpace(Player2TextBox.Text);
            if (oneOfTheFieldsAreEmpty)
            {
                MessageBox.Show(k_MissingFieldsMessage, k_ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                collectGameSettingFromFormAndStartGame();
            }
        }

        private void collectGameSettingFromFormAndStartGame()
        {
            bool gameAgainstComputer = !checkBoxAgainstComputer.Checked;
            string player2Name = gameAgainstComputer ? "Computer" : Player2TextBox.Text;
            m_GameSettings = new TicTacToeGameSettings((int) numericUpDownRows.Value, textBox1.Text, player2Name,
                gameAgainstComputer);
            Close();

        }
    }
}
