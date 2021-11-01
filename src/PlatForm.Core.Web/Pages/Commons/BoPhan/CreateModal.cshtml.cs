using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlatForm.Core.Models.BoPhan;
using PlatForm.Core.Services;
using PlatForm.Core.Web.Pages;

namespace Core.Web.Pages.Commons.BoPhan
{
    public class CreateModalModel : CorePageModel
    {
        [BindProperty]
        public BoPhanRequest ViewModel { get; set; }

        private readonly IBoPhanAppService _service;

        public CreateModalModel(IBoPhanAppService service)
        {
            _service = service;
        }

        public virtual async Task OnGetAsync()
        {
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            await _service.CreateAsync(ViewModel);
            return NoContent();
        }
    }
}