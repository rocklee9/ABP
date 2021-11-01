using PlatForm.Core.Models.NhanVien;
using PlatForm.Core.Models.Search;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace PlatForm.Core.Services
{
    public interface INhanVienAppService :
        ICrudAppService<
            NhanVienResponse,
            Guid,
            PagedAndSortedResultRequestDto,
            NhanVienRequest,
            NhanVienRequest>
    {
    }
}
