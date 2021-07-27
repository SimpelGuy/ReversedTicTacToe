using System;

namespace ReversedTicTacToe.Logic
{
    internal class Player
    {
        private readonly char r_Sign;
        private int m_Score;

        public Player(char i_Sign)
        {
            r_Sign = i_Sign;
            m_Score = 0;
        }

        public char Sign
        {
            get
            {
                return r_Sign;
            }
        }

        public int Score
        {
            get
            {
                return m_Score;
            }
        }

        internal void IncrementScore()
        {
            m_Score += 1;
        }

        internal int[] TakeTurnComputer(int i_boardSize, GameBoard io_gameBoard)
        {
            int[] positions = new int[2];
            Tuple<int, int> computerChoice = io_gameBoard.GetRandomEmptyLocations();
            positions[0] = computerChoice.Item1;
            positions[1] = computerChoice.Item2;
            return positions;
        }

        internal bool CheckIfLose(GameBoard io_board)
        {
            return WinningHandler.checkRowsForLose(io_board) || WinningHandler.checkColumnsForLose(io_board) ||
                   WinningHandler.checkMainDiagonalsForLose(io_board) || WinningHandler.checkSecondaryDiagonalsForLose(io_board);
        }
    }
}