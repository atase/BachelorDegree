using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Kidney.DataAccess.Entities
{
    public enum PRIMARY_DIAGNOSIS
    {
        DIABETES,
        GLOMERULONEPHRITIS,
        HYPERTENSION,
        CYSTIC_KIDNEY_DISEASE,
        INTERSTITIAL_NEPHRITIS,
        OBSTRUCTIVE_NEPHROPATHY,
        OTHER,
        UNKNOWN,
        MISSING
    }
    public class PrimaryDiagnosis
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Receiver> Receivers { get; set; }
    }
}
