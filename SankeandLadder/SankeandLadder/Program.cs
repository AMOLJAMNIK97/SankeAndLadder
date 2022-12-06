// See https://aka.ms/new-console-template for more information



using SankeandLadder;
using System;
using System.Collections.Generic;

namespace Snakes_and_ladders
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ladders
            Dictionary<int, int> ladderDicctionary = new Dictionary<int, int>()
            {
                {2, 38}, {7, 14}, {8, 31}, {16, 26}, {21, 42},
                {28, 84}, {36, 44}, {51, 67}, {71, 91}, {78, 98}, {87, 94}
            };

            // Snakes
            Dictionary<int, int> snakesDicctionary = new Dictionary<int, int>()
            {
                {15, 5}, {48, 10}, {45, 24}, {61, 18}, {63, 59},
                {73, 52}, {88, 67}, {91, 87}, {94, 74}, {98, 79}
            };

            SnakeBord customBoard = new SnakeBord(10, 10, ladderDicctionary, snakesDicctionary);

            // Board by default.
            SnakeBord board = new SnakeBord();
            List<CPlayers> players = new List<CPlayers>();

            int n_players = 0;
            do
            {
                Console.Write("Enter the number of players: ");
                n_players = Convert.ToInt32(Console.ReadLine());

                if (n_players <= 1)
                    Console.WriteLine("The total of players need to be 2 or more.");

            } while (n_players <= 1);


            for (int i = 1; i < n_players + 1; i++)
            {
                Console.Write("Enter the name for the player {0}: ", i);
                string nickName = Console.ReadLine();

                players.Add(new CPlayers(nickName, customBoard));
            }

            string pressed = "";
            int count = 0;

            do
            {
                if (count >= n_players)
                    count = 0;

                CPlayers currentPlayer = players[count];
                Console.WriteLine("It's the player {0}'s turn", currentPlayer.NickName);
                Console.WriteLine("Press R to Roll the die or A to abort the game.");
                pressed = Console.ReadLine();

                if (pressed.Equals("R", StringComparison.CurrentCultureIgnoreCase))
                {

                    Console.WriteLine("--------------------------------");

                    currentPlayer.Roll();
                    Console.WriteLine("Dice's result: {0} ", currentPlayer.DiceResult);

                    int previousPosition = currentPlayer.Position;
                    currentPlayer.Move();
                    Console.WriteLine("You moved from cell [{0}] ====> to cell [{1}]", previousPosition, currentPlayer.Position);

                    if (currentPlayer.Winner)
                    {
                        Console.WriteLine("Player {0} won the game.", currentPlayer.NickName);
                        break;
                    }

                    Console.WriteLine("--------------------------------");
                    count++;
                }

            } while (!pressed.Equals("A", StringComparison.CurrentCultureIgnoreCase));

            Console.ReadLine();
        }
    }
}