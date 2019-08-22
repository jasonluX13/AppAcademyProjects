using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WidgetLibrary.Data
{
    public class ToDoData
    {
        private static List<ToDoItem> Items = new List<ToDoItem>();
        private static List<string> Categories = new List<string>();

        public static List<ToDoItem> GetToDoItems()
        {
            return Items;
        }

        public static List<string> GetCategories()
        {
            if (Categories.Count == 0)
            {
                Categories.Add("Personal");
                Categories.Add("Work");
                Categories.Add("Chores");
                Categories.Add("Misc");
            }

            return Categories;
        }

        public static void AddItem(string description, string category)
        {
            Items.Add(new ToDoItem()
            {
                Description = description,
                Done = false,
                Category = category
            });
        }
    }
}