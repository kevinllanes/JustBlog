namespace JustBlog.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeuserforpostpagefornow : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posts", "UserId", "dbo.Users");
            DropIndex("dbo.Posts", new[] { "UserId" });
            AlterColumn("dbo.Posts", "UpdateTime", c => c.DateTime());
            DropColumn("dbo.Posts", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Posts", "UpdateTime", c => c.DateTime(nullable: false));
            CreateIndex("dbo.Posts", "UserId");
            AddForeignKey("dbo.Posts", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
        }
    }
}
