namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migratsioon3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "Time", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "Time");
        }
    }
}
