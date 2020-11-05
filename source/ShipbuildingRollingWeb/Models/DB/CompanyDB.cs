namespace ShipbuildingRollingWeb.Models.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class CompanyDB
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CompanyDB()
        {
            this.DrawingDB = new HashSet<DrawingDB>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Specialization { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DrawingDB> DrawingDB { get; set; }
    }
}
