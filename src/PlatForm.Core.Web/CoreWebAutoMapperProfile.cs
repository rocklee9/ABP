using AutoMapper;
using PlatForm.Core.Models.NhanVien;
using static Core.Web.Pages.Commons.NhanVien.EditModalModel;

namespace PlatForm.Core.Web
{
    public class CoreWebAutoMapperProfile : Profile
    {
        public CoreWebAutoMapperProfile()
        {
            //Define your AutoMapper configuration here for the Web project.
            CreateMap<NhanVienResponse, NhanVienModel>();
        }
    }
}
