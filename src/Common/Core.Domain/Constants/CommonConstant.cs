using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Constants
{
    public static class TableNameConstant
    {
        public const string GlobalSettingTable = "GlobalSetting";
        public const string DepartmentTable = "Department";
    }
    public enum MicroServiceComponent : byte
    {
        Common = 1,
        Project = 2
    }
    public static class ConfigurationKeys
    {
        public const string MicroserviceEndpoints = "MicroserviceEndpoints";
        public const string MicroserviceEndpointsAPIGW = "MicroserviceEndpointsAPIGW";
        public const string AWS = "AWS";
        public const string SecretKey = "SecretKey";
        public const string AccessKey = "AccessKey";
        public const string CoreDbConnectionString = "CoreDbConnectStr";
    }
    public class MicroServicesPorts
    {
        public const int Common = 15001;
        public const int Project = 15002;
    }
    public static class ApplicationHostName
    {
        public const string APIGateWay = "API Gateway";
        public const string Common = "Common Service";
        public const string Project = "Project Service";
    }

    public static class RegexFunction
    {
        public const string PhoneNumberRegex = @"^(03|05|07|08|09)[0-9]{8}$";
        public const string EmailRegex = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
    }

    public static class RoleName
    {
        public const string Admin = "Admin";
        public const string Manager = "Manager";
        public const string Leader = "Leader";
        public const string Employee = "Employee";
        public static readonly List<string> UserRoles = new List<string>() { Admin, Manager, Leader, Employee };
    }

}
