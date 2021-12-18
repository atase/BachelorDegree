
using AutoMapper;
using Kidney.Business.Models;
using Kidney.Business.Services.Base;
using Kidney.DataAccess.Interfaces;
using System.Threading.Tasks;

namespace Kidney.Business.Services
{
    public class GiverService : Service<Giver>, IGiverService
    {
        private IGiverRepository _giverRepository;
        private IMapper _mapper;
        public GiverService(IGiverRepository giverRepository, IMapper mapper) 
        {
            _giverRepository = giverRepository;
            _mapper = mapper;
        }

        public async Task<Giver> Register(Giver giver)
        {
            var result = await _giverRepository.Add(new DataAccess.Entities.Giver
            {
                FirstName = giver.FirstName,
                LastName = giver.LastName,
                Country = giver.Country,
                City = giver.City,
                Age = giver.Age,
                Email = giver.Email,
                PhoneNumber = giver.PhoneNumber,
                Sex = (global::DataAccess.Enums.SEX)giver.Sex,
                Race = new DataAccess.Entities.Race {
                    Type = giver.Race
                },
                BloodType = (global::DataAccess.Enums.BLOOD_TYPE)giver.BloodType
            });

            return _mapper.Map<Giver>(result);
        }

        public async Task<Giver> GetInformations(int id)
        {
            var result =  await _giverRepository.GetGiverInformations(id);

            return _mapper.Map<Giver>(result);
        }
    }
}
