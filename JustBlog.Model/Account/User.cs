using System;
using System.Collections.Generic;

namespace JustBlog.Model.Account
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public DateTime LastLogin { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public IEnumerable<Role> RoleDetails { get; set; }

    }
}
