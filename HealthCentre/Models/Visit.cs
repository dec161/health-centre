namespace HealthCentre.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Visit")]
    public partial class Visit
    {
        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public int PatientId { get; set; }

        public int DoctorTypeId { get; set; }

        public virtual DoctorType DoctorType { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
