namespace ShipbuildingRollingWeb.Models.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class BodyFragmentDB
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BodyFragmentDB()
        {
            this.DrawingDB = new HashSet<DrawingDB>();
        }
    
        public int ID { get; set; }
        public int RollingID { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
    
        public virtual RollingDB RollingDB { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DrawingDB> DrawingDB { get; set; }
    }
}
