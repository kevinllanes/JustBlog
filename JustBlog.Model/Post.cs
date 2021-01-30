using JustBlog.Model.Account;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace JustBlog.Model
{
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string PostContent { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public int UserId { get; set; }
        public string Tags { get; set; }
        public int CategoryId { get; set; }
        public int Frequence { get; set; }
        public string FeaturedImage { get; set; }
        public User User { get; set; }
        public Category Category { get; set; }
        public IEnumerable<Category> CategoryDetails { get; set; }


        // Slug generation taken from http://stackoverflow.com/questions/2920744/url-slugify-algorithm-in-c
        public string GenerateSlug()
        {
            string phrase = string.Format("{0}-{1}", PostId, Title);

            string str = RemoveAccent(phrase).ToLower();
            // invalid chars           
            str = Regex.Replace(str, @"[^a-z0-9\s-]", "");
            // convert multiple spaces into one space   
            str = Regex.Replace(str, @"\s+", " ").Trim();
            // cut and trim 
            str = str.Substring(0, str.Length <= 45 ? str.Length : 45).Trim();
            str = Regex.Replace(str, @"\s", "-"); // hyphens   
            return str;
        }

        private string RemoveAccent(string text)
        {
            byte[] bytes = System.Text.Encoding.GetEncoding("Cyrillic").GetBytes(text);
            return System.Text.Encoding.ASCII.GetString(bytes);
        }
    }
}
