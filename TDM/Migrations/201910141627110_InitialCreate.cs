namespace TDM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        IdArticle = c.Int(nullable: false, identity: true),
                        URL = c.String(maxLength: 100),
                        Fecha = c.DateTime(nullable: false),
                        Nombre = c.String(maxLength: 100),
                        Body = c.String(),
                        ImgURL = c.String(),
                        IdUser = c.Int(nullable: false),
                        IdSection = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdArticle)
                .ForeignKey("dbo.Sections", t => t.IdSection, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.IdUser, cascadeDelete: true)
                .Index(t => t.IdUser)
                .Index(t => t.IdSection);
            
            CreateTable(
                "dbo.Sections",
                c => new
                    {
                        IdSection = c.Int(nullable: false, identity: true),
                        Nombre = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.IdSection);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        IdUser = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 70),
                        Nombre = c.String(maxLength: 50),
                        Apellido = c.String(maxLength: 50),
                        URL = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.IdUser);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Articles", "IdUser", "dbo.Users");
            DropForeignKey("dbo.Articles", "IdSection", "dbo.Sections");
            DropIndex("dbo.Articles", new[] { "IdSection" });
            DropIndex("dbo.Articles", new[] { "IdUser" });
            DropTable("dbo.Users");
            DropTable("dbo.Sections");
            DropTable("dbo.Articles");
        }
    }
}
