using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversedTicTacToe.Logic
{
    internal static class WinningHandler
    {
        internal static bool checkRowsForLose(GameBoard io_gameBoard)
        {
            bool gameEnd = false;
            for (int i = 0; i < io_gameBoard.Size; i++)
            {
                if (io_gameBoard.Board[i, 0].Sign != eCellSign.EmptySign)
                {
                    bool flag = true;
                    eCellSign temp = io_gameBoard.Board[i, 0].Sign;
                    for (int j = 1; j < io_gameBoard.Size; j++)
                    {
                        if (io_gameBoard.Board[i, j].Sign != temp)
                        {
                            flag = false;
                            break;
                        }
                    }

                    if (flag)
                    {
                        gameEnd = true;
                        break;
                    }
                }

            }

            return gameEnd;
        }

        internal static bool checkColumnsForLose(GameBoard io_gameBoard)
        {
            bool gameEnd = false;
            for (int i = 0; i < io_gameBoard.Size; i++)
            {
                if (io_gameBoard.Board[0, i].Sign != eCellSign.EmptySign)
                {
                    bool flag = true;
                    eCellSign temp = io_gameBoard.Board[0, i].Sign;
                    for (int j = 1; j < io_gameBoard.Size; j++)
                    {
                        if (io_gameBoard.Board[j, i].Sign != temp)
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (flag)
                    {
                        gameEnd = true;
                        break;
                    }
                }
            }

            return gameEnd;
        }

        internal static bool checkMainDiagonalsForLose(GameBoard io_gameBoard)
        {
            bool endGame = false;
            if (io_gameBoard.Board[0, 0].Sign != eCellSign.EmptySign)
            {
                bool flag = true;
                eCellSign temp = io_gameBoard.Board[0, 0].Sign;
                for (int j = 1; j < io_gameBoard.Size; j++)
                {
                    if (io_gameBoard.Board[j, j].Sign != temp)
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    endGame = true;
                }
            }

            return endGame;
        }

        internal static bool checkSecondaryDiagonalsForLose(GameBoard io_gameBoard)
        {
            bool endGame = false;
            int boardSize = io_gameBoard.Size - 1;
            if (io_gameBoard.Board[0, boardSize].Sign != eCellSign.EmptySign)
            {
                bool flag = true;
                eCellSign temp = io_gameBoard.Board[0, boardSize].Sign;
                for (int j = 1; j < io_gameBoard.Size; j++)
                {
                    if (io_gameBoard.Board[j, boardSize - j].Sign != temp)
                    {
                        flag = false;
                        break;
                    }
                }

                if (flag)
                {
                    endGame = true;
                }
            }

            return endGame;
        }

    }
}

