

using Kidney.Business.Enums;

namespace Business.Models
{
    public class GiverFilter
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }
        public string Sex { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Race { get; set; }
        public string BloodType { get; set; }
        public Sort SortData { get; set; }
        public Pagination PaginationData { get; set; }
    }
}
