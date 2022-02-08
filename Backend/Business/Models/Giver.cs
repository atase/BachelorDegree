
using Kidney.Business.Enums;
using System;

namespace Kidney.Business.Models
{
    public class Giver : IComparable
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Age { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Sex { get; set; }
        public string Race { get; set; }
        public string BloodType { get; set; }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            return obj.GetHashCode().CompareTo(this.GetHashCode());
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Giver);
        }

        public bool Equals(Giver giver)
        {
            if (giver == null)
            {
                return false;
            }

            if (!FirstName.Equals(giver.FirstName))
            {
                return false;
            }

            if (!LastName.Equals(giver.LastName))
            {
                return false;
            }

            if (Age != giver.Age)
            {
                return false;
            }


            if (!Country.Equals(giver.Country))
            {
                return false;
            }

            if (!City.Equals(giver.City))
            {
                return false;
            }

            if (Sex != giver.Sex)
            {
                return false;
            }


            if (Race != giver.Race)
            {
                return false;
            }

            if (BloodType != giver.BloodType)
            {
                return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FirstName, LastName);
        }
    }
}
