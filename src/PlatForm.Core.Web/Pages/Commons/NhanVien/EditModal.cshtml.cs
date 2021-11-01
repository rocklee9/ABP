using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PlatForm.Core.Models.NhanVien;
using PlatForm.Core.Services;
using PlatForm.Core.Web.Pages;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace Core.Web.Pages.Commons.NhanVien
{
    public class EditModalModel : CorePageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public NhanVienModel ViewModel { get; set; }

        public List<SelectListItem> BoPhanList { get; set; }

        private readonly INhanVienAppService _service;

        private readonly IBoPhanAppService _boPhanService;

        public EditModalModel(INhanVienAppService service, IBoPhanAppService boPhanService)
        {
            _service = service;
            _boPhanService = boPhanService;
        }

        public virtual async Task OnGetAsync()
        {
            var response = await _service.GetAsync(Id);
            ViewModel = ObjectMapper.Map<NhanVienResponse, NhanVienModel>(response);

            var boPhanList = await _boPhanService.GetListAsync(new PagedAndSortedResultRequestDto { MaxResultCount = 1000 });
            BoPhanList = new List<SelectListItem>();
            BoPhanList.Add(new SelectListItem
            {
                Value = "",
                Text = "Chọn bộ phận",
                Selected = true
            });
            foreach (var item in boPhanList.Items)
            {
                BoPhanList.Add(new SelectListItem
                {
                    Value = item.Id.ToString(),
                    Text = item.Name.ToString()
                });
            }
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            await _service.UpdateAsync(Id, ViewModel);
            return NoContent();
        }

        public class NhanVienModel : NhanVienRequest
        {
            [SelectItems(nameof(BoPhanList))]
            [Display(Name = "BoPhan")]
            public override Guid BoPhanId { get; set; }
        }
    }
}