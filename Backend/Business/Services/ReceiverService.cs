
using AutoMapper;
using Business.Models;
using DataAccess.DTOs;
using DataAccess.Entities;
using DataAccess.Enums;
using Kidney.Business.Models;
using Kidney.Business.Services.Base;
using Kidney.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
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
                Age = receiver.Age.Equals("") ? 0 : Int32.Parse(receiver.Age),
                ContactInformations = new ContactInformations() 
                {
                    Email = receiver.Email,
                    PhoneNumber = receiver.PhoneNumber,
                },
                Sex = (SEX)Enum.Parse(typeof(SEX), receiver.Sex),
                Race = new DataAccess.Entities.Race
                {
                    Type = receiver.Race
                },
                BloodType = (BLOOD_TYPE)Enum.Parse(typeof(BLOOD_TYPE), receiver.BloodType),
                PrimaryDiagnosis = new DataAccess.Entities.PrimaryDiagnosis
                {
                    Name = receiver.PrimaryDiagnosis
                },

            });;

            return _mapper.Map<Receiver>(result);
            
        }

        public async Task<Receiver> GetInformations(int id)
        {
            var result = await _receiverRepository.GetReceiverInformations(id);
            return _mapper.Map<Receiver>(result);
        }

        public async Task<IEnumerable<Receiver>> FilterReceivers(ReceiverFilter filters)
        {
            ValidatePaginationParams(filters);

            var result = await _receiverRepository.FilterReceivers(new SubjectsFilterRequestModel
            {
                FirstName = filters.FirstName,
                LastName = filters.LastName,
                Age = filters.Age.Equals("") ? 0 : Int32.Parse(filters.Age),
                Sex = filters.Sex,
                Country = filters.Country,
                City = filters.City,
                Race = filters.Race,
                BloodType = filters.BloodType,
                SortData = new Dictionary<string, string>
                {
                    { "field", filters.SortData.Field },
                    { "order", filters.SortData.Order.ToString() }
                },
                PaginationData = new Dictionary<string, int>
                {
                    { "skip", filters.PaginationData.Skip },
                    { "limit", filters.PaginationData.Limit }
                },
                PrimaryDiagnosis = filters.PrimaryDiagnosis
            });
            return _mapper.Map<IEnumerable<Receiver>>(result);
        }

        private void ValidatePaginationParams(ReceiverFilter filters)
        {
            if (filters.PaginationData.Skip == 0 && filters.PaginationData.Limit == 0)
            {
                filters.PaginationData.Skip = 0;
                filters.PaginationData.Limit = 100;
                return;
            }

            if (filters.PaginationData.Skip < 0)
            {
                throw new Exception("Invalid request. Skip should be >= 0.");
            }

            if (!(filters.PaginationData.Limit > 0 && filters.PaginationData.Limit <= 100))
            {
                throw new Exception("Invalid request. Limit should be > 0 && <= 100.");
            }


        }

        public async Task<IEnumerable<Receiver>> GetAll()
        {
            var result = await _receiverRepository.GetAll();

            return _mapper.Map<IEnumerable<Receiver>>(result);
        }

        public async Task<string> DeleteReceiver(int id)
        {
            var obj = await  _receiverRepository.GetById(id);
            if (obj == null)
            {
                throw new Exception("No subject exists with the given id.");
            }

            await _receiverRepository.Delete(obj);

            return "Subject deleted";
        }

        public async Task<string> UpdateReceiver(int id, Receiver receiver)
        {
            var obj = new DataAccess.Entities.Receiver
            {
                FirstName = receiver.FirstName,
                LastName = receiver.LastName,
                Country = receiver.Country,
                City = receiver.City,
                Age = receiver.Age.Equals("") ? 0 : Int32.Parse(receiver.Age),
                ContactInformations = new ContactInformations()
                {
                    Email = receiver.Email,
                    PhoneNumber = receiver.PhoneNumber,
                },
                Sex = (SEX)Enum.Parse(typeof(SEX), receiver.Sex),
                Race = new DataAccess.Entities.Race
                {
                    Type = receiver.Race
                },
                BloodType = (BLOOD_TYPE)Enum.Parse(typeof(BLOOD_TYPE), receiver.BloodType),
                PrimaryDiagnosis = new DataAccess.Entities.PrimaryDiagnosis()
                {
                    Name = receiver.PrimaryDiagnosis
                }
            };

            await _receiverRepository.Update(id, obj);
            return "Receiver " + receiver.FirstName + " " + receiver.LastName + " is updated.";
        }
    }
}
