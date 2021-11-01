using PlatForm.Core.Entities.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace PlatForm.Core.IRepositories
{
    public interface IDocumentStoreRepository : IRepository<DocumentStore, Guid>
    {
        Task<List<DocumentStore>> InsertMultiAsync(List<DocumentStore> documentStores);
    }
}
