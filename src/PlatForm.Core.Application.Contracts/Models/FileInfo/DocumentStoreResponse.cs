using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace PlatForm.Core.Models.FileInfo
{
    public class DocumentStoreResponse : AuditedEntityDto<Guid>
    {
        public string TenFile { get; set; }
        public string Url { get; set; }
        public string KieuFile { get; set; }
        public decimal? KichThuoc { get; set; }
        public string FullName { get; set; }
        public decimal? TotalPage { get; set; }
        public string Cached { get; set; }
    }
}
