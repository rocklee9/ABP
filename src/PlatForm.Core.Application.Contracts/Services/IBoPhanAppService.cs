using PlatForm.Core.Models.BoPhan;
using PlatForm.Core.Models.Search;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace PlatForm.Core.Services
{
    public interface IBoPhanAppService :
        ICrudAppService<
            BoPhanResponse,
            Guid,
            PagedAndSortedResultRequestDto,
            BoPhanRequest,
            BoPhanRequest>
    {
        /// <summary>
        /// Tìm kiếm bộ phận
        /// </summary>
        /// <param name="condition">điều kiện search</param>
        /// <returns></returns>
        Task<PagedResultDto<BoPhanResponse>> SearchAsync(ConditionSearchRequest condition);
    }
}
