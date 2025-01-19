using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp22.Utils
{
    public class Board
    {
        private char[] _cells;

        public Board()
        {
            _cells = new char[9];
        }

        public void Display()
        {
            Console.WriteLine("Текущая доска: ");
            for (int i = 0; i < 9; i++)
            {
                if (_cells[i] == '\0')
                    Console.Write(i + 1);
                else
                    Console.Write(_cells[i]);

                if (i % 3 == 2)
                    Console.WriteLine();
                else
                    Console.Write("|");

            }
        }

        public bool IsCellAvailable(int cell)
        {
            if (cell >= 1 && cell <= 9)
                return _cells[cell - 1] == '\0';
            else return false;
        }

        public void MarkCell(int cell, char symbol)
        {
            _cells[cell - 1] = symbol;
        }

        public bool CheckWin(char symbol)
        {
            return (_cells[0] == symbol && _cells[1] == symbol && _cells[2] == symbol) ||
                   (_cells[3] == symbol && _cells[4] == symbol && _cells[5] == symbol) ||
                   (_cells[6] == symbol && _cells[7] == symbol && _cells[8] == symbol) ||
                   (_cells[0] == symbol && _cells[3] == symbol && _cells[6] == symbol) ||
                   (_cells[1] == symbol && _cells[4] == symbol && _cells[7] == symbol) ||
                   (_cells[2] == symbol && _cells[5] == symbol && _cells[8] == symbol) ||
                   (_cells[0] == symbol && _cells[4] == symbol && _cells[8] == symbol) ||
                   (_cells[2] == symbol && _cells[4] == symbol && _cells[6] == symbol);
        }

        public bool IsFull()
        {
            foreach (var cell in _cells)
            {
                if (cell == '\0')
                    return false;
            }
            return true;
        }

    }
}
