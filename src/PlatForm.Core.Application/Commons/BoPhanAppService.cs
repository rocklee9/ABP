using Microsoft.AspNetCore.Mvc;
using PlatForm.Core.Entities.Commons;
using PlatForm.Core.Models.BoPhan;
using PlatForm.Core.Models.Search;
using PlatForm.Core.Repositories;
using PlatForm.Core.Services;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace PlatForm.Core.Commons
{
    public class BoPhanAppService :
        CrudAppService<BoPhan,
            BoPhanResponse, Guid, PagedAndSortedResultRequestDto,
            BoPhanRequest, BoPhanRequest>,
        IBoPhanAppService
    {
        private readonly IBoPhanRepository _repository;

        public BoPhanAppService(IBoPhanRepository BoPhans,
            IRepository<BoPhan, Guid> repository) : base(repository)
        {
            _repository = BoPhans;
        }

        [HttpGet]
        public async Task<PagedResultDto<BoPhanResponse>> SearchAsync(ConditionSearchRequest condition)
        {
            var input = new PagedAndSortedResultRequestDto { MaxResultCount = 1000, SkipCount = 0 };
            if (condition.keyword == null)
            {
                condition.keyword = "";
            }

            PagedResultDto<BoPhanResponse> listResultDto = new PagedResultDto<BoPhanResponse>();
            var list = this.GetListAsync(input).Result;
            var resultSearch = list.Items.Where(x => x.Name.Contains(condition.keyword));
            listResultDto.TotalCount = resultSearch.Count();
            listResultDto.Items = resultSearch.Skip(condition.SkipCount).Take(condition.MaxResultCount).ToList();

            return listResultDto;
        }
    }
}
