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
    public partial class BookList : BaseControl
    {
    
        protected void Page_Load(object sender, EventArgs e)
        {
           
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