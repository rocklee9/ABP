using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace PlatForm.Core.Entities.File
{
    public class DocumentStore : FullAuditedAggregateRoot<Guid>
    {
        #region Base properties
        public string TenFile { get; set; }
        public string Url { get; set; }
        public string KieuFile { get; set; }
        public decimal? KichThuoc { get; set; }
        public string FullName { get; set; }
        public decimal? TotalPage { get; set; }
        public string Cached { get; set; }
        public int OrderIndex { get; set; }
        public Guid TenantId { get; set; }

        #endregion Base properties
    }
}
