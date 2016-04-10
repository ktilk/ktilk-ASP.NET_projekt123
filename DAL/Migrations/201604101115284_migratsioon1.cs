namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migratsioon1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Plans", "PersonID", "dbo.People");
            DropIndex("dbo.Plans", new[] { "PersonID" });
            RenameColumn(table: "dbo.Plans", name: "PersonID", newName: "Person_PersonID");
            CreateTable(
                "dbo.MultiLangStrings",
                c => new
                    {
                        MultiLangStringID = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                        Owner = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.MultiLangStringID);
            
            CreateTable(
                "dbo.Translations",
                c => new
                    {
                        TranslationID = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                        MultiLangStringID = c.Int(nullable: false),
                        Culture = c.String(maxLength: 12),
                    })
                .PrimaryKey(t => t.TranslationID)
                .ForeignKey("dbo.MultiLangStrings", t => t.MultiLangStringID, cascadeDelete: true)
                .Index(t => t.MultiLangStringID);
            
            CreateTable(
                "dbo.PersonInPlans",
                c => new
                    {
                        PersonInPlanID = c.Int(nullable: false, identity: true),
                        PersonID = c.Int(nullable: false),
                        PlanID = c.Int(nullable: false),
                        PersonRoleInPlanID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PersonInPlanID)
                .ForeignKey("dbo.People", t => t.PersonID, cascadeDelete: true)
                .ForeignKey("dbo.PersonRoleInPlans", t => t.PersonRoleInPlanID, cascadeDelete: true)
                .ForeignKey("dbo.Plans", t => t.PlanID, cascadeDelete: true)
                .Index(t => t.PersonID)
                .Index(t => t.PlanID)
                .Index(t => t.PersonRoleInPlanID);
            
            CreateTable(
                "dbo.PersonRoleInPlans",
                c => new
                    {
                        PersonRoleInPlanID = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.PersonRoleInPlanID);
            
            AddColumn("dbo.Competitions", "CompetitionDescriptionID", c => c.Int(nullable: false));
            AddColumn("dbo.People", "Time", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.Contacts", "ContactValue", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.ContactTypes", "ContactTypeNameID", c => c.Int(nullable: false));
            AddColumn("dbo.Plans", "PlanNameID", c => c.Int(nullable: false));
            AlterColumn("dbo.Competitions", "CompetitionName", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Competitions", "DateStart", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Competitions", "DateEnd", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.People", "FirstName", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.People", "LastName", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.People", "BirthDate", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.People", "DateCreated", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Plans", "DateCreated", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Plans", "DateClosed", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Plans", "Person_PersonID", c => c.Int());
            AlterColumn("dbo.Workouts", "Date", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Exercises", "ExerciseName", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Exercises", "VideoUrl", c => c.String(maxLength: 512));
            AlterColumn("dbo.Exercises", "DateCreated", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            CreateIndex("dbo.Competitions", "CompetitionDescriptionID");
            CreateIndex("dbo.ContactTypes", "ContactTypeNameID");
            CreateIndex("dbo.Plans", "PlanNameID");
            CreateIndex("dbo.Plans", "Person_PersonID");
            AddForeignKey("dbo.Competitions", "CompetitionDescriptionID", "dbo.MultiLangStrings", "MultiLangStringID", cascadeDelete: true);
            AddForeignKey("dbo.ContactTypes", "ContactTypeNameID", "dbo.MultiLangStrings", "MultiLangStringID", cascadeDelete: true);
            AddForeignKey("dbo.Plans", "PlanNameID", "dbo.MultiLangStrings", "MultiLangStringID", cascadeDelete: true);
            AddForeignKey("dbo.Plans", "Person_PersonID", "dbo.People", "PersonID");
            DropColumn("dbo.Contacts", "Value");
            DropColumn("dbo.ContactTypes", "ContactTypeName");
            DropColumn("dbo.Plans", "PlanName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Plans", "PlanName", c => c.String());
            AddColumn("dbo.ContactTypes", "ContactTypeName", c => c.String());
            AddColumn("dbo.Contacts", "Value", c => c.String());
            DropForeignKey("dbo.Plans", "Person_PersonID", "dbo.People");
            DropForeignKey("dbo.Plans", "PlanNameID", "dbo.MultiLangStrings");
            DropForeignKey("dbo.PersonInPlans", "PlanID", "dbo.Plans");
            DropForeignKey("dbo.PersonInPlans", "PersonRoleInPlanID", "dbo.PersonRoleInPlans");
            DropForeignKey("dbo.PersonInPlans", "PersonID", "dbo.People");
            DropForeignKey("dbo.ContactTypes", "ContactTypeNameID", "dbo.MultiLangStrings");
            DropForeignKey("dbo.Competitions", "CompetitionDescriptionID", "dbo.MultiLangStrings");
            DropForeignKey("dbo.Translations", "MultiLangStringID", "dbo.MultiLangStrings");
            DropIndex("dbo.PersonInPlans", new[] { "PersonRoleInPlanID" });
            DropIndex("dbo.PersonInPlans", new[] { "PlanID" });
            DropIndex("dbo.PersonInPlans", new[] { "PersonID" });
            DropIndex("dbo.Plans", new[] { "Person_PersonID" });
            DropIndex("dbo.Plans", new[] { "PlanNameID" });
            DropIndex("dbo.ContactTypes", new[] { "ContactTypeNameID" });
            DropIndex("dbo.Translations", new[] { "MultiLangStringID" });
            DropIndex("dbo.Competitions", new[] { "CompetitionDescriptionID" });
            AlterColumn("dbo.Exercises", "DateCreated", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Exercises", "VideoUrl", c => c.String());
            AlterColumn("dbo.Exercises", "ExerciseName", c => c.String());
            AlterColumn("dbo.Workouts", "Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Plans", "Person_PersonID", c => c.Int(nullable: false));
            AlterColumn("dbo.Plans", "DateClosed", c => c.DateTime());
            AlterColumn("dbo.Plans", "DateCreated", c => c.DateTime(nullable: false));
            AlterColumn("dbo.People", "DateCreated", c => c.DateTime());
            AlterColumn("dbo.People", "BirthDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.People", "LastName", c => c.String());
            AlterColumn("dbo.People", "FirstName", c => c.String());
            AlterColumn("dbo.Competitions", "DateEnd", c => c.DateTime());
            AlterColumn("dbo.Competitions", "DateStart", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Competitions", "CompetitionName", c => c.String());
            DropColumn("dbo.Plans", "PlanNameID");
            DropColumn("dbo.ContactTypes", "ContactTypeNameID");
            DropColumn("dbo.Contacts", "ContactValue");
            DropColumn("dbo.People", "Time");
            DropColumn("dbo.Competitions", "CompetitionDescriptionID");
            DropTable("dbo.PersonRoleInPlans");
            DropTable("dbo.PersonInPlans");
            DropTable("dbo.Translations");
            DropTable("dbo.MultiLangStrings");
            RenameColumn(table: "dbo.Plans", name: "Person_PersonID", newName: "PersonID");
            CreateIndex("dbo.Plans", "PersonID");
            AddForeignKey("dbo.Plans", "PersonID", "dbo.People", "PersonID", cascadeDelete: true);
        }
    }
}
