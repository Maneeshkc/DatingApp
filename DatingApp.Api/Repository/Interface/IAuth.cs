using System.Threading.Tasks;
using MyDatingapp.Api.Model;

namespace DatingApp.Api.Repository.Interface
{
    public interface IAuth
    {
        Task<Tuser> Register(Tuser user);
        Task<Tuser> Login(string userName, string password);

        Task<bool> CheckUserName(string userName);
    }
}