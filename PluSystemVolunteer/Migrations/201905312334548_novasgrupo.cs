namespace PluSystemVolunteer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class novasgrupo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Grupos",
                c => new
                    {
                        GrupoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        CEP = c.Int(nullable: false),
                        Endereco = c.String(),
                        Numero = c.Int(nullable: false),
                        Complemento = c.String(),
                        Bairro = c.String(),
                        Cidade = c.String(),
                        CriadoEm = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.GrupoId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Grupos");
        }
    }
}
