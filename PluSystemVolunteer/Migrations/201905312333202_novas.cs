namespace PluSystemVolunteer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class novas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategoriasEvento",
                c => new
                    {
                        CategoriaEventoId = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.CategoriaEventoId);
            
            CreateTable(
                "dbo.Eventos",
                c => new
                    {
                        EventoId = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                        Endereço = c.String(),
                        Preco = c.Double(nullable: false),
                        Data = c.DateTime(nullable: false),
                        Imagem = c.String(),
                        CategoriaEvento_CategoriaEventoId = c.Int(),
                    })
                .PrimaryKey(t => t.EventoId)
                .ForeignKey("dbo.CategoriasEvento", t => t.CategoriaEvento_CategoriaEventoId)
                .Index(t => t.CategoriaEvento_CategoriaEventoId);
            
            AddColumn("dbo.Usuarios", "Administrador", c => c.Boolean(nullable: false));
            AddColumn("dbo.Usuarios", "Imagem", c => c.String());
            AddColumn("dbo.Usuarios", "Pontuacao", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Usuarios", "Telefone", c => c.String());
            DropTable("dbo.Grupos");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Grupos",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Descricao = c.String(),
                        CriadoEm = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UsuarioId);
            
            DropForeignKey("dbo.Eventos", "CategoriaEvento_CategoriaEventoId", "dbo.CategoriasEvento");
            DropIndex("dbo.Eventos", new[] { "CategoriaEvento_CategoriaEventoId" });
            AlterColumn("dbo.Usuarios", "Telefone", c => c.Int(nullable: false));
            DropColumn("dbo.Usuarios", "Pontuacao");
            DropColumn("dbo.Usuarios", "Imagem");
            DropColumn("dbo.Usuarios", "Administrador");
            DropTable("dbo.Eventos");
            DropTable("dbo.CategoriasEvento");
        }
    }
}
