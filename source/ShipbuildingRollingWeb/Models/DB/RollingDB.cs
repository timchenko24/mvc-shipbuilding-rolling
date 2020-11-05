namespace ShipbuildingRollingWeb.Models.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class RollingDB
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RollingDB()
        {
            this.BodyFragmentDB = new HashSet<BodyFragmentDB>();
        }
    
        public int ID { get; set; }
        public int ProviderID { get; set; }
        public int ProducerID { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public string Form { get; set; }
        public string Processing { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BodyFragmentDB> BodyFragmentDB { get; set; }
        public virtual ProducerDB ProducerDB { get; set; }
        public virtual ProvidersDB ProvidersDB { get; set; }
    }
}
