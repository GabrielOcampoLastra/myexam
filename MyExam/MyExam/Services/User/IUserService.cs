using MyExam.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyExam.Services.User
{
    public interface IUserService
    {
        Task<Response<bool>> Login(Models.User user);

        Task<List<Models.User>> GetUsersFromService(int users);

        List<Models.User> GetUsersFromDatabase();

        bool Logout();
    }
}
