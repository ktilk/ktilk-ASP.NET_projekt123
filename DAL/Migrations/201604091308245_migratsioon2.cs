namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migratsioon2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Competitions", "DateStart", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Competitions", "DateEnd", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.People", "BirthDate", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.People", "DateCreated", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Plans", "DateCreated", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Plans", "DateClosed", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Workouts", "Date", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Exercises", "DateCreated", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Exercises", "DateCreated", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Workouts", "Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Plans", "DateClosed", c => c.DateTime());
            AlterColumn("dbo.Plans", "DateCreated", c => c.DateTime(nullable: false));
            AlterColumn("dbo.People", "DateCreated", c => c.DateTime());
            AlterColumn("dbo.People", "BirthDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Competitions", "DateEnd", c => c.DateTime());
            AlterColumn("dbo.Competitions", "DateStart", c => c.DateTime(nullable: false));
        }
    }
}
