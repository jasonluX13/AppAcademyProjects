using Library.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library.Controls
{
    public partial class CheckoutBook : System.Web.UI.UserControl
    {
        protected int bookCopyId;
        protected int patronId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!int.TryParse(Request.QueryString["ID"], out bookCopyId))
            {
                Response.Redirect("~/BookCopy.aspx");
            }
            if (!IsPostBack)
            {
                DataTable dt = DatabaseHelper.Retrieve(@"
                    select Title, ISBN, FirstName, LastName, BranchName
                    from BookCopy join Book on (BookCopy.BookId = Book.Id)
                    join Author on (Book.AuthorId = Author.Id)
                    join Library on (BookCopy.LibraryId = Library.Id)
                    where BookCopy.Id = @BookCopyId
                ", new SqlParameter("@BookCopyId", bookCopyId));

                if (dt.Rows.Count == 1)
                {
                    Title.Text = "Title: " + dt.Rows[0].Field<string>("Title");
                    Author.Text = "Author: " + dt.Rows[0].Field<string>("FirstName") + " " +  dt.Rows[0].Field<string>("LastName");
                    ISBN.Text = "ISBN: " + dt.Rows[0].Field<string>("ISBN");
                    Library.Text = "Library: " + dt.Rows[0].Field<string>("BranchName");


                    DataTable dt2 = DatabaseHelper.Retrieve(@"
                    select LibraryCardNumber, FirstName + ' ' +  LastName as Name
                    from Patron
                ");
                    Patrons.DataValueField = "LibraryCardNumber";
                    Patrons.DataTextField = "Name";
                    Patrons.AppendDataBoundItems = true;
                    Patrons.Items.Add(new ListItem("Select a patron...", ""));
                    Patrons.DataSource = dt2;
                    Patrons.DataBind();

                }
                else
                {
                    Response.Redirect("~/BookCopy.aspx");
                }
            }
        }

        protected void Checkout_Click(object sender, EventArgs e)
        {
            patronId = int.Parse(Patrons.SelectedValue);
            DatabaseHelper.Insert(@"
                insert into Borrowed (PatronId, BookCopyId, BorrowedDate, DueDate, ReturnDate)
                values (@PatronId, @BookCopyId, @BorrowedDate, @DueDate, @ReturnDate);
            ",
              new SqlParameter("@PatronId", patronId),
              new SqlParameter("@BookCopyId", bookCopyId),
              new SqlParameter("@DueDate", DateTimeOffset.Now.AddDays(20)),
              new SqlParameter("@BorrowedDate", DateTimeOffset.Now),
              new SqlParameter("@ReturnDate", (object)DBNull.Value));

            DatabaseHelper.Update(@"
                Update BookCopy set
                Out = @Out
                where Id = @BookCopyId",
             new SqlParameter("@Out", true),
             new SqlParameter("@BookCopyId", bookCopyId));
            Response.Redirect("~/Borrowed.aspx");

        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/BookCopy.aspx");
        }
    }
}