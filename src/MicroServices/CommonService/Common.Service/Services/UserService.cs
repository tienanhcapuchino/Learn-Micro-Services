using Common.Domain.Models;
using Common.Domain.Models.Users;
using Common.Service.Interfaces;
using Core.Domain.Entities;
using Core.Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Core.Domain.Utility;
using Core.Domain.Constants;

namespace Common.Service.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UserService(UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public Task<ResponseModel> Login(UserLoginModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel> Register(User model, string password)
        {
            try
            {
                var result = new ResponseModel()
                {
                    Data = model,
                    Message = $"Register user successfully!",
                    StatusCode = HttpStatusCode.OK,
                };
                var resultAdd = await _userManager.CreateAsync(model, password);
                if (!resultAdd.Succeeded)
                {
                    return new ResponseModel()
                    {
                        Data = model,
                        Message = resultAdd.Errors.ToString(),
                        StatusCode = HttpStatusCode.BadRequest,
                    };
                }

                //add to user role table
                var isExistEmployeeRole = await _roleManager.RoleExistsAsync(RoleName.Employee);
                if (!isExistEmployeeRole)
                {
                    await _roleManager.CreateAsync(new IdentityRole(RoleName.Employee));
                }
                await _userManager.AddToRoleAsync(model, RoleName.Employee);
                return result;
            }
            catch (Exception ex)
            {
                return new ResponseModel()
                {
                    Data = ex,
                    Message = ex.Message,
                    StatusCode = HttpStatusCode.BadRequest
                };
            }
        }
    }
}
