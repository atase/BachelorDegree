
using DataAccess.Entities;
using DataAccess.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Kidney.DataAccess.Entities
{
    public class Giver
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int Age { get; set; }
        public int? ContactInformationsId { get; set; }
        public ContactInformations ContactInformations { get; set; }
        public SEX Sex{ get; set; }
        public int? RaceId { get; set; }
        public Race Race { get; set; }
        public BLOOD_TYPE BloodType { get; set; }
    }
}
