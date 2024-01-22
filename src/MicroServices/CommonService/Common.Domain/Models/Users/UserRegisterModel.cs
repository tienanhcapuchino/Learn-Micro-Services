using Core.Domain.Constants;
using Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain.Models.Users
{
    public class UserRegisterModel
    {
        public required string UserName { get; set; }
        public required string FullName { get; set; }
        [RegularExpression(RegexFunction.EmailRegex, ErrorMessage = "Invalid email address!")]
        public required string Email { get; set; }
        [RegularExpression(RegexFunction.PhoneNumberRegex, ErrorMessage = "Invalid phone number!")]
        public required string PhoneNumber { get; set; }
        public required Gender Gender { get; set; }
        public required DateTime DateOfBirth { get; set; }
        public required string Password { get; set; }
        [Compare("Password", ErrorMessage = "The passwords do not match.")]
        public required string RePassword { get; set; }
    }
}
