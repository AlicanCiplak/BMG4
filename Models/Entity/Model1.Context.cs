//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SekerWeb.Models.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DiyabetimEntities : DbContext
    {
        public DiyabetimEntities()
            : base("name=DiyabetimEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Besin> Besin { get; set; }
        public virtual DbSet<DoktorHasta> DoktorHasta { get; set; }
        public virtual DbSet<Duyuru> Duyuru { get; set; }
        public virtual DbSet<Hasta> Hasta { get; set; }
        public virtual DbSet<Hekim> Hekim { get; set; }
        public virtual DbSet<İletisim> İletisim { get; set; }
        public virtual DbSet<Kategori> Kategori { get; set; }
        public virtual DbSet<Marka> Marka { get; set; }
        public virtual DbSet<Mesaj> Mesaj { get; set; }
        public virtual DbSet<Sekerlerim> Sekerlerim { get; set; }
        public virtual DbSet<Sepetim> Sepetim { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TestAtama> TestAtama { get; set; }
        public virtual DbSet<Urun> Urun { get; set; }
        public virtual DbSet<Yönetici> Yönetici { get; set; }
    }
}
