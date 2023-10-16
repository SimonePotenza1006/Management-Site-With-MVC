namespace TheLastBuildWeek.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_Ricovero
    {
        [Key]
        public int IDRicovero { get; set; }

        [Column(TypeName = "date")]
        public DateTime DataRicovero { get; set; }

        [Required]
        [StringLength(30)]
        public string DescrizioneRicovero { get; set; }

        public int FKIDAnimale { get; set; }

        public virtual T_Animali T_Animali { get; set; }
    }
}
