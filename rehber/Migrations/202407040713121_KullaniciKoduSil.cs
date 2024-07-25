namespace rehber.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KullaniciKoduSil : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Kullanicis", "KullaniciKodu");
        }
        
        public override void Down()
        {
            
            DropIndex("dbo.Kişiler", new[] { "KullaniciId" });
            DropColumn("dbo.Kişiler", "KullaniciId");
        }
    }
}
