using Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        IEnumerable<User> GetAllUsers();
        User SearchByEmailAndPassword(string email, string password);
        User GetUserById(int id);

        string GetUserIdByEmail(string email);
        void CreateUser(User user);

        void UpdateUser(User user);

        void DeleteUser(User user);

        bool VerifyUser(string email, string password);
    }
}
