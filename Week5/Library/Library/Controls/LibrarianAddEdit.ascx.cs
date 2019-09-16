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
    public partial class LibrarianAddEdit : System.Web.UI.UserControl
    {
        int patronId = 0;
        int libraryId = 0;
        int librarianId = 0;
        public bool edit { get; set; }
        public string LibrarianList { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (edit)
            {
                AddOrEdit.Text = "Edit Librarian";
                Cancel.Visible = true;

                if (!int.TryParse(Request.QueryString["ID"], out librarianId))
                {
                    Response.Redirect(LibrarianList);
                }
                if (!IsPostBack)
                {
                    DataTable dt = DatabaseHelper.Retrieve(@"
                    select Librarian.LibraryCardNumber, LibraryId
                    from Librarian join Library on (Librarian.LibraryId = Library.Id)
                    join Patron on (Librarian.LibraryCardNumber = Patron.LibraryCardNumber)
                    where Librarian.Id = @LibrarianId
                ", new SqlParameter("@LibrarianId", librarianId));

                    if (dt.Rows.Count == 1)
                    {
                        int selectedPatronId = dt.Rows[0].Field<int>("LibraryCardNumber");
                        int selectedLibraryId = dt.Rows[0].Field<int>("LibraryId");

                        Patrons.SelectedValue = selectedPatronId.ToString();
                        Libraries.SelectedValue = selectedLibraryId.ToString();
                    }
                    else
                    {
                        Response.Redirect(LibrarianList);
                    }
                }
            }
            else
            {
                AddOrEdit.Text = "Add Librarian";
            }
            if (!IsPostBack)
            {
                DataTable dt = DatabaseHelper.Retrieve(@"
                    select LibraryCardNumber, FirstName + ' ' + LastName As Name 
                    from Patron
                ");

                Patrons.DataValueField = "LibraryCardNumber";
                Patrons.DataTextField = "Name";
                Patrons.AppendDataBoundItems = true;
                Patrons.Items.Add(new ListItem("Select Value...", string.Empty));
                Patrons.DataSource = dt;
                Patrons.DataBind();


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
            patronId = SelectPatron();
            libraryId = SelectLibrary();
            string password = Password.Text;
            string hashedPassword = Hashing.HashPassword(password);
            if (edit)
            {
                DatabaseHelper.Update(@"
                update Librarian set
                    LibraryCardNumber = @LibraryCardNumber,
                    LibraryId = @LibraryId
                where Id = @LibrarianId
                ",
                new SqlParameter("@LibraryCardNumber", patronId),
                new SqlParameter("@LibrarianId", librarianId),
                new SqlParameter("@LibraryId", libraryId));

                DatabaseHelper.Update(@"
                update Patron set
                    Password = @Password
                where LibraryCardNumber = @LibraryCardNumber
                ",
                new SqlParameter("@LibraryCardNumber", patronId),
                new SqlParameter("@Password", hashedPassword));
                Response.Redirect(LibrarianList);
            }
            else
            {
                DatabaseHelper.Insert(@"
                insert into Librarian (LibraryId, LibraryCardNumber)
                values (@LibraryId, @LibraryCardNumber);
            ",
              new SqlParameter("@LibraryCardNumber", patronId),
              new SqlParameter("@LibraryId", libraryId)
              );

                DatabaseHelper.Update(@"
                update Patron set
                    Password = @Password,
                    RoleId = 2
                where LibraryCardNumber = @LibraryCardNumber
                ",
                new SqlParameter("@LibraryCardNumber", patronId),
                new SqlParameter("@Password", hashedPassword));

                Response.Redirect(Request.RawUrl);
            }


        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(LibrarianList);
        }


        protected int SelectPatron()
        {
            return int.Parse(Patrons.SelectedValue);
        }

        protected int SelectLibrary()
        {
            return int.Parse(Libraries.SelectedValue);
        }
    }
}