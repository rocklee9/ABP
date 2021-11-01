using Microsoft.AspNetCore.Authorization;
using PlatForm.Core.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace PlatForm.Core.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    [Authorize]
    public abstract class CorePageModel : AbpPageModel
    {
        protected CorePageModel()
        {
            LocalizationResourceType = typeof(CoreResource);
        }
    }
}