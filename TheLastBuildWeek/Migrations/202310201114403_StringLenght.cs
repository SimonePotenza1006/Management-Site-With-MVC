namespace TheLastBuildWeek.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StringLenght : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.T_DittaFarmaceutica", "Recapito", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.T_DittaFarmaceutica", "Nome", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.T_DittaFarmaceutica", "Indirizzo", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.T_DittaFarmaceutica", "Indirizzo", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.T_DittaFarmaceutica", "Nome", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.T_DittaFarmaceutica", "Recapito", c => c.String(nullable: false, maxLength: 20));
        }
    }
}
