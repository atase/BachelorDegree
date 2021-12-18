
using Kidney.Business.Models;
using Kidney.Business.Services.Base;
using System.Threading.Tasks;

namespace Kidney.Business.Services
{
    public interface IUserService : IService<User>
    {
        Task<User> Register(User user);
    }
}
