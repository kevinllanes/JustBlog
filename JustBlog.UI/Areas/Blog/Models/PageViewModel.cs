using System;

namespace JustBlog.UI.Areas.Blog.Models
{
    public class PageViewModel
    {
        public int PageId { get; set; }
        public string Title { get; set; }
        public string PagesContent { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}