using PlatForm.Core.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace PlatForm.Core.Repositories
{
    public interface IBoPhanRepository : IRepository<BoPhan, Guid>
    {
        Task<List<BoPhan>> GetBoPhans();
    }
}
