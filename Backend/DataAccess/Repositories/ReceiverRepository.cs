using DataAccess.DTOs;
using DataAccess.Entities;
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

namespace Kidney.Infrastructure.Repositories.Base
{
    public class ReceiverRepository : Repository<Receiver>, IReceiverRepository
    {
        public ReceiverRepository(ApplicationContext applicationContext) : base(applicationContext) { }

        public async Task<IEnumerable<Receiver>> FilterReceivers(SubjectsFilterRequestModel filters)
        {
            var results = _applicationContext.Receivers.AsQueryable().Include("Race").Include("PrimaryDiagnosis").Include("ContactInformations");

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

            if (!filters.PrimaryDiagnosis.Equals(""))
            {
                results = results.Where(x => x.PrimaryDiagnosis.Name.ToUpper().Equals(filters.PrimaryDiagnosis.ToUpper()));
            }

            if (!filters.Race.Equals(""))
            {
                results = results.Where(x => x.Race.Type.ToUpper().Equals(filters.Race.ToUpper()));
            }



            return await results.Skip(filters.PaginationData["skip"]).Take(filters.PaginationData["limit"]).ToListAsync();
        }

        public async Task<IEnumerable<Receiver>> GetReceiverByFirstName(string firstName)
        {
            return await _applicationContext.Receivers.Where(r => r.FirstName == firstName)
                .Include("Race")
                .Include("PrimaryDiagnosis")
                .Include("ContactInformations")
                .ToListAsync();
        }

        public async Task<Receiver> GetReceiverInformations(int id)
        {
            return _applicationContext.Receivers
                .Where(g => g.Id == id)
                .Include("Race")
                .Include("PrimaryDiagnosis")
                .Include("ContactInformations")
                .FirstOrDefault();
        }

        public async new Task<List<Receiver>> GetAll() 
        {
            return await _applicationContext.Receivers
                .Include("Race")
                .Include("PrimaryDiagnosis")
                .Include("ContactInformations")
                .ToListAsync();
        }

        public async Task Update(int id, Receiver entity)
        {
            var receiver = await GetReceiverInformations(id);
            receiver.FirstName = entity.FirstName;
            receiver.LastName = entity.LastName;
            receiver.Country = entity.Country;
            receiver.City = entity.City;
            receiver.Age = entity.Age;
            if (receiver.ContactInformations != null)
            {
                receiver.ContactInformations.Email = entity.ContactInformations.Email;
                receiver.ContactInformations.PhoneNumber = entity.ContactInformations.PhoneNumber;
            }
            else 
            {
                receiver.ContactInformations = new ContactInformations();
                receiver.ContactInformations.Email = entity.ContactInformations.Email;
                receiver.ContactInformations.PhoneNumber = entity.ContactInformations.PhoneNumber;
            }
            receiver.Sex = entity.Sex;
            receiver.BloodType = entity.BloodType;
            receiver.Race.Type = entity.Race.Type;
            receiver.PrimaryDiagnosis.Name = entity.PrimaryDiagnosis.Name;


            _applicationContext.SaveChanges();
        }
    }
}
