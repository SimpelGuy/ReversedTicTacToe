namespace ReversedTicTacToe.Logic
{
    public class TicTacToeGameSettings
    {
        private readonly int r_BoardSize;
        private readonly string r_Player1Name;
        private readonly string r_Player2Name;
        private readonly bool r_GameAgainstComputer;

        public TicTacToeGameSettings(int i_BoardSize, string i_Player1Name, string i_Player2Name, bool i_GameAgainstComputer)
        {
            r_BoardSize = i_BoardSize;
            r_Player1Name = i_Player1Name;
            r_Player2Name = i_Player2Name;
            r_GameAgainstComputer = i_GameAgainstComputer;
        }

        public string Player1Name
        {
            get
            {
                return r_Player1Name;
            }
            
        }

        public string Player2Name
        {
            get
            {
                return r_Player2Name;
            }
        }

        public bool GameAgainstComputer
        {
            get
            {
                return r_GameAgainstComputer;
            }
        }

        public int BoardSize
        {
            get
            {
                return r_BoardSize;
            }
        }
    }
   
}