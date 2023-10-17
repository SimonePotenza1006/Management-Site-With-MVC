namespace TheLastBuildWeek.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    public partial class T_Animali
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T_Animali()
        {
            T_Ricovero = new HashSet<T_Ricovero>();
            T_Visita = new HashSet<T_Visita>();
        }

        [Key]
        public int IDAnimale { get; set; }

        [Column(TypeName = "date")]
        public DateTime DataRegistrazione { get; set; }

        [Required]
        [StringLength(20)]
        public string NomeAnimale { get; set; }

        [Required]
        [StringLength(20)]
        public string Tipologia { get; set; }

        [Required]
        [StringLength(20)]
        public string Colore { get; set; }

        public bool HasMicrochip { get; set; }

        [StringLength(20)]
        public string CodiceMicrochip { get; set; }

        [StringLength(20)]
        public string NomeProprietario { get; set; }

        [StringLength(20)]
        public string CognomeProprietario { get; set; }

        [Column(TypeName = "date")]
        public DateTime DataNascita { get; set; }

        [NotMapped]
        public HttpPostedFileBase Immagine { get; set; }

        [StringLength(100)]
        public string FotoAnimale { get; set; }

        public bool IsSmarrito { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_Ricovero> T_Ricovero { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_Visita> T_Visita { get; set; }
    }
}
