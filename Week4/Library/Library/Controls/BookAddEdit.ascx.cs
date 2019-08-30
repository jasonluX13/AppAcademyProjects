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
    public partial class BookAddEdit : System.Web.UI.UserControl
    {
        int bookId = 0;
        int authorId = 0;
        public bool edit { get; set; }
        public string BookList { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (edit)
            {
                AddOrEdit.Text = "Edit Book";
                if (!int.TryParse(Request.QueryString["ID"], out bookId))
                {
                    Response.Redirect(BookList);
                }
                if (!IsPostBack)
                {
                    DataTable dt = DatabaseHelper.Retrieve(@"
                    select Title, ISBN, FirstName, LastName
                    from Book Inner Join Author on (AuthorId = Author.Id)
                    where Book.Id = @BookId
                ", new SqlParameter("@BookId", bookId));

                    if (dt.Rows.Count == 1)
                    {
                        Title.Text = dt.Rows[0].Field<string>("Title");
                        ISBN.Text = dt.Rows[0].Field<string>("ISBN");
                        string authorName = dt.Rows[0].Field<string>("FirstName") + " ";
                        authorName += dt.Rows[0].Field<string>("LastName");
                        Authors.SelectedValue = authorName;
                    }
                    else
                    {
                        Response.Redirect(BookList);
                    }
                }
            }
            else
            {
                AddOrEdit.Text = "Add Book";
            }
            if (!IsPostBack)
            {
                DataTable dt = DatabaseHelper.Retrieve(@"
                    select FirstName, LastName
                    from Author
                ");
                ListItemCollection items = new ListItemCollection();
                items.Add(new ListItem());
                foreach (DataRow row in dt.Rows)
                {
                    string author = "";
                    author += row.Field<string>("FirstName") + " ";
                    author += row.Field<string>("LastName");
                    ListItem item = new ListItem(author, author);
                    items.Add(item);
                }
                Authors.DataSource = items;
                Authors.DataBind();
            }
           
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            SelectAuthor();
            string title = Title.Text;
            string isbn = ISBN.Text;

            if (edit)
            {
                DatabaseHelper.Update(@"
                update Book set
                    Title = @Title,
                    ISBN = @ISBN,
                    AuthorId = @AuthorId
                where Id = @BookId
                ",
                new SqlParameter("@Title", title),
                new SqlParameter("@ISBN", isbn),
                new SqlParameter("@AuthorId", authorId),
                new SqlParameter("@BookId", bookId));
            }
            else
            {
                int? id = DatabaseHelper.Insert(@"
                insert into Book (Title, ISBN, AuthorId)
                values (@Title, @ISBN, @AuthorID);
            ",
              new SqlParameter("@Title", title),
              new SqlParameter("@ISBN", isbn),
              new SqlParameter("@AuthorID", authorId));

            }

            Response.Redirect(BookList);
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(BookList);
        }


        protected void SelectAuthor()
        {
            string[] name = Authors.SelectedValue.Split(' ');
            string firstName = name[0];
            string lastName = name[1];
            DataTable dt = DatabaseHelper.Retrieve(@"
                    select id
                    from Author
                    where FirstName = @FirstName and LastName = @LastName
                ",
                new SqlParameter("@FirstName", firstName),
                new SqlParameter("@LastName", lastName));
            authorId = dt.Rows[0].Field<int>("Id");
        }
    }


}