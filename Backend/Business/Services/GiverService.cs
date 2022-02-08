
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
            var obj = new DataAccess.Entities.Giver
            {
                FirstName = giver.FirstName,
                LastName = giver.LastName,
                Country = giver.Country,
                City = giver.City,
                Age = giver.Age.Equals("") ? 0 : Int32.Parse(giver.Age),
                ContactInformations = new ContactInformations()
                {
                    Email = giver.Email,
                    PhoneNumber = giver.PhoneNumber,
                },
                Sex = (SEX)Enum.Parse(typeof(SEX), giver.Sex),
                Race = new DataAccess.Entities.Race
                {
                    Type = giver.Race
                },
                BloodType = (BLOOD_TYPE)Enum.Parse(typeof(BLOOD_TYPE), giver.BloodType)
            };
            var result = await _giverRepository.Add(obj);

            return _mapper.Map<Giver>(result);
        }

        public async Task<Giver> GetInformations(int id)
        {
            var result =  await _giverRepository.GetGiverInformations(id);

            return _mapper.Map<Giver>(result);
        }

        public async Task<IEnumerable<Giver>> FilterGivers(GiverFilter filters)
        {
            ValidatePaginationParams(filters);

            var result = await _giverRepository.FilterGivers(new SubjectsFilterRequestModel {
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
                }
            });
            return _mapper.Map<IEnumerable<Giver>>(result);
        }

        private void ValidatePaginationParams(GiverFilter filters) 
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

        public async Task<string> DeleteGiver(int id)
        {
            var obj = await _giverRepository.GetById(id);

            if (obj == null)
            {
                throw new Exception("No subjects exists with the given id.");
            }

            await _giverRepository.Delete(obj);

            return "Subject deleted.";
        }

        public async Task<IEnumerable<Giver>> GetAll()
        {
            var result = await _giverRepository.GetAll();

            return _mapper.Map<IEnumerable<Giver>>(result);
        }

        public async Task<string> UpdateGiver(int id, Giver giver)
        {
            var obj = new DataAccess.Entities.Giver
            {
                FirstName = giver.FirstName,
                LastName = giver.LastName,
                Country = giver.Country,
                City = giver.City,
                Age = giver.Age.Equals("") ? 0 : Int32.Parse(giver.Age),
                ContactInformations = new ContactInformations()
                {
                    Email = giver.Email,
                    PhoneNumber = giver.PhoneNumber,
                },
                Sex = (SEX)Enum.Parse(typeof(SEX), giver.Sex),
                Race = new DataAccess.Entities.Race
                {
                    Type = giver.Race
                },
                BloodType = (BLOOD_TYPE)Enum.Parse(typeof(BLOOD_TYPE), giver.BloodType)
            };

            await _giverRepository.Update(id, obj);
            return "Giver " + giver.FirstName + " " + giver.LastName + " is updated.";
        }
    }
}
