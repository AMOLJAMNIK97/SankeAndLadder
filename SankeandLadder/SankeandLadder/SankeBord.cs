using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SankeandLadder
{
    internal class SnakeBord
    {
        private int[] board;
        List<CPlayers> Players = new List<CPlayers> { };
        public int[] Board { get => board; }
        public SnakeBord ()
        {
            board = new int[100];
            Array.Clear(board, 0, board.Length);
        }
        private void createSnakesOrLadders(Dictionary<int, int> dataDict)
        {
            foreach (KeyValuePair<int, int> data in dataDict)
            {
                board[data.Key - 1] = data.Value - 1;
            }
        }
        public SnakeBord(int altura, int largo, Dictionary<int, int> ladders = null, Dictionary<int, int> snakes = null)
        {
            if (altura < 2 || largo < 2)
                throw new ArgumentException("The Height and length need to be least greater than 1.");
            int ladderSize = 0;
            int snakesSize = 0;

            if (!(ladders is null))
                ladderSize = ladders.Count;
            if (!(snakes is null))
                snakesSize = snakes.Count;

            // We create the board, with values set to 0.
            board = new int[altura * largo];
            Array.Clear(board, 0, board.Length);

            // If the total size of the number of ladders and snakes is less than half the board
            // ladders and snakes are created on the board. If not, the exception is thrown.

            if ((ladderSize * 2) + (snakesSize * 2) / 2 < board.Length)
            {
                if (!(ladders is null))
                    createSnakesOrLadders(ladders);

                if (!(snakes is null))
                    createSnakesOrLadders(snakes);
            }
            else
            {
                throw new Exception("The total sum of Snakes and Ladders cannot exceed 50% of the board.");
            }
        }
    }
}
