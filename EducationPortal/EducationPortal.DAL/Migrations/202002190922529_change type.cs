namespace EducationPortal.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changetype : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BaseMaterials", "Published", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BaseMaterials", "Published", c => c.String());
        }
    }
}
