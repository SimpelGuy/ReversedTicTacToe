using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ReversedTicTacToe.Logic
{
    public class GameManager
    {
        private readonly bool r_GameAgainstComputer;
        private readonly int r_BoardSize;
        private readonly GameBoard r_GameBoard;
        private readonly Player r_Player1;
        private readonly Player r_Player2;
        private int m_MoveCounter;

        public GameManager(TicTacToeGameSettings i_GameSettings)
        {
            r_GameAgainstComputer = i_GameSettings.GameAgainstComputer;
            r_BoardSize = i_GameSettings.BoardSize;
            r_GameBoard = new GameBoard(i_GameSettings.BoardSize);
            r_Player1 = new Player((char)eCellSign.XSign);
            r_Player2 = new Player((char)eCellSign.OSign);
            m_MoveCounter = 0; 
        }

        public void TakeTurn(bool i_IsPlayer1 ,int i_Row ,int i_Col)
        {
            m_MoveCounter++;
            if (i_IsPlayer1)
            {
                r_GameBoard.PutMarkUser(r_Player1, i_Row , i_Col);
            }
            else
            {
                r_GameBoard.PutMarkUser(r_Player2, i_Row, i_Col);
            }
        }

        public Tuple<int, int> ComputerTakeTurn()
        {
            Tuple<int, int> computerChoice ;
            m_MoveCounter++;
            computerChoice = r_GameBoard.PutMarkComputer(r_Player2);
            
            return computerChoice;
        }

        public bool CheckDraw()
        {
            return m_MoveCounter == r_BoardSize * r_BoardSize;
        }

        public int[] GetScores()
        {
            int[] scoreArray = new int[2];
            scoreArray[0] = r_Player1.Score;
            scoreArray[1] = r_Player2.Score;

            return scoreArray;
        }

        public bool HasCurrentPlayerLost(bool i_IsPlayer1)
        {
            bool playerLost = false;
            if (i_IsPlayer1)
            {
                playerLost = r_Player1.CheckIfLose(r_GameBoard);
                if (playerLost)
                {
                    r_Player2.IncrementScore();
                }
            }
            else
            {
                playerLost = r_Player2.CheckIfLose(r_GameBoard);
                if (playerLost)
                {
                    r_Player1.IncrementScore();
                } 
            }

            return playerLost;
        }

        public void RestartGameLogic()
        {
            m_MoveCounter = 0;
            r_GameBoard.InitGameBoard();
        }
    }
}
