using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace TheLastBuildWeek.Models
{
    public partial class ModelDBContext : DbContext
    {
        public ModelDBContext()
            : base("name=ModelDBContext")
        {
        }

        public virtual DbSet<T_Animali> T_Animali { get; set; }
        public virtual DbSet<T_Clienti> T_Clienti { get; set; }
        public virtual DbSet<T_DittaFarmaceutica> T_DittaFarmaceutica { get; set; }
        public virtual DbSet<T_Prodotti> T_Prodotti { get; set; }
        public virtual DbSet<T_Ricovero> T_Ricovero { get; set; }
        public virtual DbSet<T_User> T_User { get; set; }
        public virtual DbSet<T_Vendita> T_Vendita { get; set; }
        public virtual DbSet<T_Visita> T_Visita { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<T_Animali>()
                .HasMany(e => e.T_Ricovero)
                .WithRequired(e => e.T_Animali)
                .HasForeignKey(e => e.FKIDAnimale)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<T_Animali>()
                .HasMany(e => e.T_Visita)
                .WithRequired(e => e.T_Animali)
                .HasForeignKey(e => e.FKIDAnimale)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<T_Clienti>()
                .HasMany(e => e.T_Vendita)
                .WithRequired(e => e.T_Clienti)
                .HasForeignKey(e => e.FKIDCliente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<T_DittaFarmaceutica>()
                .HasMany(e => e.T_Prodotti)
                .WithRequired(e => e.T_DittaFarmaceutica)
                .HasForeignKey(e => e.FKIDDitta)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<T_Prodotti>()
                .Property(e => e.Prezzo)
                .HasPrecision(19, 4);

            modelBuilder.Entity<T_Prodotti>()
                .HasMany(e => e.T_Vendita)
                .WithRequired(e => e.T_Prodotti)
                .HasForeignKey(e => e.FKIDProdotto)
                .WillCascadeOnDelete(false);
        }
    }
}
