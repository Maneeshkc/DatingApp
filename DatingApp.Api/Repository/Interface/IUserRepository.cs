using System.Threading.Tasks;
using MyDatingapp.Api.Model;
using System.Collections.Generic;

namespace DatingApp.Api.Repository.Interface
{
    public interface IUserRepository
    {
        Task<Tuser> AddUser(Tuser user);

        Task DeleteUser(int id);

        Task<Tuser> GetTuser(int id);
        Task<IList<Tuser>> GetUsers();
    }
}