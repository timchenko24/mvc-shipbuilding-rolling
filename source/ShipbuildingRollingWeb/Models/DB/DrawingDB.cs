namespace ShipbuildingRollingWeb.Models.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class DrawingDB
    {
        public int ID { get; set; }
        public int BodyFragmentID { get; set; }
        public int CompanyID { get; set; }
        public System.DateTime Data { get; set; }
        public string Format { get; set; }
    
        public virtual BodyFragmentDB BodyFragmentDB { get; set; }
        public virtual CompanyDB CompanyDB { get; set; }
    }
}
