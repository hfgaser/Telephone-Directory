namespace rehber.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class YeniBisilerDegisti : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Kullanicis", "KullaniciKodu", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Kullanicis", "KullaniciKodu");
        }
    }
}
