namespace PluSystemVolunteer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lista : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ListasPresencaEvento", "Validada", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ListasPresencaEvento", "Validada");
        }
    }
}
