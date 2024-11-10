using System;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class DbEventRepository(DataContext context): IDbEventRepository
{
    public async Task AddDbEventAsync(DbEvent dbEvent)
    {
        context.DbEvents.Add( dbEvent );
        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<DbEvent>> GetDbEventsAsync()
    {
        return await context.DbEvents.ToListAsync();
    }
}
