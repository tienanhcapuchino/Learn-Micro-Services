﻿using Common.Domain.Models;
using Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Service.Interfaces
{
    public interface IUserService
    {
        Task<ResponseModel> Login(UserLoginModel model);
        Task<ResponseModel> Register();
    }
}
