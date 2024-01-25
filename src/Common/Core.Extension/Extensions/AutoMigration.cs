using Core.Service.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extension.Extensions
{
    public static class AutoMigration
    {
        public static async Task UpgradeServiceAsync(IServiceScope scope)
        {
            try
            {
                var services = scope.ServiceProvider.GetServices<IDataUpgradeService>();
                foreach (var service in services)
                {
                    await service.UpgradeAsync();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error when upgrade data with error: " + ex.ToString());
            }
        }
    }
}
