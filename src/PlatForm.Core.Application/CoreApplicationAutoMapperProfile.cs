using AutoMapper;
using PlatForm.Core.Entities.Commons;
using PlatForm.Core.Entities.File;
using PlatForm.Core.Models.BoPhan;
using PlatForm.Core.Models.FileInfo;
using PlatForm.Core.Models.NhanVien;

namespace PlatForm.Core
{
    public class CoreApplicationAutoMapperProfile : Profile
    {
        public CoreApplicationAutoMapperProfile()
        {
            //nhân viên
            CreateMap<NhanVien, NhanVienResponse>();
            CreateMap<NhanVienRequest, NhanVien>();
            CreateMap<NhanVienResponse, NhanVienRequest>();

            //bộ phận
            CreateMap<BoPhan, BoPhanResponse>();
            CreateMap<BoPhanRequest, BoPhan>();
            CreateMap<BoPhanResponse, BoPhanRequest>();

            // file
            CreateMap<DocumentStore, DocumentStoreResponse>();
            CreateMap<DocumentStore, DocumentStoreModel>();
            CreateMap<DocumentStoreRequest, DocumentStore>();
            CreateMap<DocumentStoreResponse, DocumentStoreRequest>();
            CreateMap<DocumentStoreModel, DocumentStoreResponse>();
            CreateMap<DocumentStoreResponse, DocumentStoreModel>();
        }
    }
}
