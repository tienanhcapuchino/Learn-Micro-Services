using Common.Service.Interfaces;
using Core.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Common.API.Controllers
{
    [Route("~/common-api/[controller]/[action]")]
    [ApiController]
    public class FileStorageController : ControllerBase
    {
        private readonly IFileStorageService _fileStorageService;
        public FileStorageController(IFileStorageService fileStorageService)
        {
            _fileStorageService = fileStorageService;
        }

        [HttpPost("create/bucket")]
        public async Task<ResponseModel> CreateBucket(string bucketName)
        {
            var result = await _fileStorageService.CreateBucket(bucketName);
            return result;
        }
    }
}
