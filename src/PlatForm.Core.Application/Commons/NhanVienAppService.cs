using Microsoft.AspNetCore.Mvc;
using PlatForm.Core.Entities.Commons;
using PlatForm.Core.Models.NhanVien;
using PlatForm.Core.Models.Search;
using PlatForm.Core.Repositories;
using PlatForm.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace PlatForm.Core.Commons
{
    public class NhanVienAppService :
        CrudAppService<NhanVien,
            NhanVienResponse, Guid, PagedAndSortedResultRequestDto,
            NhanVienRequest, NhanVienRequest>,
        INhanVienAppService
    {
        private readonly INhanVienRepository _repository;

        public NhanVienAppService(INhanVienRepository NhanViens,
            IRepository<NhanVien, Guid> repository) : base(repository)
        {
            _repository = NhanViens;
        }

        public async override Task<PagedResultDto<NhanVienResponse>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            PagedResultDto<NhanVien> items = await _repository.GetListAsync(input);
            List<NhanVienResponse> nhanVienResponses = new List<NhanVienResponse>();
            foreach (var item in items.Items)
            {
                var nhanVienResponse = ObjectMapper.Map<NhanVien, NhanVienResponse>(item);
                nhanVienResponse.BoPhan = item.BoPhan == null ? "" : item.BoPhan.Name;
                nhanVienResponses.Add(nhanVienResponse);
            }
            return new PagedResultDto<NhanVienResponse>(items.TotalCount, nhanVienResponses);
        }
    }
}
