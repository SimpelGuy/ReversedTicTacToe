using System;
using System.Collections.Generic;

namespace ReversedTicTacToe.Logic
{
    internal class GameBoard
    {
        private readonly Cell[,] r_Board;
        private int m_Size;
        private List<Tuple<int, int>> m_EmptyLocations = new List<Tuple<int, int>>();
        private Random m_random;
        public GameBoard(int i_Size)
        {
            m_Size = i_Size;
            r_Board = new Cell[i_Size, i_Size];
            m_random = new Random();
            InitGameBoard();
        }

        internal void InitGameBoard()
        {
            initializeEmptyLocations();
            cleanBoard();
        }

        public int Size
        {
            get
            {
                return m_Size;
            }
        }

        public Cell[,] Board
        {
            get
            {
                return r_Board;
            }
        }
        internal void PutMarkUser(Player io_Player, int i_Row , int i_Col)
        {
                r_Board[i_Row ,i_Col ].MarkField(io_Player);
                Tuple<int, int> itemToRemove = new Tuple<int, int>(i_Row , i_Col);
                m_EmptyLocations.Remove(itemToRemove);
        }

        internal Tuple<int, int> PutMarkComputer(Player io_Player)
        {
            Tuple<int, int> computerMarkPosition = GetRandomEmptyLocations();
            r_Board[computerMarkPosition.Item1, computerMarkPosition.Item2].MarkField(io_Player);
            m_EmptyLocations.Remove(computerMarkPosition);
            
            return computerMarkPosition;
        }

        private void cleanBoard()
        {
            for (int i = 0; i < m_Size; i++)
            {
                for (int j = 0; j < m_Size; j++)
                {
                    r_Board[i, j] = new Cell();
                }
            }
        }

        internal Tuple<int, int> GetRandomEmptyLocations()
        {
            int index = m_random.Next(m_EmptyLocations.Count);
            Tuple<int, int> element = m_EmptyLocations[index];
            
            return element;
        }

        private void initializeEmptyLocations()
        {
            m_EmptyLocations.Clear();
            int boardSize = m_Size;
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    m_EmptyLocations.Add(new Tuple<int, int>(i, j));
                }
            }
        }


    }
}