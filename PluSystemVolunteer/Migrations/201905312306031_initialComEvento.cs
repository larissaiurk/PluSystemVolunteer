namespace PluSystemVolunteer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialComEvento : DbMigration
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
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Senha = c.String(),
                        Nome = c.String(),
                        Apelido = c.String(),
                        DataNascimento = c.DateTime(nullable: false),
                        Telefone = c.String(),
                        Administrador = c.Boolean(nullable: false),
                        Imagem = c.String(),
                        Pontuacao = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CriadoEm = c.DateTime(nullable: false),
                        Grupo_GrupoId = c.Int(),
                    })
                .PrimaryKey(t => t.UsuarioId)
                .ForeignKey("dbo.Grupos", t => t.Grupo_GrupoId)
                .Index(t => t.Grupo_GrupoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usuarios", "Grupo_GrupoId", "dbo.Grupos");
            DropForeignKey("dbo.Eventos", "CategoriaEvento_CategoriaEventoId", "dbo.CategoriasEvento");
            DropIndex("dbo.Usuarios", new[] { "Grupo_GrupoId" });
            DropIndex("dbo.Eventos", new[] { "CategoriaEvento_CategoriaEventoId" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.Grupos");
            DropTable("dbo.Eventos");
            DropTable("dbo.CategoriasEvento");
        }
    }
}
