using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceCore.Infrastructure.Seed
{
    public class SharedData
    {
        public static List<Guid> AccountTypeIds { get; set; } = new List<Guid>();
        public static List<Guid> AdminAccountIds { get; set; } = new List<Guid>();
    }
}
