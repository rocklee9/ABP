using PlatForm.Core.Entities.File;
using PlatForm.Core.EntityFrameworkCore;
using PlatForm.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using EFCore.BulkExtensions;

namespace PlatForm.Core.Repositories
{
    public class DocumentStoreRepository : EfCoreRepository<CoreDbContext, DocumentStore, Guid>, IDocumentStoreRepository
    {
        private readonly IDbContextProvider<CoreDbContext> _dbContextProvider;

        public DocumentStoreRepository(IDbContextProvider<CoreDbContext> dbContextProvider)
         : base(dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
        }

        public async Task<List<DocumentStore>> InsertMultiAsync(List<DocumentStore> documentStores)
        {
            await _dbContextProvider.GetDbContext().BulkInsertAsync(documentStores);
            return documentStores;
        }
    }
}
