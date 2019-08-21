using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WidgetLibrary.Data;

namespace WidgetLibrary.Controls
{
    public partial class ToDoList : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            PopulateList();
  
        }


        private void PopulateList()
        {
            List<ToDoItem> todos = ToDoData.GetToDoItems();
            Debug.WriteLine(todos);

            TaskList.DataSource = todos;
            TaskList.DataBind();
        }

        protected void TaskList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int index = int.Parse((string)e.CommandArgument);
            List<ToDoItem> todos = ToDoData.GetToDoItems();
            todos[index].Done = true;
            PopulateList();

        }
    }
}