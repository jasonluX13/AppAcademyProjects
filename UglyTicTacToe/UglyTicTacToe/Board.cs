using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UglyTicTacToe
{
    public class Board
    {
        private static Player[,] board =
        {
            {Player.None, Player.None, Player.None},
            {Player.None, Player.None, Player.None},
            {Player.None, Player.None, Player.None}
        };
        private static int TurnNumber = 1;

        public static Player[,] GetBoard()
        {
            return board;
        }
        public static void ResetBoard()
        {
            for (int row=0; row < board.GetLength(0); row++)
            {
                for (int col=0; col < board.GetLength(1); col++)
                {
                    board[row, col] = Player.None;
                }
            }
            TurnNumber = 1;
        }

        public static int GetTurnNumber()
        {
            return TurnNumber;
        }

        public static void NextTurn()
        {
            TurnNumber++;
        }
    }
}