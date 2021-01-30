using System;

namespace JustBlog.Model.Account
{
    public class EmailSetting
    {
        public int Id { get; set; }
        public string SMTPServer { get; set; }
        public string Sender { get; set; }
        public int SMTPServerPort { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool EnableSSL { get; set; }
        public int UserId { get; set; }
        public DateTime LastUpdate { get; set; }
        public virtual User User { get; set; }
    }
}
