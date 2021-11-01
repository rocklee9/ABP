using PlatForm.Core.Entities.Commons;
using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Application.Dtos;

namespace PlatForm.Core.Repositories
{
    public interface INhanVienRepository : IRepository<NhanVien, Guid>
    {
        Task<PagedResultDto<NhanVien>> GetListAsync(PagedAndSortedResultRequestDto input);
    }
}
