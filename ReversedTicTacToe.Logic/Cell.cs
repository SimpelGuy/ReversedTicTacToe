namespace ReversedTicTacToe.Logic
{
    internal class Cell
    {
        private eCellSign m_Sign;

        public Cell()
        {
            m_Sign = eCellSign.EmptySign;
        }

        public eCellSign Sign
        {
            get
            {
                return m_Sign;
            }
        }

        internal void MarkField(Player player)
        {
            if (IsEmpty())
            {
                if (player.Sign == 'X')
                {
                    m_Sign = eCellSign.XSign;
                }
                else
                {
                    m_Sign = eCellSign.OSign;
                }
            }
        }

        internal bool IsEmpty()
        {
            bool isEmpty = m_Sign == eCellSign.EmptySign;

            return isEmpty;
        }
    }
}
