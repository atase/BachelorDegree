
using AutoMapper;
using Kidney.Business.Models;
using Kidney.Business.Services.Base;
using Kidney.DataAccess.Interfaces;
using System.Threading.Tasks;

namespace Kidney.Business.Services
{
    public class UserService : Service<User>, IUserService
    {
        private IUserRepository _userRepository;
        private IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }


        public async Task<User> Register(User user) 
        {
            var result = await _userRepository.Add(new DataAccess.Entities.User {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Country = user.Country,
                City = user.City,
                Age = user.Age,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            });

            return _mapper.Map<User>(result);
        }

    }
}
