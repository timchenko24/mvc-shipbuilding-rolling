namespace ShipbuildingRollingWeb.Models.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProvidersDB
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProvidersDB()
        {
            this.RollingDB = new HashSet<RollingDB>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RollingDB> RollingDB { get; set; }
    }
}
