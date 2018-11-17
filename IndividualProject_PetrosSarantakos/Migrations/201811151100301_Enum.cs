namespace IndividualProject_PetrosSarantakos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Enum : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "UserState", c => c.Int(nullable: false));
            DropColumn("dbo.Users", "IsAdmin");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "IsAdmin", c => c.Boolean(nullable: false));
            DropColumn("dbo.Users", "UserState");
        }
    }
}
