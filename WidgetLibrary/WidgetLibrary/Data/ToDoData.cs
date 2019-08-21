using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WidgetLibrary.Data
{
    public class ToDoData
    {
        private static List<ToDoItem> Items = new List<ToDoItem>();

        public static List<ToDoItem> GetToDoItems()
        {
            return Items;
        }

        public static void AddItem(string description)
        {
            Items.Add(new ToDoItem()
            {
                Description = description,
                Done = false
            });
        }
    }
}