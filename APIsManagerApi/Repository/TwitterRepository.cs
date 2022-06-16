using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class TwitterRepository : RepositoryBase<TwitterCredential>, ITwitterRepository
    {
        public TwitterRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void AddTwitterCredential(TwitterCredential twitterCredential)
        {
            Create(twitterCredential);
        }

        public TwitterCredential GetCredential(int idUser)
        {
            return FindByCondition(userCredential => userCredential.IdUser == idUser).FirstOrDefault(); ;
        }
    }
}
