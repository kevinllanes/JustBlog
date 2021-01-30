using JustBlog.Model;
using JustBlog.Model.Account;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;

namespace JustBlog.Data
{
    public class JustBlogDbContext:DbContext
    {
        public JustBlogDbContext():base("name=JustBlogConString")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Post> Posts { get; set; }
        //public DbSet<User> Users { get; set; }
        //public DbSet<Role> Roles { get; set; }
        //public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Widget> Widgets { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<EmailSetting> EmailSettings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
       
    }
}
