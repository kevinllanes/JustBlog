namespace JustBlog.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                        Frequence = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        CommentContent = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(),
                        UserId = c.Int(nullable: false),
                        PostId = c.Int(nullable: false),
                        Publish = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        MiddleName = c.String(),
                        EmailAddress = c.String(),
                        Password = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(),
                        LastLogin = c.DateTime(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.EmailSettings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SMTPServer = c.String(),
                        Sender = c.String(),
                        SMTPServerPort = c.Int(nullable: false),
                        UserName = c.String(),
                        Password = c.String(),
                        EnableSSL = c.Boolean(nullable: false),
                        UserId = c.Int(nullable: false),
                        LastUpdate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Imagepath = c.String(),
                        Size = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Pages",
                c => new
                    {
                        PageId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        PagesContent = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                        Update_Time = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PageId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        PostContent = c.String(),
                        CreateTime = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                        Tags = c.String(),
                        CategoryId = c.Int(nullable: false),
                        Frequence = c.Int(nullable: false),
                        FeaturedImage = c.String(),
                    })
                .PrimaryKey(t => t.PostId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Settings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HomeImage = c.String(),
                        HomeTitle = c.String(),
                        NumberOfLasPost = c.Int(nullable: false),
                        NumberOfCatergory = c.Int(nullable: false),
                        PostNumberInPage = c.Int(nullable: false),
                        NumberOfTopPost = c.Int(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        UserRoleId = c.Int(nullable: false, identity: true),
                        RoleId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserRoleId);
            
            CreateTable(
                "dbo.Widgets",
                c => new
                    {
                        WidgetId = c.Int(nullable: false, identity: true),
                        WidgetName = c.String(),
                        WidgetContent = c.String(),
                        UpdateTime = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WidgetId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Widgets", "UserId", "dbo.Users");
            DropForeignKey("dbo.Settings", "UserId", "dbo.Users");
            DropForeignKey("dbo.Posts", "UserId", "dbo.Users");
            DropForeignKey("dbo.Posts", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Pages", "UserId", "dbo.Users");
            DropForeignKey("dbo.Images", "UserId", "dbo.Users");
            DropForeignKey("dbo.EmailSettings", "UserId", "dbo.Users");
            DropForeignKey("dbo.Comments", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropIndex("dbo.Widgets", new[] { "UserId" });
            DropIndex("dbo.Settings", new[] { "UserId" });
            DropIndex("dbo.Posts", new[] { "CategoryId" });
            DropIndex("dbo.Posts", new[] { "UserId" });
            DropIndex("dbo.Pages", new[] { "UserId" });
            DropIndex("dbo.Images", new[] { "UserId" });
            DropIndex("dbo.EmailSettings", new[] { "UserId" });
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropIndex("dbo.Comments", new[] { "UserId" });
            DropTable("dbo.Widgets");
            DropTable("dbo.UserRoles");
            DropTable("dbo.Settings");
            DropTable("dbo.Posts");
            DropTable("dbo.Pages");
            DropTable("dbo.Images");
            DropTable("dbo.EmailSettings");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.Comments");
            DropTable("dbo.Categories");
        }
    }
}
