using eCommerceCore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceCore.Infrastructure.Seed
{
    public class AdminAccountConfiguration : IEntityTypeConfiguration<AdminAccount>
    {
        private readonly IConfiguration _configuration;

        public AdminAccountConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Configure(EntityTypeBuilder<AdminAccount> builder)
        {
            var numberOfAdminAccountRecords = _configuration["AppSettings:NumberOfAdminAccountRecords"];


            if (int.TryParse(numberOfAdminAccountRecords, out int numberOfAdminAccountRecordsInt))
            {
                var accountTypeIds = SharedData.AccountTypeIds;
                var random = new Random();
                var adminAccounts = Enumerable.Range(0, numberOfAdminAccountRecordsInt)
                    .Select(i => new AdminAccount
                    {
                        Id = Guid.NewGuid(),
                        FirstName = "Admin",
                        LastName = "Admin",
                        Email = "admin@gmail.com",
                        ContactNumber = "7578998845",
                        Password = "Admin@123",
                        AccountTypeId = GetRandomAccountTypeId(accountTypeIds, random),
                        IsActive = true
                    })
                    .ToArray();

                builder.HasData(adminAccounts);
                SharedData.AdminAccountIds = adminAccounts.Select(b => b.Id).ToList();
            }
        }
        private Guid GetRandomAccountTypeId(List<Guid> accountTypeIds, Random random)
        {
            return accountTypeIds[random.Next(accountTypeIds.Count)];
        }
        private string GenerateRandomAccountNumber()
        {
            var random = new Random();
            return random.Next(10000000, 99999999).ToString();
        }
    }
}
