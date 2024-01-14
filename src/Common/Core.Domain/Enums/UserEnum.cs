using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Enums
{
    public enum UserStatus: byte
    {
        Active = 0,
        Inactive = 1,
        Deleted = 2
    }
    public enum Gender: byte
    {
        Unknown = 0,
        Male = 1,
        Female = 2
    }
}
