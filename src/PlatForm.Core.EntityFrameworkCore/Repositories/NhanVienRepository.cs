using Microsoft.EntityFrameworkCore;
using PlatForm.Core.Entities.Commons;
using PlatForm.Core.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace PlatForm.Core.Repositories
{
    public class NhanVienRepository : EfCoreRepository<CoreDbContext, NhanVien, Guid>,
        INhanVienRepository
    {
        public NhanVienRepository(IDbContextProvider<CoreDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<PagedResultDto<NhanVien>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            PagedResultDto<NhanVien> list = new PagedResultDto<NhanVien>();
            list.TotalCount = await GetQueryable().Where(w => !w.IsDeleted).CountAsync();
            list.Items = await GetQueryable().Where(w => !w.IsDeleted).Include(t => t.BoPhan).OrderByDescending(w => w.CreationTime)
                .ThenByDescending(w => w.LastModificationTime)
                .Skip(input.SkipCount).Take(input.MaxResultCount).AsNoTracking().ToListAsync();
            return list;
        }
    }
}
