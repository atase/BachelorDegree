using DataAccess.Enums;
using System.Collections.Generic;

namespace DataAccess.DTOs
{
    public class SubjectsFilterRequestModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Race { get; set; }
        public string BloodType { get; set; }
        public IDictionary<string, string> SortData { get; set; }
        public IDictionary<string, int> PaginationData { get; set; }
        public string PrimaryDiagnosis { get; set; }
    }
}
