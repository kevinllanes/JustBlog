using System;

namespace JustBlog.Model
{
    public class Page
    {
        public int PageId { get; set; }
        public string Title { get; set; }
        public string PagesContent { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        //public int UserId { get; set; }
        //public User User { get; set; }
    }
}
