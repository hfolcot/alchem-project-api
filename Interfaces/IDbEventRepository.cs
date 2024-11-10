using API.Entities;

namespace API.Data;

public interface IDbEventRepository
{
    Task<IEnumerable<DbEvent>> GetDbEventsAsync();
    Task AddDbEventAsync(DbEvent dbEvent);
}