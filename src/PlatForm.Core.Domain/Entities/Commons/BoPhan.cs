using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace PlatForm.Core.Entities.Commons
{
    public class BoPhan : FullAuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public string GhiChu { get; set; }

        public List<NhanVien> NhanViens { get; set; }
    }
}
