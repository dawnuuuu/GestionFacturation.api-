using System.Linq;
using System.Threading.Tasks;
using GestionFacturation.Api.Models;

namespace GestionFacturation.Api.Auth
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<User> Authenticate(string username, string password)
        {
            var user = _context.Users.ToList().Find(u => u.Username == username && u.Password == password);

            return user;
        }
    }
}