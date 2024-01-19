using Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Service.Interfaces
{
    public interface IFileStorageService
    {
        /// <summary>
        /// Create a bucket in AWS S3
        /// </summary>
        /// <param name="bucketName"></param>
        /// <returns></returns>
        Task<ResponseModel> CreateBucket(string bucketName);
    }
}
