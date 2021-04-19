namespace Clinic.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class P1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Patient", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Patient", "Name", c => c.String());
        }
    }
}
