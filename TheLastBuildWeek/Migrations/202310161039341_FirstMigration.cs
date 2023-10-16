namespace TheLastBuildWeek.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.T_Animali",
                c => new
                    {
                        IDAnimale = c.Int(nullable: false, identity: true),
                        DataRegistrazione = c.DateTime(nullable: false, storeType: "date"),
                        NomeAnimale = c.String(nullable: false, maxLength: 20),
                        Tipologia = c.String(nullable: false, maxLength: 20),
                        Colore = c.String(nullable: false, maxLength: 20),
                        HasMicrochip = c.Boolean(nullable: false),
                        CodiceMicrochip = c.String(maxLength: 20),
                        NomeProprietario = c.String(maxLength: 20),
                        CognomeProprietario = c.String(maxLength: 20),
                        DataNascita = c.DateTime(nullable: false, storeType: "date"),
                        FotoAnimale = c.String(maxLength: 100),
                        IsSmarrito = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IDAnimale);
            
            CreateTable(
                "dbo.T_Ricovero",
                c => new
                    {
                        IDRicovero = c.Int(nullable: false, identity: true),
                        DataRicovero = c.DateTime(nullable: false, storeType: "date"),
                        DescrizioneRicovero = c.String(nullable: false, maxLength: 30),
                        FKIDAnimale = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDRicovero)
                .ForeignKey("dbo.T_Animali", t => t.FKIDAnimale)
                .Index(t => t.FKIDAnimale);
            
            CreateTable(
                "dbo.T_Visita",
                c => new
                    {
                        IDVisita = c.Int(nullable: false, identity: true),
                        DataVisita = c.DateTime(nullable: false, storeType: "date"),
                        Esame = c.String(nullable: false, maxLength: 30),
                        Descrizione = c.String(nullable: false, maxLength: 50),
                        FKIDAnimale = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDVisita)
                .ForeignKey("dbo.T_Animali", t => t.FKIDAnimale)
                .Index(t => t.FKIDAnimale);
            
            CreateTable(
                "dbo.T_Clienti",
                c => new
                    {
                        IDCliente = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 20),
                        Cognome = c.String(nullable: false, maxLength: 20),
                        CodiceFiscale = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.IDCliente);
            
            CreateTable(
                "dbo.T_Vendita",
                c => new
                    {
                        IDVendita = c.Int(nullable: false, identity: true),
                        FKIDCliente = c.Int(nullable: false),
                        FKIDProdotto = c.Int(nullable: false),
                        NumeroRicetta = c.String(maxLength: 20),
                        DataVendita = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.IDVendita)
                .ForeignKey("dbo.T_Prodotti", t => t.FKIDProdotto)
                .ForeignKey("dbo.T_Clienti", t => t.FKIDCliente)
                .Index(t => t.FKIDCliente)
                .Index(t => t.FKIDProdotto);
            
            CreateTable(
                "dbo.T_Prodotti",
                c => new
                    {
                        IDProdotto = c.Int(nullable: false, identity: true),
                        NomeProdotto = c.String(nullable: false, maxLength: 20),
                        FKIDDitta = c.Int(nullable: false),
                        Prezzo = c.Decimal(storeType: "money"),
                        Descrizione = c.String(nullable: false, maxLength: 30),
                        NumArmadietto = c.Int(nullable: false),
                        NumCassetto = c.Int(nullable: false),
                        TipoProdotto = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.IDProdotto)
                .ForeignKey("dbo.T_DittaFarmaceutica", t => t.FKIDDitta)
                .Index(t => t.FKIDDitta);
            
            CreateTable(
                "dbo.T_DittaFarmaceutica",
                c => new
                    {
                        IDDitta = c.Int(nullable: false, identity: true),
                        Recapito = c.String(nullable: false, maxLength: 20),
                        Nome = c.String(nullable: false, maxLength: 20),
                        Indirizzo = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.IDDitta);
            
            CreateTable(
                "dbo.T_User",
                c => new
                    {
                        IDUser = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false, maxLength: 20),
                        Role = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.IDUser);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.T_Vendita", "FKIDCliente", "dbo.T_Clienti");
            DropForeignKey("dbo.T_Vendita", "FKIDProdotto", "dbo.T_Prodotti");
            DropForeignKey("dbo.T_Prodotti", "FKIDDitta", "dbo.T_DittaFarmaceutica");
            DropForeignKey("dbo.T_Visita", "FKIDAnimale", "dbo.T_Animali");
            DropForeignKey("dbo.T_Ricovero", "FKIDAnimale", "dbo.T_Animali");
            DropIndex("dbo.T_Prodotti", new[] { "FKIDDitta" });
            DropIndex("dbo.T_Vendita", new[] { "FKIDProdotto" });
            DropIndex("dbo.T_Vendita", new[] { "FKIDCliente" });
            DropIndex("dbo.T_Visita", new[] { "FKIDAnimale" });
            DropIndex("dbo.T_Ricovero", new[] { "FKIDAnimale" });
            DropTable("dbo.T_User");
            DropTable("dbo.T_DittaFarmaceutica");
            DropTable("dbo.T_Prodotti");
            DropTable("dbo.T_Vendita");
            DropTable("dbo.T_Clienti");
            DropTable("dbo.T_Visita");
            DropTable("dbo.T_Ricovero");
            DropTable("dbo.T_Animali");
        }
    }
}
