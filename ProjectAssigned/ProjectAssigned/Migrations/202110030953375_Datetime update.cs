namespace ProjectAssigned.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Datetimeupdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "JoinDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "JoinDate", c => c.String());
        }
    }
}
