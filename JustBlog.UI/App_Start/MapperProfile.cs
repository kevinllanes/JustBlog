using AutoMapper;
using JustBlog.Model;
using JustBlog.UI.Areas.Blog.Models;

namespace JustBlog.UI.App_Start
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            #region Pages
            CreateMap<Page, PageViewModel>().ReverseMap();
            #endregion
        }
    }
}