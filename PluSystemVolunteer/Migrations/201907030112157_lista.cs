namespace PluSystemVolunteer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lista : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ListasPresencaEvento",
                c => new
                    {
                        ListaPresencaId = c.Int(nullable: false, identity: true),
                        Evento_EventoId = c.Int(),
                        Usuario_UsuarioId = c.Int(),
                    })
                .PrimaryKey(t => t.ListaPresencaId)
                .ForeignKey("dbo.Eventos", t => t.Evento_EventoId)
                .ForeignKey("dbo.Usuarios", t => t.Usuario_UsuarioId)
                .Index(t => t.Evento_EventoId)
                .Index(t => t.Usuario_UsuarioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ListasPresencaEvento", "Usuario_UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.ListasPresencaEvento", "Evento_EventoId", "dbo.Eventos");
            DropIndex("dbo.ListasPresencaEvento", new[] { "Usuario_UsuarioId" });
            DropIndex("dbo.ListasPresencaEvento", new[] { "Evento_EventoId" });
            DropTable("dbo.ListasPresencaEvento");
        }
    }
}
