using AutoMapper;
using Common.Domain.Models.Users;
using Common.Service.Interfaces;
using Core.Domain.Entities;
using Core.Domain.Models;
using Core.Extension;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Common.API.Controllers
{

    public class UserController : APIBaseController
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(IHttpContextAccessor contextAccessor,
            IUserService userService,
            IMapper mapper) : base(contextAccessor)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<ResponseModel> RegisterUser([FromBody] UserRegisterModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));
                    string errorList = string.Join("; ", errors);
                    return new ResponseModel()
                    {
                        Data = model,
                        Message = errorList,
                        StatusCode = HttpStatusCode.BadRequest
                    };
                }
                var user = _mapper.Map<User>(model);
                var result = await _userService.Register(user, model.Password);
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
