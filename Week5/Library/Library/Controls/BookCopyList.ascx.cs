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
    public partial class BookCopyList : BaseControl
    {
        const string ListModeKey = "ListMode";
        protected bool listMode
        {
            get
            {
                if (ViewState[ListModeKey] == null)
                {
                    return false;
                }
                return (bool)ViewState[ListModeKey];
            }
            set
            {
                ViewState[ListModeKey] = value;
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            if (!CustomUser.IsLibrarian)
            {
                ListModeButton.Visible = false;
                listMode = false;
            }
            else
            {
                switch (listMode)
                {
                    case true:
                        ListModeButton.Text = "List All Book Copies";
                        break;
                    case false:
                        ListModeButton.Text = "View Local Branch Only";
                        break;
                }
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindRepeater();
            }

        }

        protected void BindRepeater()
        {
            DataTable bookCopiesdt;
            if (!listMode)
            {
                bookCopiesdt = DatabaseHelper.Retrieve(@"
                    select BookCopy.Id, Title, ISBN, FirstName, LastName, BranchName, Out, Available
                    from BookCopy join Book on (BookCopy.BookId = Book.Id) 
                    join Author on (Book.AuthorId = Author.Id)
                    join Library on (BookCopy.LibraryId = Library.Id)
                    order by Title
                ");
            }
            else
            {
                int libraryCardNumber = int.Parse(Context.User.Identity.Name);
                DataTable getLibrary = DatabaseHelper.Retrieve(@"
                        select LibraryId from Librarian
                        where LibraryCardNumber = @LibraryCardNumber
                    ", new SqlParameter("@LibraryCardNumber", libraryCardNumber));
                int libraryId = getLibrary.Rows[0].Field<int>("LibraryId");

                bookCopiesdt = DatabaseHelper.Retrieve(@"
                    select BookCopy.Id, Title, ISBN, FirstName, LastName, BranchName, Out, Available
                    from BookCopy join Book on (BookCopy.BookId = Book.Id) 
                    join Author on (Book.AuthorId = Author.Id)
                    join Library on (BookCopy.LibraryId = Library.Id)
                    where LibraryId = @LibraryId 
                    order by Title
                ", new SqlParameter("@LibraryId", libraryId));
            }


            BookCopies.DataSource = bookCopiesdt.Rows;
            BookCopies.DataBind();
        }
        protected void ListMode_Click(object sender, EventArgs e)
        {
            listMode = !listMode;
            switch (listMode)
            {
                case true:
                    ListModeButton.Text = "List All Book Copies";
                    break;
                case false:
                    ListModeButton.Text = "View Local Branch Only";
                    break;
            }
            BindRepeater();
        }
    }
}