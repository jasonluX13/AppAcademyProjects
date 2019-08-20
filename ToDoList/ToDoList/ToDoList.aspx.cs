using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ToDoList
{
    public partial class ToDoList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            Tasks.DataSource = ToDoItemData.GetToDoItems();
            Tasks.DataBind();
            
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Description.Text))
            {
                ErrorMessage.Visible = true;
            }
            else
            {
                ToDoItemData.AddItem(Description.Text);
                Tasks.DataSource = ToDoItemData.GetToDoItems();
                Tasks.DataBind();
                Description.Text = string.Empty;
            }
           
        }
        protected void Tasks_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int index = int.Parse(e.CommandArgument.ToString());
            List<ToDoItem> todos = ToDoItemData.GetToDoItems();
            todos[index].Done = true;
            Tasks.DataSource = todos;
            Tasks.DataBind();
        }


    }
}