using Microsoft.EntityFrameworkCore;
using PlatForm.Core.Entities.Commons;
using PlatForm.Core.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace PlatForm.Core.Repositories
{
    public class BoPhanRepository : EfCoreRepository<CoreDbContext, BoPhan, Guid>,
        IBoPhanRepository
    {
        public BoPhanRepository(IDbContextProvider<CoreDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<List<BoPhan>> GetBoPhans()
        {
            return await  GetQueryable().Where(t => !t.IsDeleted).ToListAsync();
        }
    }
}
