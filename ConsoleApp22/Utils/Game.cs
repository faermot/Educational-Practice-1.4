using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp22.Utils
{
    public class Game
    {
        private Board board;
        private Player player1;
        private Player player2;
        private Player currentPlayer;

        public Game()
        {
            board = new Board();
            player1 = new Player('X');
            player2 = new Player('O');
            currentPlayer = player1;
        }

        public void Start()
        {
            while (true)
            {
                Console.Clear();
                board.Display();
                Console.WriteLine($"Ход игрока {currentPlayer.Symbol}. Введите номер клетки (1-9): ");

                int cell;

                if (int.TryParse(Console.ReadLine(), out cell) && board.IsCellAvailable(cell))
                {
                    board.MarkCell(cell, currentPlayer.Symbol);

                    if (board.CheckWin(currentPlayer.Symbol))
                    {
                        Console.Clear();
                        board.Display();
                        Console.WriteLine($"Игрок {currentPlayer.Symbol} выиграл!");
                        break;
                    }
                    else if (board.IsFull())
                    {
                        Console.Clear();
                        board.Display();
                        Console.WriteLine("Ничья!");
                        break;
                    }

                    currentPlayer = (currentPlayer == player1) ? player2 : player1;
                }
                else
                {
                    Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                    Thread.Sleep(3000);
                }
            }
        }

    }
}
