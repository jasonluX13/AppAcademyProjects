using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UglyTicTacToe
{
    public enum Player
    {
        None,
        X,
        O
    }
    public partial class Game : Base
    {
       

        private static string TurnKey = "turn";
        public bool Turn
        {
            get
            {
                if (ViewState[TurnKey] == null)
                {
                    return true;
                }
                else
                {
                    return (bool)ViewState[TurnKey];
                }
            }
            set
            {
                ViewState[TurnKey] = value;
            }
        }
      
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TakeTurn(Button button, int row, int col)
        {
            Board.NextTurn();
            if (Turn == true)
            {
                button.Text = "X";
                Board.GetBoard()[row, col] = Player.X;
                Turn = false;

                if (Win(Player.X))
                {
                    Winner.Text = "Congratulations Player X, You Won!";
                    return;
                }
            }
            else
            {
                button.Text = "O";
                Turn = true;
                Board.GetBoard()[row, col] = Player.O;
                if (Win(Player.O))
                {
                    Winner.Text = "Congratulations Player O, You Won!";
                }
            }
            button.Enabled = false;
        }
        protected void aa_Click(object sender, EventArgs e)
        {
            TakeTurn(aa, 0, 0);
        }

        protected void ab_Click(object sender, EventArgs e)
        {
            TakeTurn(ab, 0, 1);
        }

        protected void ac_Click(object sender, EventArgs e)
        {
            TakeTurn(ac, 0, 2);
        }

        protected void ba_Click(object sender, EventArgs e)
        {
            TakeTurn(ba, 1, 0);
        }

        protected void bb_Click(object sender, EventArgs e)
        {
            TakeTurn(bb, 1, 1);
        }

        protected void bc_Click(object sender, EventArgs e)
        {
            TakeTurn(bc, 1, 2);
        }

        protected void ca_Click(object sender, EventArgs e)
        {
            TakeTurn(ca, 2, 0);
        }

        protected void cb_Click(object sender, EventArgs e)
        {
            TakeTurn(cb, 2, 1);
        }

        protected void cc_Click(object sender, EventArgs e)
        {
            TakeTurn(cc, 2, 2);
        }

        protected bool Win(Player player)
        {
            if (Board.GetTurnNumber() > 9)
            {
                Winner.Text = "You have Tied";
            }
            //check rows
            for (int row=0; row < Board.GetBoard().GetLength(0); row ++)
            {
                if (Board.GetBoard()[row,0] == player && Board.GetBoard()[row,1] == player && Board.GetBoard()[row,2] == player)
                {
                    EnableButtons(false);
                    return true;
                }
            }
            //check columns
            for (int col = 0; col < Board.GetBoard().GetLength(1); col++)
            {
                if (Board.GetBoard()[0, col] == player && Board.GetBoard()[1, col] == player && Board.GetBoard()[2, col] == player)
                {
                    EnableButtons(false);
                    return true;
                }
            }
            //check diagonals
            if (Board.GetBoard()[0, 0] == player && Board.GetBoard()[1, 1] == player && Board.GetBoard()[2, 2] == player)
            {
                EnableButtons(false);
                return true;
            }
            if (Board.GetBoard()[0, 2] == player && Board.GetBoard()[1, 1] == player && Board.GetBoard()[2, 0] == player)
            {
                EnableButtons(false);
                return true;
            }
            return false;
        }

        protected void EnableButtons(bool enable)
        {
            //GameBoard.Enabled = enable;

            aa.Enabled = enable;
            ab.Enabled = enable;
            ac.Enabled = enable;

            ba.Enabled = enable;
            bb.Enabled = enable;
            bc.Enabled = enable;

            ca.Enabled = enable;
            cb.Enabled = enable;
            cc.Enabled = enable;
        }
        protected void ResetGame_Click(object sender, EventArgs e)
        {
            Turn = true;
            Winner.Text = "";
            Board.ResetBoard();
            EnableButtons(true);

            aa.Text = "  ";   
            ab.Text = "  ";
            ac.Text = "  ";

            ba.Text = "  ";
            bb.Text = "  ";
            bc.Text = "  ";

            ca.Text = "  ";
            cb.Text = "  ";
            cc.Text = "  ";
        }

        protected void PrintBoard()
        {
            Winner.Text = "";
            for (int row = 0; row < Board.GetBoard().GetLength(0); row++)
            {
                for (int col = 0; col < Board.GetBoard().GetLength(1); col++)
                {
                    Winner.Text += Board.GetBoard()[row, col].ToString() + " ";
                }
                Winner.Text += "<br/>";
            }
        }

       
    }
}