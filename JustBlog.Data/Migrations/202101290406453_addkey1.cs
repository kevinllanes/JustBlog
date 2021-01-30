namespace JustBlog.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addkey1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pages", "CreateTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pages", "CreateTime", c => c.DateTime(nullable: false));
        }
    }
}
