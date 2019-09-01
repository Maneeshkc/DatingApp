using System.Linq;
using System.Threading.Tasks;
using DatingApp.Api.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using MyDatingapp.Api.Model;

namespace DatingApp.Api.Repository.Implimenation
{
    public class Auth : IAuth
    {
        private DatingAppContext _Context { get; }


       public Auth(DatingAppContext context)
        {
            _Context = context;
        }


        public async Task<bool> CheckUserName(string userName)
        {
            return await _Context.
            Tuser.
            FirstOrDefaultAsync(x => x.Name.ToLower() == userName.ToLower()) != null;
        }

        public async Task<Tuser> Login(string userName, string password)
        {
            var userFromDb = await _Context.Tuser.
            FirstOrDefaultAsync(x => x.Name == userName && x.Password == password);
            if (userFromDb != null)
                return userFromDb;
            else
                return null;
        }

        public async Task<Tuser> Register(Tuser user)
        {
            using (_Context)
            {
                await _Context.Tuser.AddAsync(user);
                await _Context.SaveChangesAsync();
                return user;
            };

            //return null;
        }
    }
}