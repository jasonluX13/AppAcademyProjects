using Library.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library.Controls
{
    public partial class BookList : System.Web.UI.UserControl
    {
        public string AddBookUrl { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            BookAddLink.NavigateUrl = AddBookUrl;
            if (!IsPostBack)
            {
                DataTable dt = DatabaseHelper.Retrieve(@"
                    select Book.Id, Title, ISBN, FirstName, LastName
                    from Book inner join Author on (Book.AuthorId = Author.Id)
                    order by Title
                ");

                Books.DataSource = dt.Rows;
                Books.DataBind();
            }
        }
    }
}