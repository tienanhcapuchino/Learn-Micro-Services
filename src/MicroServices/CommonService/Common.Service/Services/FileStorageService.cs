using Amazon.S3;
using Common.Service.Interfaces;
using Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Service.Services
{
    public class FileStorageService : IFileStorageService
    {
        private readonly IAmazonS3 _s3Client;
        public FileStorageService(IAmazonS3 s3Client)
        {
            _s3Client = s3Client;
        }

        public async Task<ResponseModel> CreateBucket(string bucketName)
        {
            try
            {
                var result = new ResponseModel()
                {
                    Data = bucketName,
                    Message = "Create successfully",
                    StatusCode = System.Net.HttpStatusCode.OK,
                };
                var bucketExists = await _s3Client.DoesS3BucketExistAsync(bucketName);
                if (bucketExists)
                {
                    return new ResponseModel()
                    {
                        Data = bucketName,
                        Message = "Bucket name already existed",
                        StatusCode = System.Net.HttpStatusCode.BadRequest
                    };
                }
                await _s3Client.PutBucketAsync(bucketName);
                return result;
            }
            catch(Exception ex)
            {
                return new ResponseModel
                {
                    Data = ex,
                    Message = ex.Message,
                    StatusCode = System.Net.HttpStatusCode.BadRequest
                };
            }
        }
    }
}
