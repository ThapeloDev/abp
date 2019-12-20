﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Volo.Abp.PermissionManagement.EntityFrameworkCore
{
    public class EfCorePermissionGrantRepository : EfCoreRepository<IPermissionManagementDbContext, PermissionGrant, Guid>, IPermissionGrantRepository
    {
        public EfCorePermissionGrantRepository(IDbContextProvider<IPermissionManagementDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public Task<PermissionGrant> FindAsync(string name, string providerName, string providerKey)
        {
            return Task.FromResult(DbSet
                .FirstOrDefault(s =>
                    s.Name == name &&
                    s.ProviderName == providerName &&
                    s.ProviderKey == providerKey
                ));
        }

        public async Task<List<PermissionGrant>> GetListAsync(string providerName, string providerKey)
        {
            return await DbSet
                .Where(s =>
                    s.ProviderName == providerName &&
                    s.ProviderKey == providerKey
                ).ToListAsync();
        }
    }
}
