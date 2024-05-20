using eCommerceCore.Domain.Models;
using eCommerceCore.Infrastructure.Context;
using eCommerceCore.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static eCommerceCore.Infrastructure.UnitOfWork.UnitOfWork;

namespace eCommerceCore.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            AdminAccountsRepository = new Repository<AdminAccount>(context);
            AccountsTypeRepository = new Repository<AccountType>(context);
         
        }

        public IRepository<AdminAccount> AdminAccountsRepository { get; private set; }
        public IRepository<AccountType> AccountsTypeRepository { get; private set; }
       
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
