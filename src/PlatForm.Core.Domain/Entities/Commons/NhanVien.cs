using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace PlatForm.Core.Entities.Commons
{
    public class NhanVien : FullAuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public int Tuoi { get; set; }
        public string CMND { get; set; }
        public Guid BoPhanId { get; set; }
        public BoPhan BoPhan { get; set; }
    }
}
