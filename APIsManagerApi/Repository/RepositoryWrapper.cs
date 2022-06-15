﻿using Contracts;
using Entities;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private IUserRepository _user;
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

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}