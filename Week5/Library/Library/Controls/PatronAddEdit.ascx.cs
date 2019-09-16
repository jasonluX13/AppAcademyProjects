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
    public partial class PatronAddEdit : BaseControl
    {
        int patronId = 0;
        public bool edit { get; set; }
        public string PatronList { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (edit)
            {
                AddOrEdit.Text = "Edit Patron";
                if (!int.TryParse(Request.QueryString["ID"], out patronId))
                {
                    Response.Redirect(PatronList);
                }

                if (!IsPostBack)
                {
                    DataTable dt = DatabaseHelper.Retrieve(@"
                    select FirstName, LastName, Email, Address, Zipcode, State
                    from Patron
                    where LibraryCardNumber = @PatronId
                ", new SqlParameter("@PatronId", patronId));

                    if (dt.Rows.Count == 1)
                    {
                        FirstName.Text = dt.Rows[0].Field<string>("FirstName");
                        LastName.Text = dt.Rows[0].Field<string>("LastName");
                        Email.Text = dt.Rows[0].Field<string>("Email");
                        Address.Text = dt.Rows[0].Field<string>("Address");
                        Zipcode.Text = dt.Rows[0].Field<string>("Zipcode");
                        State.Text = dt.Rows[0].Field<string>("State");
                    }
                    else
                    {
                        Response.Redirect(PatronList);
                    }
                }
            }
            else
            {
                AddOrEdit.Text = "Add Patron";
            }
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            string firstName = FirstName.Text;
            string lastName = LastName.Text;
            string email = Email.Text;
            string address = Address.Text;
            string zipcode = Zipcode.Text;
            string state = State.Text;
            string password = Password.Text;
            string hashedPassword = Hashing.HashPassword(password);

            if (edit)
            {
                DatabaseHelper.Update(@"
                    update Patron set
                        FirstName = @FirstName,
                        LastName = @LastName,
                        Email = @Email,
                        Address = @Address,
                        Zipcode = @Zipcode,
                        State = @State,
                        Password = @Password
                    where LibraryCardNumber = @PatronId
                ",
                new SqlParameter("@FirstName", firstName),
                new SqlParameter("@LastName", lastName),
                new SqlParameter("@Email", email),
                new SqlParameter("@Address", address),
                new SqlParameter("@PatronId", patronId),
                new SqlParameter("@State", state),
                new SqlParameter("@Password", hashedPassword),
                new SqlParameter("@Zipcode", zipcode));
            }
            else
            {
                DatabaseHelper.Insert(@"
                insert into Patron (FirstName, LastName, Email, Address, Zipcode, State, Password, RoleId)
                values (@FirstName, @LastName, @Email, @Address, @Zipcode, @State, @Password, 1);
            ",
              new SqlParameter("@FirstName", firstName),
              new SqlParameter("@LastName", lastName),
              new SqlParameter("@Email", email),
              new SqlParameter("@Zipcode", zipcode),
              new SqlParameter("@State", state),
              new SqlParameter("@Password", hashedPassword),
              new SqlParameter("@Address", address));

            }

            Response.Redirect(PatronList);
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(PatronList);
        }

    }
}