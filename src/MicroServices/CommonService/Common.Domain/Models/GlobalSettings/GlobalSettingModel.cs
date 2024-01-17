using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain.Models
{
    public class FileS3StorageSetting
    {
        public string AWSKey { get; set; } = "";
        public string AWSSecretKey { get; set; } = "";
    }
}
