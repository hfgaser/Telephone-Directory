namespace rehber.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KisiTableUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Kişiler", "KullaniciId", c => c.Int());
            CreateIndex("dbo.Kişiler", "KullaniciId");
            AddForeignKey("dbo.Kişiler", "KullaniciId", "dbo.Kullanicis", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Kişiler", "KullaniciId", "dbo.Kullanicis");
            DropIndex("dbo.Kişiler", new[] { "KullaniciId" });
            DropColumn("dbo.Kişiler", "KullaniciId");
        }
    }
}
