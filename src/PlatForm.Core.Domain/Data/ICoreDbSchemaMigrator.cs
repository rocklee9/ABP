using System.Threading.Tasks;

namespace PlatForm.Core.Data
{
    public interface ICoreDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
