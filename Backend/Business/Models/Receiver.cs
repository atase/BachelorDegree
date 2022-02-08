
using Kidney.Business.Enums;
using System;

namespace Kidney.Business.Models
{
    public class Receiver : IComparable
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
        public string PrimaryDiagnosis { get; set; }

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
            return this.Equals(obj as Receiver);
        }

        public bool Equals(Receiver receiver)
        {
            if (receiver == null)
            {
                return false;
            }

            if (Id != receiver.Id)
            {
                return false;
            }

            if (!FirstName.Equals(receiver.FirstName))
            {
                return false;
            }

            if (!LastName.Equals(receiver.LastName))
            {
                return false;
            }

            if (Age != receiver.Age)
            {
                return false;
            }


            if (!Country.Equals(receiver.Country))
            {
                return false;
            }

            if (!City.Equals(receiver.City))
            {
                return false;
            }

            if (Sex != receiver.Sex)
            {
                return false;
            }    


            if(Race != receiver.Race)
            {
                return false;
            }

            if (PrimaryDiagnosis != receiver.PrimaryDiagnosis)
            {
                return false;
            }

            if (BloodType != receiver.BloodType)
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
