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
    public enum MicroServiceComponent: byte
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
}
