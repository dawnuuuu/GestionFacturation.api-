using System.Threading.Tasks;
using GestionFacturation.Api.Models;

namespace GestionFacturation.Api.Auth
{
    public interface IUserService
    {
        Task<User> Authenticate(string username, string password);
    }
}