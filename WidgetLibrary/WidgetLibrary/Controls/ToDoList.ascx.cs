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
        public int NumberOfRecordsToDisplay { get; set; }
        public string CategoryFilter { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateList();

            }

        }


        private void PopulateList()
        {
            TaskList.DataSource = GetDisplay();
            TaskList.DataBind();

        }

        private List<ToDoItem> GetDisplay()
        {
            List<ToDoItem> todos = ToDoData.GetToDoItems();
            List<ToDoItem> todosDisplay = new List<ToDoItem>();
            Debug.WriteLine(todos);

            if (NumberOfRecordsToDisplay > 0 && NumberOfRecordsToDisplay < todos.Count)
            {
                int index = 0;
                while (todosDisplay.Count < NumberOfRecordsToDisplay)
                {
                    if (string.IsNullOrWhiteSpace(CategoryFilter))
                    {
                        todosDisplay.Add(todos[index]);
                    }
                    else
                    {
                        if (todos[index].Category == CategoryFilter)
                        {
                            todosDisplay.Add(todos[index]);
                        }
                    }
                    index++;
                }
            }
            else if (!string.IsNullOrWhiteSpace(CategoryFilter))
            {
                int index = 0;
                while (index < todos.Count)
                {
                    if (todos[index].Category == CategoryFilter)
                    {
                        todosDisplay.Add(todos[index]);
                    }
                    index++;
                }
            }
            else
            {
                todosDisplay = todos;
            }
            return todosDisplay;
        }

        protected void TaskList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int index = int.Parse((string)e.CommandArgument);
            List<ToDoItem> todos = GetDisplay();
            todos[index].Done = true;
            PopulateList();
            Response.Redirect(Request.RawUrl);
        }
    }
}