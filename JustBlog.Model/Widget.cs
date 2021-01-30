using JustBlog.Model.Account;
using System;

namespace JustBlog.Model
{
    public class Widget
    {
        public int WidgetId { get; set; }
        public string WidgetName { get; set; }
        public string WidgetContent { get; set; }
        public DateTime UpdateTime { get; set; }
        public int UserId { get; set; }
        public  User User { get; set; }
    }
}
