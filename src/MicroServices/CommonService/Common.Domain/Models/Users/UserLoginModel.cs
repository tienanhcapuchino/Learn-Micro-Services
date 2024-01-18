using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain.Models
{
    public class UserLoginModel
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
