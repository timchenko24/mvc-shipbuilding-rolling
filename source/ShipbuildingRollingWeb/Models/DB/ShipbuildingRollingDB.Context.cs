namespace ShipbuildingRollingWeb.Models.DB
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class ShipbuildingRollingDBEntities : DbContext
    {
        public ShipbuildingRollingDBEntities()
            : base("name=ShipbuildingRollingDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BodyFragmentDB> BodyFragmentDB { get; set; }
        public virtual DbSet<CompanyDB> CompanyDB { get; set; }
        public virtual DbSet<DrawingDB> DrawingDB { get; set; }
        public virtual DbSet<ProducerDB> ProducerDB { get; set; }
        public virtual DbSet<ProvidersDB> ProvidersDB { get; set; }
        public virtual DbSet<RollingDB> RollingDB { get; set; }
    }
}
