namespace TheLastBuildWeek.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_Visita
    {
        [Key]
        public int IDVisita { get; set; }

        [Column(TypeName = "date")]
        public DateTime DataVisita { get; set; }

        [Required]
        [StringLength(30)]
        public string Esame { get; set; }

        [Required]
        [StringLength(50)]
        public string Descrizione { get; set; }
        [Display(Name = "Nome dell'animale")]
        public int FKIDAnimale { get; set; }

        public virtual T_Animali T_Animali { get; set; }
    }
}
