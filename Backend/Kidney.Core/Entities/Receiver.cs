using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Kidney.Core.Entities
{
    public class Receiver
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public SEX Sex { get; set; }
        public RACE Race { get; set; }
        public BLOOD_TYPE BloodType { get; set; }
        public PRIMARY_DIAGNOSIS PrimaryDiagnosis { get; set; }
    }
}
