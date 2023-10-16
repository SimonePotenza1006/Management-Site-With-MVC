namespace TheLastBuildWeek.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_Vendita
    {
        [Key]
        public int IDVendita { get; set; }

        public int FKIDCliente { get; set; }

        public int FKIDProdotto { get; set; }

        [StringLength(20)]
        public string NumeroRicetta { get; set; }

        [Column(TypeName = "date")]
        public DateTime DataVendita { get; set; }

        public virtual T_Clienti T_Clienti { get; set; }

        public virtual T_Prodotti T_Prodotti { get; set; }
    }
}
