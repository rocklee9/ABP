using PlatForm.Core.Entities.File;
using PlatForm.Core.Models.FileInfo;
using PlatForm.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Guids;
using Volo.Abp.BlobStoring;
using PlatForm.Core.IRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;
using Volo.Abp;
using Microsoft.EntityFrameworkCore;


namespace PlatForm.Core.FileInfo
{
    public class DocumentStoreAppService :
        CrudAppService<DocumentStore,
            DocumentStoreResponse, Guid, PagedAndSortedResultRequestDto,
            DocumentStoreRequest, DocumentStoreRequest>,
        IDocumentStoreAppService
    {
        private readonly IBlobContainer _blobContainer;
        private readonly IGuidGenerator _guidGenerator;
        private readonly IDocumentStoreRepository _documentStoreRepository;

        public DocumentStoreAppService(
            IDocumentStoreRepository documentStoreRepository, IBlobContainer blobContainer, IGuidGenerator guidGenerator) : base(documentStoreRepository)
        {
            _blobContainer = blobContainer;
            _guidGenerator = guidGenerator;
            _documentStoreRepository = documentStoreRepository;
        }

        [HttpPost, Route("api/app/document")]
        public async Task<DocumentStoreModel> UploadFileAsync(IFormFile file)
        {
            try
            {
                var arrFile = file.FileName.Split(".");
                string kieuFile = arrFile[arrFile.Length - 1];
                DocumentStoreRequest newItem = new DocumentStoreRequest
                {
                    Id = _guidGenerator.Create(),
                    TenFile = file.FileName,
                    KieuFile = file.ContentType,
                    KichThuoc = file.Length,
                    FullName = file.FileName
                };
                var tenFile = Path.GetFileNameWithoutExtension(file.FileName);
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    newItem.Url = "/UploadFile/host/default/" + tenFile + "-" + newItem.Id.ToString() + '.' + kieuFile;
                    await _blobContainer.SaveAsync(tenFile + "-" + newItem.Id.ToString() + '.' + kieuFile, memoryStream);
                }
                var documentStore = ObjectMapper.Map<DocumentStoreRequest, DocumentStore>(newItem);
                var item = await _documentStoreRepository.InsertAsync(documentStore);

                return ObjectMapper.Map<DocumentStore, DocumentStoreModel>(item);
            }
            catch (Exception)
            {
                throw new BusinessException("Error");
            }
        }

        [HttpPost("/api/app/document/multiupload")]
        [RequestSizeLimit(52428800)] // 50MB
        public async Task<List<DocumentStoreResponse>> UploadMultiFilesAsync(List<IFormFile> files)
        {
            if (files == null || files.Count == 0)
                throw new BusinessException("file not selected");
            var createUpdateDocumentStoreDtos = new List<DocumentStoreRequest>();
            try
            {
                foreach (var formFile in files)
                {
                    if (formFile.Length > 0)
                    {
                        var arrFile = formFile.FileName.Split(".");
                        string kieuFile = arrFile[arrFile.Length - 1];
                        var documentStoreDto = new DocumentStoreRequest
                        {
                            Id = _guidGenerator.Create(),
                            TenFile = formFile.FileName,
                            KieuFile = formFile.ContentType,
                            KichThuoc = formFile.Length,
                            FullName = formFile.FileName
                        };

                        using (var memoryStream = new MemoryStream())
                        {
                            await formFile.CopyToAsync(memoryStream);
                            var fileName = documentStoreDto.Id.ToString() + "." + kieuFile;
                            documentStoreDto.Url = CoreConsts.FolderSaveFile + "/host/default/" + fileName;
                            await _blobContainer.SaveAsync(fileName, memoryStream);
                            createUpdateDocumentStoreDtos.Add(documentStoreDto);
                        }
                    }
                }
                var documentStores = ObjectMapper.Map<List<DocumentStoreRequest>, List<DocumentStore>>(createUpdateDocumentStoreDtos);
                var results = await _documentStoreRepository.InsertMultiAsync(documentStores);
                return ObjectMapper.Map<List<DocumentStore>, List<DocumentStoreResponse>>(results);
            }
            catch (Exception)
            {
                throw new BusinessException("Error");
            }
        }

        public override Task DeleteAsync(Guid id)
        {
            var Document = this.GetAsync(id).Result;
            _blobContainer.DeleteAsync(Document.FullName);
            return this.DeleteByIdAsync(id);
        }

        public async Task<byte[]> GetFileAsync(string url)
        {
            var nameImage = url.Split(new char[] { '/' });
            return await _blobContainer.GetAllBytesOrNullAsync(nameImage.LastOrDefault());
        }

        public async Task<List<DocumentStoreResponse>> GetFilesInfoByIdsAsync(List<Guid> ids)
        {
            var items = await Repository.Where(s => !s.IsDeleted && ids.Contains(s.Id)).AsNoTracking().ToListAsync();
            return ObjectMapper.Map<List<DocumentStore>, List<DocumentStoreResponse>>(items);
        }

        [HttpGet]
        [Route("/api/app/documentStore/download/{id}")]
        public async Task<IActionResult> DownloadAsync(Guid id)
        {
            var document = await this.GetAsync(id);
            if (document != null)
            {
                string folder = CoreConsts.FolderSaveFile + "/host/default/";
                string name = document.Url.Substring(folder.Length, document.Url.Length - folder.Length);
                byte[] bytes = await _blobContainer.GetAllBytesOrNullAsync(name);
                return new FileContentResult(bytes, document.KieuFile)
                {
                    FileDownloadName = document.FullName
                };
            }
            return null;
        }
    }
}
