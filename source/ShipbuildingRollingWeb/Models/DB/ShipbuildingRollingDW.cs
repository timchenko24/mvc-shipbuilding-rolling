namespace ShipbuildingRollingWeb.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ShipbuildingRollingDW : DbContext
    {
        public ShipbuildingRollingDW()
            : base("name=ShipbuildingRollingDW")
        {
        }

        public virtual DbSet<Main> Main { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Main>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Main>()
                .Property(e => e.Provider_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Main>()
                .Property(e => e.Rolling_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Main>()
                .Property(e => e.Document)
                .IsUnicode(false);

            modelBuilder.Entity<Main>()
                .Property(e => e.Form)
                .IsUnicode(false);

            modelBuilder.Entity<Main>()
                .Property(e => e.Processing)
                .IsUnicode(false);

            modelBuilder.Entity<Main>()
                .Property(e => e.Company_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Main>()
                .Property(e => e.Specialization)
                .IsUnicode(false);

            modelBuilder.Entity<Main>()
                .Property(e => e.Format)
                .IsUnicode(false);

            modelBuilder.Entity<Main>()
                .Property(e => e.Weekday)
                .IsUnicode(false);

            modelBuilder.Entity<Main>()
                .Property(e => e.Month)
                .IsUnicode(false);

            modelBuilder.Entity<Main>()
                .Property(e => e.BodyFragment_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Main>()
                .Property(e => e.Designation)
                .IsUnicode(false);
        }
    }
}
