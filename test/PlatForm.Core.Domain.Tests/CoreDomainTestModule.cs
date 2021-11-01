using PlatForm.Core.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace PlatForm.Core
{
    [DependsOn(
        typeof(CoreEntityFrameworkCoreTestModule)
        )]
    public class CoreDomainTestModule : AbpModule
    {

    }
}