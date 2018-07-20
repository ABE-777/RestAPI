namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Paste", "Identifier", c => c.String(nullable: false, maxLength: 20, unicode: false));
            AlterColumn("dbo.Paste", "CreateDate", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.Paste", "AccessDate", c => c.DateTime(nullable: false, storeType: "date"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Paste", "AccessDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Paste", "CreateDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Paste", "Identifier", c => c.String(nullable: false, storeType: "ntext"));
        }
    }
}
