namespace ShipbuildingRollingWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Main")]
    public partial class Main
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(100)]
        public string Name { get; set; }

        [Key]
        [Column("Provider.Name", Order = 1)]
        [StringLength(100)]
        public string Provider_Name { get; set; }

        [Key]
        [Column("Rolling.ID", Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Rolling_ID { get; set; }

        [Key]
        [Column("Rolling.Name", Order = 3)]
        [StringLength(150)]
        public string Rolling_Name { get; set; }

        [StringLength(60)]
        public string Document { get; set; }

        [StringLength(20)]
        public string Form { get; set; }

        [StringLength(50)]
        public string Processing { get; set; }

        [Key]
        [Column("Company.Name", Order = 4)]
        [StringLength(100)]
        public string Company_Name { get; set; }

        [StringLength(80)]
        public string Specialization { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(50)]
        public string Format { get; set; }

        public int? SheetNumber { get; set; }

        public int? RollingNumber { get; set; }

        [Key]
        [Column(Order = 6, TypeName = "date")]
        public DateTime Date { get; set; }

        public int? Hour { get; set; }

        public int? Day { get; set; }

        public int? Week { get; set; }

        [StringLength(10)]
        public string Weekday { get; set; }

        [StringLength(10)]
        public string Month { get; set; }

        public int? Quarter { get; set; }

        public int? Year { get; set; }

        [Key]
        [Column("BodyFragment.Name", Order = 7)]
        [StringLength(100)]
        public string BodyFragment_Name { get; set; }

        [StringLength(80)]
        public string Designation { get; set; }
    }
}
