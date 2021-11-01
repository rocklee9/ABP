using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace PlatForm.Core.Web
{
    [Dependency(ReplaceServices = true)]
    public class CoreBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "Core";
    }
}
