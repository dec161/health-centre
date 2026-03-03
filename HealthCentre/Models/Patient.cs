namespace HealthCentre.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Patient")]
    public partial class Patient
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Patient()
        {
            Visit = new HashSet<Visit>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public int GenderId { get; set; }

        [Column(TypeName = "date")]
        public DateTime BirthDate { get; set; }

        [Required]
        [StringLength(255)]
        public string InsuranceCertificate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Fluorography { get; set; }

        [Column(TypeName = "date")]
        public DateTime? HealthAssessment { get; set; }

        public int Height { get; set; }

        public int Weight { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DisabilityGroupI { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DisabilityGroupII { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DisabilityGroupIII { get; set; }

        public int? PhotoId { get; set; }

        public virtual Gender Gender { get; set; }

        public virtual Photo Photo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Visit> Visit { get; set; }
    }
}
