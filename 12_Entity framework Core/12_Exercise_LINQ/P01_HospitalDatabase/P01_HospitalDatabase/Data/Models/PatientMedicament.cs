using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P01_HospitalDatabase.Data.Models
{
    public class PatientMedicament
    {
        [ForeignKey(nameof(Patient))]
       // [Key]
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }

        [ForeignKey(nameof(Medicament))]
       // [Key]
        public int MedicamentId { get; set; }
        public virtual Medicament Medicament { get; set; }


    }
}
