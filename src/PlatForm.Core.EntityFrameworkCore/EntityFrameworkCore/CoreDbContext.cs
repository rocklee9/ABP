﻿using Microsoft.EntityFrameworkCore;
using PlatForm.Core.Entities.Commons;
using PlatForm.Core.Entities.File;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.IdentityServer.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace PlatForm.Core.EntityFrameworkCore
{
    [ReplaceDbContext(typeof(IIdentityDbContext))]
    [ReplaceDbContext(typeof(ITenantManagementDbContext))]
    [ConnectionStringName("Default")]
    public class CoreDbContext : 
        AbpDbContext<CoreDbContext>,
        IIdentityDbContext,
        ITenantManagementDbContext
    {
        /* Add DbSet properties for your Aggregate Roots / Entities here. */
        
        #region Entities from the modules
        
        /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
         * and replaced them for this DbContext. This allows you to perform JOIN
         * queries for the entities of these modules over the repositories easily. You
         * typically don't need that for other modules. But, if you need, you can
         * implement the DbContext interface of the needed module and use ReplaceDbContext
         * attribute just like IIdentityDbContext and ITenantManagementDbContext.
         *
         * More info: Replacing a DbContext of a module ensures that the related module
         * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
         */
        
        //Identity
        public DbSet<IdentityUser> Users { get; set; }
        public DbSet<IdentityRole> Roles { get; set; }
        public DbSet<IdentityClaimType> ClaimTypes { get; set; }
        public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
        public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
        public DbSet<IdentityLinkUser> LinkUsers { get; set; }
        
        // Tenant Management
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

        public DbSet<BoPhan> BoPhans { get; set; }
        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<DocumentStore> DocumentStores { get; set; }

        #endregion

        public CoreDbContext(DbContextOptions<CoreDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /* Include modules to your migration db context */

            builder.ConfigurePermissionManagement();
            builder.ConfigureSettingManagement();
            builder.ConfigureBackgroundJobs();
            builder.ConfigureAuditLogging();
            builder.ConfigureIdentity();
            builder.ConfigureIdentityServer();
            builder.ConfigureFeatureManagement();
            builder.ConfigureTenantManagement();

            /* Configure your own tables/entities inside here */

            builder.Entity<NhanVien>(b =>
            {
                b.ToTable(CoreConsts.DbTablePrefix + "NhanViens", CoreConsts.DbCommonSchema);
                b.Property(s => s.Name).HasMaxLength(255).IsRequired(true);
                b.Property(s => s.Tuoi);
                b.Property(s => s.CMND).HasMaxLength(20).IsRequired(true);
                b.HasOne(t => t.BoPhan).WithMany(l => l.NhanViens).HasForeignKey(t => t.BoPhanId);
                b.ConfigureByConvention();
            });

            builder.Entity<BoPhan>(b =>
            {
                b.ToTable(CoreConsts.DbTablePrefix + "BoPhans", CoreConsts.DbCommonSchema);
                b.Property(s => s.Name).HasMaxLength(255).IsRequired(true);
                b.Property(s => s.GhiChu).HasMaxLength(1000).IsRequired(true);
                b.ConfigureByConvention();
            });

            builder.Entity<DocumentStore>(b =>
            {
                b.ToTable(CoreConsts.DbTablePrefix + "DocumentStores", CoreConsts.DbCommonSchema);
                b.Property(s => s.Url).HasMaxLength(255).IsRequired(true);
                b.Property(s => s.KieuFile).HasMaxLength(255).IsRequired(true);
                b.Property(s => s.FullName).HasMaxLength(255);
                b.Property(s => s.Cached).HasMaxLength(255);
                b.ConfigureByConvention();
            });
        }
    }
}
