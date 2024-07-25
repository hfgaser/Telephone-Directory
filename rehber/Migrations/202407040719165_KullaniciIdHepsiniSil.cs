namespace rehber.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KullaniciIdHepsiniSil : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Kişiler", "KullaniciId", "dbo.Kullanicis");
            DropIndex("dbo.Kişiler", new[] { "KullaniciId" });
            DropColumn("dbo.Kişiler", "KullaniciKodu");
            
        }
        
        public override void Down()
        {
            
            AddColumn("dbo.Kişiler", "KullaniciKodu", c => c.String());
        }
    }
}
