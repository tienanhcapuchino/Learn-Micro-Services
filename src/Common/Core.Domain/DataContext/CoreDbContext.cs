using Core.Domain.Configuration;
using Core.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.DataContext
{
    public class CoreDbContext : IdentityDbContext<User>
    {
        public CoreDbContext(DbContextOptions<CoreDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new GlobalSettingConfiguration());
            base.OnModelCreating(builder);
        }

        #region Entities
        public DbSet<GlobalSetting> GlobalSettings { get; set; }
        #endregion

    }
}
