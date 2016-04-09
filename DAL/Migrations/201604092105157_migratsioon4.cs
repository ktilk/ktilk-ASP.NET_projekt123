namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migratsioon4 : DbMigration
    {
        public override void Up()
        {
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
            
            AddColumn("dbo.Contacts", "ContactValue", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.ContactTypes", "ContactTypeNameID", c => c.Int(nullable: false));
            CreateIndex("dbo.ContactTypes", "ContactTypeNameID");
            AddForeignKey("dbo.ContactTypes", "ContactTypeNameID", "dbo.MultiLangStrings", "MultiLangStringID", cascadeDelete: true);
            DropColumn("dbo.Contacts", "Value");
            DropColumn("dbo.ContactTypes", "ContactTypeName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ContactTypes", "ContactTypeName", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Contacts", "Value", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.ContactTypes", "ContactTypeNameID", "dbo.MultiLangStrings");
            DropForeignKey("dbo.Translations", "MultiLangStringID", "dbo.MultiLangStrings");
            DropIndex("dbo.Translations", new[] { "MultiLangStringID" });
            DropIndex("dbo.ContactTypes", new[] { "ContactTypeNameID" });
            DropColumn("dbo.ContactTypes", "ContactTypeNameID");
            DropColumn("dbo.Contacts", "ContactValue");
            DropTable("dbo.Translations");
            DropTable("dbo.MultiLangStrings");
        }
    }
}
