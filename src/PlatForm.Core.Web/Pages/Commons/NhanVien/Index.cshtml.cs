using PlatForm.Core.Web.Pages;
using System.Threading.Tasks;

namespace Core.Web.Pages.Commons.NhanVien
{
    public class IndexModel : CorePageModel
    {
        public virtual async Task OnGetAsync()
        {
            await Task.CompletedTask;
        }
    }
}
