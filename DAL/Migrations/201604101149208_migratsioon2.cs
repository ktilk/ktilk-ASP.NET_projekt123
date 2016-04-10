namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migratsioon2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Plans", "PlanDescriptionID", c => c.Int());
            AddColumn("dbo.Plans", "PlanInstructionsID", c => c.Int());
            AddColumn("dbo.ExerciseTypes", "ExerciseTypeNameID", c => c.Int());
            AddColumn("dbo.ExerciseTypes", "ExerciseTypeDescriptionID", c => c.Int());
            CreateIndex("dbo.Plans", "PlanDescriptionID");
            CreateIndex("dbo.Plans", "PlanInstructionsID");
            CreateIndex("dbo.ExerciseTypes", "ExerciseTypeNameID");
            CreateIndex("dbo.ExerciseTypes", "ExerciseTypeDescriptionID");
            AddForeignKey("dbo.Plans", "PlanDescriptionID", "dbo.MultiLangStrings", "MultiLangStringID");
            AddForeignKey("dbo.Plans", "PlanInstructionsID", "dbo.MultiLangStrings", "MultiLangStringID");
            AddForeignKey("dbo.ExerciseTypes", "ExerciseTypeDescriptionID", "dbo.MultiLangStrings", "MultiLangStringID");
            AddForeignKey("dbo.ExerciseTypes", "ExerciseTypeNameID", "dbo.MultiLangStrings", "MultiLangStringID");
            DropColumn("dbo.Plans", "Description");
            DropColumn("dbo.Plans", "Instructions");
            DropColumn("dbo.ExerciseTypes", "ExerciseTypeName");
            DropColumn("dbo.ExerciseTypes", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ExerciseTypes", "Description", c => c.String());
            AddColumn("dbo.ExerciseTypes", "ExerciseTypeName", c => c.String());
            AddColumn("dbo.Plans", "Instructions", c => c.String());
            AddColumn("dbo.Plans", "Description", c => c.String());
            DropForeignKey("dbo.ExerciseTypes", "ExerciseTypeNameID", "dbo.MultiLangStrings");
            DropForeignKey("dbo.ExerciseTypes", "ExerciseTypeDescriptionID", "dbo.MultiLangStrings");
            DropForeignKey("dbo.Plans", "PlanInstructionsID", "dbo.MultiLangStrings");
            DropForeignKey("dbo.Plans", "PlanDescriptionID", "dbo.MultiLangStrings");
            DropIndex("dbo.ExerciseTypes", new[] { "ExerciseTypeDescriptionID" });
            DropIndex("dbo.ExerciseTypes", new[] { "ExerciseTypeNameID" });
            DropIndex("dbo.Plans", new[] { "PlanInstructionsID" });
            DropIndex("dbo.Plans", new[] { "PlanDescriptionID" });
            DropColumn("dbo.ExerciseTypes", "ExerciseTypeDescriptionID");
            DropColumn("dbo.ExerciseTypes", "ExerciseTypeNameID");
            DropColumn("dbo.Plans", "PlanInstructionsID");
            DropColumn("dbo.Plans", "PlanDescriptionID");
        }
    }
}
