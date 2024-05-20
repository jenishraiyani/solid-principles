using eCommerceCore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceCore.Infrastructure.Seed
{
    public class AccountTypeConfiguration : IEntityTypeConfiguration<AccountType>
    {
        public void Configure(EntityTypeBuilder<AccountType> builder)
        {
            var adminId = Guid.NewGuid();
            var customerId = Guid.NewGuid();

            builder.HasData(
                new AccountType { Id = adminId, Name = "Admin" },
                new AccountType { Id = customerId, Name = "Customer" }
            );

            SharedData.AccountTypeIds = new List<Guid> { adminId, customerId };
        }
    }
}
