using JustBlog.Model.Account;
using System;

namespace JustBlog.Model
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string CommentContent { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public bool Publish { get; set; }
        public User User { get; set; }
    }
}
