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
    public partial class BorrowedList : BaseControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                DataTable dt;
                int libraryCardNumber = int.Parse(CustomUser.Identity.Name);
                if (CustomUser.IsPatron)
                {
                    dt = DatabaseHelper.Retrieve(@"
                    select BorrowedId, BookCopy.Id, Title, ISBN, Author.FirstName+' '+Author.LastName as AuthorName, BranchName,
                    Patron.FirstName+' '+Patron.LastName as PatronName, BorrowedDate, DueDate, ReturnDate
                    from BookCopy join Book on (BookCopy.BookId = Book.Id) 
                    join Author on (Book.AuthorId = Author.Id)
                    join Library on (BookCopy.LibraryId = Library.Id)
                    join Borrowed on (BookCopy.Id = Borrowed.BookCopyId)
                    join Patron on (Borrowed.PatronId = Patron.LibraryCardNumber)
                    where ReturnDate is null and Patron.LibraryCardNumber = @LibraryCardNumber
                    order by DueDate desc
                ", new SqlParameter("@LibraryCardNumber", libraryCardNumber));
                }
                else
                {
                    dt = DatabaseHelper.Retrieve(@"
                    select BorrowedId, BookCopy.Id, Title, ISBN, Author.FirstName+' '+Author.LastName as AuthorName, BranchName,
                    Patron.FirstName+' '+Patron.LastName as PatronName, BorrowedDate, DueDate, ReturnDate
                    from BookCopy join Book on (BookCopy.BookId = Book.Id) 
                    join Author on (Book.AuthorId = Author.Id)
                    join Library on (BookCopy.LibraryId = Library.Id)
                    join Borrowed on (BookCopy.Id = Borrowed.BookCopyId)
                    join Patron on (Borrowed.PatronId = Patron.LibraryCardNumber)
                    where ReturnDate is null
                    order by DueDate desc
                ");
                }
                
                BorrowedBooks.DataSource = dt.Rows;
                BorrowedBooks.DataBind();
            }
        }

        protected void Return_Click(object sender, EventArgs e)
        {
            Button returnBook = (Button)sender;
            int borrowedId = int.Parse(returnBook.CommandArgument);

            DatabaseHelper.Update(@"
            Update Borrowed set
            ReturnDate = @ReturnDate
            where BorrowedId = @BorrowedId",
            new SqlParameter("@ReturnDate", DateTimeOffset.Now),
            new SqlParameter("@BorrowedId", borrowedId));

            DataTable dt = DatabaseHelper.Retrieve(@"
                    select BookCopy.Id from
                    Borrowed join BookCopy on (Borrowed.BookCopyId = BookCopy.Id)
                    where BorrowedId = @BorrowedId
                ", new SqlParameter("@BorrowedId", borrowedId));

            int bookCopyId = dt.Rows[0].Field<int>("Id");
            DatabaseHelper.Update(@"
                Update BookCopy set
                Out = @Out
                where Id = @BookCopyId",
             new SqlParameter("@Out", false),
             new SqlParameter("@BookCopyId", bookCopyId));

            Response.Redirect("~/Borrowed.aspx");

        }
    }
}