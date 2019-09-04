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
    public partial class LibraryAddEdit : BaseControl
    {
        int libraryId = 0;
        public bool edit { get; set; }
        public string LibraryList { get; set; }

        protected void Page_Init(object sender, EventArgs e)
        {
            if (!CustomUser.IsLibrarian)
            {
                Response.Redirect("~/NotAuthorized.aspx");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (edit)
            {
                AddOrEdit.Text = "Edit Author";
                if (!int.TryParse(Request.QueryString["ID"], out libraryId))
                {
                    Response.Redirect(LibraryList);
                }

                if (!IsPostBack)
                {
                    DataTable dt = DatabaseHelper.Retrieve(@"
                    select BranchName, Address, Zipcode, State
                    from Library
                    where Id = @LibraryId
                ", new SqlParameter("@LibraryId", libraryId));

                    if (dt.Rows.Count == 1)
                    {
                        BranchName.Text = dt.Rows[0].Field<string>("BranchName");
                        Address.Text = dt.Rows[0].Field<string>("Address");
                        Zipcode.Text = dt.Rows[0].Field<string>("Zipcode");
                        State.Text = dt.Rows[0].Field<string>("State");
                    }
                    else
                    {
                        Response.Redirect(LibraryList);
                    }
                }
            }
            else
            {
                AddOrEdit.Text = "Add Library";
            }
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            string branchName = BranchName.Text;
            string address = Address.Text;
            string zipcode = Zipcode.Text;
            string state = State.Text;

            if (edit)
            {
                DatabaseHelper.Update(@"
                update Library set
                    BranchName = @BranchName,
                    Address = @Address,
                    Zipcode = @Zipcode,
                    State = @State
                where Id = @LibraryId
            ",
                new SqlParameter("@BranchName", branchName),
                new SqlParameter("@Address", address),
                new SqlParameter("@LibraryId", libraryId),
                new SqlParameter("@State", state),
                new SqlParameter("@Zipcode", zipcode));
            }
            else
            {
                int? id = DatabaseHelper.Insert(@"
                insert into Library (BranchName, Address, Zipcode, State)
                values (@BranchName, @Address, @Zipcode, @State);
            ",
              new SqlParameter("@BranchName", branchName),
              new SqlParameter("@Zipcode", zipcode),
              new SqlParameter("@State", state),
              new SqlParameter("@Address", address));

            }

            Response.Redirect(LibraryList);
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(LibraryList);
        }
    }
}