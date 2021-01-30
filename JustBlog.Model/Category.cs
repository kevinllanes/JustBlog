using System;

namespace JustBlog.Model
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public DateTime CreateTime { get; set; }
        public int? Frequence { get; set; }
    }
}
