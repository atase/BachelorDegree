
using AutoMapper;
using Kidney.Business.Models;
using Kidney.Business.Services.Base;
using Kidney.DataAccess.Interfaces;
using System.Threading.Tasks;

namespace Kidney.Business.Services
{
    public class ReceiverService : Service<Receiver>, IReceiverService
    {
        private IReceiverRepository _receiverRepository;
        private IMapper _mapper;

        public ReceiverService(IReceiverRepository receiverRepository, IMapper mapper)
        {
            _receiverRepository = receiverRepository;
            _mapper = mapper;
        }
        public async Task<Receiver> Register(Receiver receiver)
        {
            var result = await _receiverRepository.Add(new DataAccess.Entities.Receiver {
                FirstName = receiver.FirstName,
                LastName = receiver.LastName,
                Country = receiver.Country,
                City = receiver.City,
                Age = receiver.Age,
                Email = receiver.Email,
                PhoneNumber = receiver.PhoneNumber,
                Sex = (global::DataAccess.Enums.SEX)receiver.Sex,
                Race = new DataAccess.Entities.Race
                {
                    Type = receiver.Race
                },
                BloodType = (global::DataAccess.Enums.BLOOD_TYPE)receiver.BloodType,
                PrimaryDiagnosis = new DataAccess.Entities.PrimaryDiagnosis
                {
                    Name = receiver.PrimaryDiagnosis
                },

            });

            return _mapper.Map<Receiver>(result);
            
        }

        public async Task<Receiver> GetInformations(int id)
        {
            var result = await _receiverRepository.GetReceiverInformations(id);
            return _mapper.Map<Receiver>(result);
        }
    }
}
