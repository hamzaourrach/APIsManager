using Contracts;
using Entities;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private IUserRepository _user;
        private ITwitterRepository _twitterRepo;
        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public IUserRepository User
        {
            get{
                if (_user == null)
                    _user = new UserRepository(_repoContext);
                return _user;
            }
        }

        public ITwitterRepository Twitter
        {
            get
            {
                if (_twitterRepo == null)
                    _twitterRepo = new TwitterRepository(_repoContext);
                return _twitterRepo;
            }
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}