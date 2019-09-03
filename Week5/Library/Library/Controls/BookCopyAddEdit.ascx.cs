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
    public partial class BookCopyAddEdit : System.Web.UI.UserControl
    {
        int bookCopyId = 0;
        int bookId = 0;
        int libraryId = 0;
        public bool edit { get; set; }
        public string BookCopyList { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (edit)
            {
                AddOrEdit.Text = "Edit Book Copy";
                Cancel.Visible = true;
                CheckedOutLabel.Visible = true;
                CheckedOut.Visible = true;
                AvailableLabel.Visible = true;
                Available.Visible = true;
                if (!int.TryParse(Request.QueryString["ID"], out bookCopyId))
                {
                    Response.Redirect(BookCopyList);
                }
                if (!IsPostBack)
                {
                    DataTable dt = DatabaseHelper.Retrieve(@"
                    select Book.Id as BookId, BookCopy.LibraryId  as LibraryId, Out, Available
                    from BookCopy join Book on (BookCopy.BookId = Book.Id)
                    where BookCopy.Id = @BookCopyId
                ", new SqlParameter("@BookCopyId", bookCopyId));

                    if (dt.Rows.Count == 1)
                    {
                        int selectedBookId = dt.Rows[0].Field<int>("BookId");
                        int selectedLibraryId = dt.Rows[0].Field<int>("LibraryId");
                        bool selectedOut = dt.Rows[0].Field<bool>("Out");
                        bool selectedAvailable = dt.Rows[0].Field<bool>("Available");
                        Books.SelectedValue = selectedBookId.ToString();
                        Libraries.SelectedValue = selectedLibraryId.ToString();
                        CheckedOut.Checked = selectedOut;
                        Available.Checked = selectedAvailable;
                    }
                    else
                    {
                        Response.Redirect(BookCopyList);
                    }
                }
            }
            else
            {
                AddOrEdit.Text = "Add Book Copy";
            }
            if (!IsPostBack)
            {
                DataTable dt = DatabaseHelper.Retrieve(@"
                    select Book.Id as BookId, Title + '    By: ' + FirstName + ' ' + LastName as BookName
                    from Book join Author on Book.AuthorId = Author.Id
                ");
                
                Books.DataValueField = "BookId";
                Books.DataTextField = "BookName";
                Books.AppendDataBoundItems = true;
                Books.Items.Add(new ListItem("Select Value...", string.Empty));
                Books.DataSource = dt;
                Books.DataBind();


                DataTable dt2 = DatabaseHelper.Retrieve(@"
                    select BranchName, Id
                    from Library
                ");

                Libraries.DataValueField = "Id";
                Libraries.DataTextField = "BranchName";

                Libraries.AppendDataBoundItems = true;
                Libraries.Items.Add(new ListItem("Select Value...", string.Empty));
                Libraries.DataSource = dt2;
                Libraries.DataBind();
            }

        }

        protected void Save_Click(object sender, EventArgs e)
        {
            SelectBook();
            SelectLibrary();
            bool checkedOut = false;
            bool available = true;
            if (edit)
            {
                
                checkedOut = CheckedOut.Checked;
                available = Available.Checked;

                DatabaseHelper.Update(@"
                update BookCopy set
                    BookId = @BookId,
                    LibraryId = @LibraryId,
                    Available = @Available,
                    Out = @Out
                where Id = @BookCopyId
                ",
                new SqlParameter("@BookId", bookId),
                new SqlParameter("@LibraryId", libraryId),
                new SqlParameter("@Available", available),
                new SqlParameter("@Out", checkedOut),
                new SqlParameter("@BookCopyId", bookCopyId));
                Response.Redirect(BookCopyList);
            }
            else
            {
                int? id = DatabaseHelper.Insert(@"
                insert into BookCopy (BookId, LibraryId, Out, Available)
                values (@BookId, @LibraryId, @Out, @Available);
            ",
              new SqlParameter("@BookId", bookId),
              new SqlParameter("@LibraryId", libraryId),
              new SqlParameter("@Available", available),
              new SqlParameter("@Out", checkedOut));
                Response.Redirect(Request.RawUrl);
            }

            
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(BookCopyList);
        }


        protected void SelectBook()
        {
            bookId = int.Parse(Books.SelectedValue);
        }

        protected void SelectLibrary()
        {
            libraryId = int.Parse(Libraries.SelectedValue);
        }
    }
}