using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ITwitterRepository : IRepositoryBase<TwitterCredential>
    {
        public TwitterCredential GetCredential(int idUser);

        void AddTwitterCredential(TwitterCredential twitterCredential);
    }
}
