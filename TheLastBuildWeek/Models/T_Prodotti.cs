namespace TheLastBuildWeek.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_Prodotti
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T_Prodotti()
        {
            T_Vendita = new HashSet<T_Vendita>();
        }
        [Display(Name = "Codice Identificativo")]
        [Key]
        public int IDProdotto { get; set; }
        [Display(Name =" Prodotto:")]
        [Required]
        [StringLength(20)]
        public string NomeProdotto { get; set; }
        [Display(Name ="Ditta Farmaceutica: ")]
        public int FKIDDitta { get; set; }
        [Display(Name =" Prezzo")]
        [Column(TypeName = "money")]
        public decimal? Prezzo { get; set; }
        [Display(Name ="Descrizione:")]
        [Required]
        [StringLength(30)]
        public string Descrizione { get; set; }
        [Display(Name ="Armadietto: ")]
        public int NumArmadietto { get; set; }
        [Display(Name ="Cassetto: ")]
        public int NumCassetto { get; set; }

        [Required]
        [StringLength(20)]
        public string TipoProdotto { get; set; }

        public virtual T_DittaFarmaceutica T_DittaFarmaceutica { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_Vendita> T_Vendita { get; set; }
    }
}
