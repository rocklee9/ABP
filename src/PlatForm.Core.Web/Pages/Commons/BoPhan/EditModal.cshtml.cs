using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlatForm.Core.Models.BoPhan;
using PlatForm.Core.Services;
using PlatForm.Core.Web.Pages;

namespace Core.Web.Pages.Commons.BoPhan
{
    public class EditModalModel : CorePageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public BoPhanRequest ViewModel { get; set; }

        private readonly IBoPhanAppService _service;

        public EditModalModel(IBoPhanAppService service)
        {
            _service = service;
        }

        public virtual async Task OnGetAsync()
        {
            var response = await _service.GetAsync(Id);
            ViewModel = ObjectMapper.Map<BoPhanResponse, BoPhanRequest>(response);
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            await _service.UpdateAsync(Id, ViewModel);
            return NoContent();
        }
    }
}