namespace rehber.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CurrentIdEkle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Kişiler", "CurrentId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Kişiler", "CurrentId");
        }
    }
}
