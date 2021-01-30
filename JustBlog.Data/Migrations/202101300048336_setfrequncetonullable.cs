namespace JustBlog.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class setfrequncetonullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "Frequence", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Categories", "Frequence", c => c.Int(nullable: false));
        }
    }
}
