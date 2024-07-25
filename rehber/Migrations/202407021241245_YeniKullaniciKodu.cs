namespace rehber.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class YeniKullaniciKodu : DbMigration
    {
        public override void Up()
        {
            
            AddColumn("dbo.Kişiler", "KullaniciKodu", c => c.String());
        }
        
        public override void Down()
        {
            
            DropColumn("dbo.Kişiler", "KullaniciKodu");
            
        }
    }
}
