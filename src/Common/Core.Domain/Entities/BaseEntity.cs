using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public long CreatedDate { get; set; }
        public long UpdatedDate { get; set; }
    }
}
