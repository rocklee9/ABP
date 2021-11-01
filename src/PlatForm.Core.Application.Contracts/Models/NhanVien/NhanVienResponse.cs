using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace PlatForm.Core.Models.NhanVien
{
    public class NhanVienResponse : EntityDto<Guid>
    {
        public string Name { get; set; }
        public int Tuoi { get; set; }
        public string CMND { get; set; }
        public string BoPhan { get; set; }
    }
}
