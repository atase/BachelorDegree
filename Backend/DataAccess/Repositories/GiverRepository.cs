using DataAccess.DTOs;
using DataAccess.Enums;
using Kidney.DataAccess.DataContexts;
using Kidney.DataAccess.Entities;
using Kidney.DataAccess.Interfaces;
using Kidney.DataAccess.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kidney.Infrastructure.Repositories
{
    public class GiverRepository : Repository<Giver>, IGiverRepository
    {
        public GiverRepository(ApplicationContext applicationContext) : base(applicationContext) { }

        public async Task<IEnumerable<Giver>> FilterGivers(SubjectsFilterRequestModel filters)
        {
            var results = _applicationContext.Givers.AsQueryable().Include("Race").Include("ContactInformations");

            if (!filters.FirstName.Equals(""))
            {
                results = results.Where(x => x.FirstName.ToLower().Equals(filters.FirstName.ToLower()));
            }

            if (!filters.LastName.Equals(""))
            {
                results = results.Where(x => x.LastName.ToLower().Equals(filters.LastName.ToLower()));
            }

            if (filters.Age != 0)
            {
                results = results.Where(x => x.Age == filters.Age);
            }

            if (!filters.Sex.Equals(""))
            {
                results = results.Where(x => x.Sex == (SEX)Enum.Parse(typeof(SEX), filters.Sex));
            }

            if (!filters.Country.Equals(""))
            {
                results = results.Where(x => x.Country.ToLower().Equals(filters.Country.ToLower()));
            }


            if (!filters.City.Equals(""))
            {
                results = results.Where(x => x.City.ToLower().Equals(filters.City.ToLower()));
            }

            if (!filters.BloodType.Equals(""))
            {
                results = results.Where(x => x.BloodType == (BLOOD_TYPE)Enum.Parse(typeof(BLOOD_TYPE), filters.BloodType));
            }

            if (!filters.Race.Equals(""))
            {
                results = results.Where(x => x.Race.Type.ToUpper().Equals(filters.Race.ToUpper()));
            }



            return await results.Skip(filters.PaginationData["skip"]).Take(filters.PaginationData["limit"]).ToListAsync();
        }

        public async Task<IEnumerable<Giver>> GetGiverByFirstName(string firstName)
        {
            return await _applicationContext.Givers
                .Where(g => g.FirstName == firstName)
                .Include("Race")
                .Include("ContactInformations")
                .ToListAsync();
        }

        public async Task<Giver> GetGiverInformations(int id)
        {
            return _applicationContext.Givers
                .Where(g => g.Id == id)
                .Include("Race")
                .Include("ContactInformations")
                .FirstOrDefault();
        }

        public  async new Task<List<Giver>> GetAll()
        {
            return await  _applicationContext.Givers
                .Include("Race")
                .Include("ContactInformations")
                .ToListAsync();
        }


        public async Task Update(int id, Giver entity) 
        {
            var giver = await GetGiverInformations(id);
            giver.FirstName = entity.FirstName;
            giver.LastName = entity.LastName;
            giver.Country = entity.Country;
            giver.City = entity.City;
            giver.Age = entity.Age;
            giver.ContactInformations.Email = entity.ContactInformations.Email;
            giver.ContactInformations.PhoneNumber = entity.ContactInformations.PhoneNumber;
            giver.Sex = entity.Sex;
            giver.BloodType = entity.BloodType;
            giver.Race.Type = entity.Race.Type;


            _applicationContext.SaveChanges();
        }
    }
}
