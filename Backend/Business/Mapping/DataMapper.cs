using AutoMapper;
using Kidney.Business.Models;

namespace Business.Mapping
{
    public class DataMapper : Profile
    {
        public DataMapper() 
        {
            CreateMap<Kidney.DataAccess.Entities.Giver, Giver>()
                .ForMember(e => e.Race, opt => opt.MapFrom(s => s.Race.Type.ToString()))
                .ForMember(e => e.PhoneNumber, opt => opt.MapFrom(s => s.ContactInformations.PhoneNumber))
                .ForMember(e => e.Email, opt => opt.MapFrom(s => s.ContactInformations.Email));
            CreateMap<Kidney.DataAccess.Entities.Receiver, Receiver>()
                .ForMember(e => e.Race, opt => opt.MapFrom(s => s.Race.Type.ToString()))
                .ForMember(e => e.PrimaryDiagnosis, opt => opt.MapFrom(s => s.PrimaryDiagnosis.Name.ToString()))
                .ForMember(e => e.PhoneNumber, opt => opt.MapFrom(s => s.ContactInformations.PhoneNumber))
                .ForMember(e => e.Email, opt => opt.MapFrom(s => s.ContactInformations.Email));
        }

        
    }
}
