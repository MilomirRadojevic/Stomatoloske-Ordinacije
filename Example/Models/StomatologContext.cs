using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Example.Models
{
    public class StomatologContext : DbContext
    {
        public StomatologContext()
            : base("StomatologContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<Stomatolog>().HasKey(m => m.IDClanaKomore);
            builder.Entity<Ordinacija>().HasKey(m => m.MaticniBrojFirme);
            builder.Entity<Pacijent>().HasKey(m => m.IDKartona);
            builder.Entity<ZakazanaPoseta>().HasKey(m => m.IDZakazanePosete);
            builder.Entity<ObavljenaPoseta>().HasKey(m => m.IDPosete);
            builder.Entity<Poruka>().HasKey(m => m.IDPoruke);
            builder.Entity<KomentarNaObjavu>().HasKey(m => m.IDKomentara);
            builder.Entity<Objava>().HasKey(m => m.IDObjave);
            builder.Entity<OdgovorNaPoruku>().HasKey(m => m.IDOdgovora);
            builder.Entity<Pregled>().HasKey(m => m.IDPregleda);

            builder.Entity<Stomatolog>().HasRequired(m => m.OrdinacijaZaposlenog).WithMany(t => t.Zaposleni).HasForeignKey(m => m.OrdinacijaMaticniBrojFirme).WillCascadeOnDelete(false);
            builder.Entity<Pacijent>().HasRequired(m => m.IzabraniStomatolog).WithMany(t => t.Pacijenti).HasForeignKey(m => m.StomatologIDClanaKomore).WillCascadeOnDelete(false);
            builder.Entity<ObavljenaPoseta>().HasRequired(m => m.IzabraniStomatolog).WithMany(t => t.ObavljenePosete).HasForeignKey(m => m.StomatologIDClanaKomore).WillCascadeOnDelete(false);
            builder.Entity<ObavljenaPoseta>().HasRequired(m => m.PregledaniPacijent).WithMany(t => t.ObavljenePosete).HasForeignKey(m => m.PacijentIDKartona).WillCascadeOnDelete(false);
            builder.Entity<Pregled>().HasRequired(m => m.Poseta).WithOptional(t => t.ObavljeniPregled);
            builder.Entity<ZakazanaPoseta>().HasRequired(m => m.Zakazao).WithMany(t => t.ZakazanePosete).HasForeignKey(m => m.StomatologIDClanaKomore).WillCascadeOnDelete(false);
            builder.Entity<ZakazanaPoseta>().HasOptional(m => m.ZakazanPacijent).WithMany(t => t.ZakazanePosete);
            builder.Entity<Objava>().HasRequired(m => m.Objavio).WithMany(t => t.Objave).HasForeignKey(m => m.StomatologIDClanaKomore).WillCascadeOnDelete(false);
            builder.Entity<KomentarNaObjavu>().HasRequired(m => m.OriginalnaObjava).WithMany(t => t.KomentariNaObjavu).HasForeignKey(m => m.ObjavaIDObjave).WillCascadeOnDelete(false);
            builder.Entity<Poruka>().HasRequired(m => m.Primalac).WithMany(t => t.Primljene).HasForeignKey(m => m.StomatologPrimalacIDClanaKomore).WillCascadeOnDelete(false);
            builder.Entity<Poruka>().HasRequired(m => m.Salje).WithMany(t => t.Poslate).HasForeignKey(m => m.StomatologSaljeIDClanaKomore).WillCascadeOnDelete(false);
            builder.Entity<OdgovorNaPoruku>().HasRequired(m => m.OriginalnaPoruka).WithMany(t => t.OdgovoriNaPoruke).HasForeignKey(m => m.PorukaIDPoruke).WillCascadeOnDelete(false);
            builder.Entity<OdgovorNaPoruku>().HasRequired(m => m.Primalac).WithMany(t => t.OdgovoriNaPorukePrimljeno).HasForeignKey(m => m.StomatologPrimalacIDClanaKomore).WillCascadeOnDelete(false);
            builder.Entity<OdgovorNaPoruku>().HasRequired(m => m.Salje).WithMany(t => t.OdgovoriNaPorukePoslato).HasForeignKey(m => m.StomatologSaljeIDClanaKomore).WillCascadeOnDelete(false);
        }

        public virtual DbSet<Stomatolog> Stomatolozi { get; set; }
        public virtual DbSet<Pacijent> Pacijenti { get; set; }
        public virtual DbSet<Poruka> Poruke { get; set; }
        public virtual DbSet<OdgovorNaPoruku> OdgovoriNaPoruke { get; set; }
        public virtual DbSet<Objava> Objave { get; set; }
        public virtual DbSet<KomentarNaObjavu> KomentariNaObjave { get; set; }
        public virtual DbSet<Ordinacija> Ordinacije { get; set; }
        public virtual DbSet<Pregled> Pregledi { get; set; }
        public virtual DbSet<ZakazanaPoseta> ZakazanePosete { get; set; }
        public virtual DbSet<ObavljenaPoseta> ObavljenePosete { get; set; }
    }
}