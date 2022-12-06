using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SankeandLadder
{
    internal class CPlayers
    {
        int[] board;
        private int position = 0;
        private string nickName = null;
        private int diceResult = 0;
        private bool winner = false;

        public int Position { get => position + 1; }
        public int DiceResult { get => diceResult; }
        public string NickName { get => nickName; }
        public bool Winner { get => winner; }


        public CPlayers(string nickName, SnakeBord board)
        {
            this.nickName = nickName;
            this.board = board.Board;
        }

        public void Roll()
        {
            // Wait 30 milliseconds to change the random seed.
            Random rnd = new Random();
            Thread.Sleep(30);
            diceResult = rnd.Next(1, 7);
        }
        public void Move()
        {
            // Move the player N dice cells.
            if (position + diceResult < board.Length)
                if (board[position + diceResult] == 0)
                    position = position + diceResult;
                else
                    position = board[diceResult + position];

            if (position == board.Length - 1)
                winner = true;
        }

    }
}
