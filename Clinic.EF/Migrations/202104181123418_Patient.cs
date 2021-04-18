namespace Clinic.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Patient : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Patient",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Token = c.String(),
                        Name = c.String(),
                        Sex = c.Int(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        Phone = c.String(),
                        Address = c.String(),
                        CityId = c.Byte(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        Height = c.String(),
                        Weight = c.String(),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patient", "CityId", "dbo.Cities");
            DropIndex("dbo.Patient", new[] { "CityId" });
            DropTable("dbo.Cities");
            DropTable("dbo.Patient");
        }
    }
}
