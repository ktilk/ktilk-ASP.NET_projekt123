namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migratsioon3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PersonRoleInPlans", "RoleNameID", c => c.Int());
            AddColumn("dbo.PlanTypes", "PlanTypeNameID", c => c.Int());
            AddColumn("dbo.PlanTypes", "PlanTypeDescriptionID", c => c.Int());
            AlterColumn("dbo.Workouts", "Date", c => c.DateTime(nullable: false, storeType: "date"));
            CreateIndex("dbo.PersonRoleInPlans", "RoleNameID");
            CreateIndex("dbo.PlanTypes", "PlanTypeNameID");
            CreateIndex("dbo.PlanTypes", "PlanTypeDescriptionID");
            AddForeignKey("dbo.PersonRoleInPlans", "RoleNameID", "dbo.MultiLangStrings", "MultiLangStringID");
            AddForeignKey("dbo.PlanTypes", "PlanTypeDescriptionID", "dbo.MultiLangStrings", "MultiLangStringID");
            AddForeignKey("dbo.PlanTypes", "PlanTypeNameID", "dbo.MultiLangStrings", "MultiLangStringID");
            DropColumn("dbo.PersonRoleInPlans", "RoleName");
            DropColumn("dbo.PlanTypes", "PlanTypeName");
            DropColumn("dbo.PlanTypes", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PlanTypes", "Description", c => c.String());
            AddColumn("dbo.PlanTypes", "PlanTypeName", c => c.String());
            AddColumn("dbo.PersonRoleInPlans", "RoleName", c => c.String());
            DropForeignKey("dbo.PlanTypes", "PlanTypeNameID", "dbo.MultiLangStrings");
            DropForeignKey("dbo.PlanTypes", "PlanTypeDescriptionID", "dbo.MultiLangStrings");
            DropForeignKey("dbo.PersonRoleInPlans", "RoleNameID", "dbo.MultiLangStrings");
            DropIndex("dbo.PlanTypes", new[] { "PlanTypeDescriptionID" });
            DropIndex("dbo.PlanTypes", new[] { "PlanTypeNameID" });
            DropIndex("dbo.PersonRoleInPlans", new[] { "RoleNameID" });
            AlterColumn("dbo.Workouts", "Date", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            DropColumn("dbo.PlanTypes", "PlanTypeDescriptionID");
            DropColumn("dbo.PlanTypes", "PlanTypeNameID");
            DropColumn("dbo.PersonRoleInPlans", "RoleNameID");
        }
    }
}
