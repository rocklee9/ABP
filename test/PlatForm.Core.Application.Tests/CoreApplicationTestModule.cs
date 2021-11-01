using Volo.Abp.Modularity;

namespace PlatForm.Core
{
    [DependsOn(
        typeof(CoreApplicationModule),
        typeof(CoreDomainTestModule)
        )]
    public class CoreApplicationTestModule : AbpModule
    {

    }
}