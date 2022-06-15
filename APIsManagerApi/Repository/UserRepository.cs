using Contracts;
using Entities;
using Entities.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<User> GetAllUsers()
        {
            return FindAll()
                .OrderBy(user => user.Email)
                .ToList();
        }

        public User SearchByEmailAndPassword(string email, string password)
        {
            return FindByCondition(user => user.Email.Equals(email) && user.Password.Equals(password)).FirstOrDefault();
        }

        public void CreateUser(User user)
        {
            Create(user);
        }

        public User GetUserById(int id)
        {
            return FindByCondition(user => user.Id == id).FirstOrDefault();
        }

        public void UpdateUser(User user)
        {
            Update(user);
        }

        public void DeleteUser(User user)
        {
            Delete(user);
        }

        public bool VerifyUser(string email, string password)
        {
            var userExist = FindByCondition(user => user.Email == email && user.Password == password).FirstOrDefault();
            if (userExist is not null)
                return true;

            return false;
        }
    }
}
