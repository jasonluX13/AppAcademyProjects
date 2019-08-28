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
            if (!IsPostBack)
            {
                DataTable dt = DatabaseHelper.Retrieve(@"
                    select FirstName, LastName
                    from Author
                ");
                ListItemCollection items = new ListItemCollection();
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
            TitleLabel.Text += authorId;
        }
    }


}