using eCommerceCore.Domain.Models;
using eCommerceCore.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceCore.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<AccountType> AccountsTypeRepository { get; }
        IRepository<AdminAccount> AdminAccountsRepository { get; }

        Task SaveAsync();
    }
}
