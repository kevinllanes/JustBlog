using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustBlog.Model.Account
{
    public class Setting
    {
        public int Id { get; set; }
        public string HomeImage { get; set; }
        public string HomeTitle { get; set; }
        public int NumberOfLasPost { get; set; }
        public int NumberOfCatergory { get; set; }
        public int PostNumberInPage { get; set; }
        public int NumberOfTopPost { get; set; }
        public DateTime UpdateTime { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
