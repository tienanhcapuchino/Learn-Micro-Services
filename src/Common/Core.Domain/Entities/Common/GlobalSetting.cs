using Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities
{
    public class GlobalSetting : BaseEntity
    {
        public GlobalSettingType Type { get; set; }
        public string Detail {  get; set; }
    }
}
