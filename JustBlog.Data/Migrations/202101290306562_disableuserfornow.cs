namespace JustBlog.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class disableuserfornow : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pages", "UserId", "dbo.Users");
            DropIndex("dbo.Pages", new[] { "UserId" });
            AddColumn("dbo.Pages", "UpdateTime", c => c.DateTime());
            DropColumn("dbo.Pages", "Update_Time");
            DropColumn("dbo.Pages", "UserId");
            DropTable("dbo.UserRoles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        UserRoleId = c.Int(nullable: false, identity: true),
                        RoleId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserRoleId);
            
            AddColumn("dbo.Pages", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Pages", "Update_Time", c => c.DateTime(nullable: false));
            DropColumn("dbo.Pages", "UpdateTime");
            CreateIndex("dbo.Pages", "UserId");
            AddForeignKey("dbo.Pages", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
        }
    }
}
