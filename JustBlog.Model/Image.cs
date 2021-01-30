using JustBlog.Model.Account;
using System;

namespace JustBlog.Model
{
    public class Image
    {
        public int Id { get; set; }
        public string Imagepath { get; set; }
        public int Size { get; set; }
        public DateTime CreateTime { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
