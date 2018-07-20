namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedAccessDateType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Paste", "AccessDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Paste", "AccessDate", c => c.DateTime(nullable: false, storeType: "date"));
        }
    }
}
