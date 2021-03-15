using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DeerManager.Models
{
    public partial class DBModel : DbContext
    {
        public DBModel()
            : base("name=DBModel")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Details> Details { get; set; }
        public virtual DbSet<Diseases> Diseases { get; set; }
        public virtual DbSet<Hamlatot> Hamlatot { get; set; }
        public virtual DbSet<maintable> maintable { get; set; }
        public virtual DbSet<Settings> Settings { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Vaccinations> Vaccinations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hamlatot>()
                .Property(e => e.DateOfHamlata)
                .IsFixedLength();

            modelBuilder.Entity<Hamlatot>()
                .Property(e => e.DateOfTakser)
                .IsFixedLength();

            modelBuilder.Entity<maintable>()
                .Property(e => e.Blood)
                .IsFixedLength();

            modelBuilder.Entity<maintable>()
                .Property(e => e.Gender)
                .IsFixedLength();

            modelBuilder.Entity<maintable>()
                .Property(e => e.Birthday)
                .IsFixedLength();

            modelBuilder.Entity<maintable>()
                .HasOptional(e => e.Details)
                .WithRequired(e => e.maintable)
                .WillCascadeOnDelete();

            modelBuilder.Entity<maintable>()
                .HasOptional(e => e.Diseases)
                .WithRequired(e => e.maintable)
                .WillCascadeOnDelete();

            modelBuilder.Entity<maintable>()
                .HasOptional(e => e.Hamlatot)
                .WithRequired(e => e.maintable)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Settings>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Settings>()
                .Property(e => e.Email)
                .IsFixedLength();

            modelBuilder.Entity<Settings>()
                .Property(e => e.Password)
                .IsFixedLength();

            modelBuilder.Entity<Settings>()
                .Property(e => e.Address)
                .IsFixedLength();

            modelBuilder.Entity<Vaccinations>()
                .Property(e => e.DateOfVaccination)
                .IsFixedLength();

            modelBuilder.Entity<Vaccinations>()
                .Property(e => e.Medicine)
                .IsFixedLength();

            modelBuilder.Entity<Vaccinations>()
                .Property(e => e.NextVaccinationDate)
                .IsFixedLength();
        }
    }
}
