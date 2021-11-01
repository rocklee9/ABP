using Microsoft.AspNetCore.Http;
using PlatForm.Core.Models.FileInfo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace PlatForm.Core.Services
{
    public interface IDocumentStoreAppService :
        ICrudAppService<
            DocumentStoreResponse,
            Guid,
            PagedAndSortedResultRequestDto,
            DocumentStoreRequest,
            DocumentStoreRequest>
    {
        Task<DocumentStoreModel> UploadFileAsync(IFormFile file);
        Task<byte[]> GetFileAsync(string url);

        /// <summary>
        /// get list file theo ids
        /// </summary>
        /// <param name="ids">list id của file cần lấy</param>
        /// <returns></returns>
        Task<List<DocumentStoreResponse>> GetFilesInfoByIdsAsync(List<Guid> ids);

        /// <summary>
        /// upload multifile
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        Task<List<DocumentStoreResponse>> UploadMultiFilesAsync(List<IFormFile> files);
    }
}
