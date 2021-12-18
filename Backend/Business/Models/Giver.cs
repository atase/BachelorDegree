
using Kidney.Business.Enums;

namespace Kidney.Business.Models
{
    public class Giver
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public SEX Sex { get; set; }
        public string Race { get; set; }
        public BLOOD_TYPE BloodType { get; set; }
    }
}
