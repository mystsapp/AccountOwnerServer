using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly RepositoryContext _repoContext;
        private IOwnerRepository _owner;
        private IAccountRepository _account;

        public RepositoryWrapper(RepositoryContext context)
        {
            _repoContext = context;
        }

        public IOwnerRepository Owner
        {
            get
            {
                if(_owner == null)
                {
                    _owner = new OwnerRepository(_repoContext);
                }

                return _owner;
            }
        }

        public IAccountRepository Account
        {
            get
            {
                if(_account == null)
                {
                    _account = new AccountRepository(_repoContext);
                }

                return _account;
            }
        }
        

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
