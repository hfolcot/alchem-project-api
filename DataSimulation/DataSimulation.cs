using API.Data;
using API.Entities;
using API.SignalR;
using Microsoft.AspNetCore.SignalR;


public class PeriodicDbEventService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IHubContext<DbEventHub> _hubContext;
    private readonly TimeSpan _interval = TimeSpan.FromSeconds(30);

    public PeriodicDbEventService(IServiceProvider serviceProvider, IHubContext<DbEventHub> hubContext)
    {
        _serviceProvider = serviceProvider;
        _hubContext = hubContext;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await AddDbEventAsync();
            await Task.Delay(_interval, stoppingToken);
        }
    }

    private async Task AddDbEventAsync()
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var repository = scope.ServiceProvider.GetRequiredService<IDbEventRepository>();

            var newEvent = new DbEvent
            {
                EventType = new Random().Next(0, 4),
                Timestamp = DateTime.Now,
                Database = $"DB_Prod_0{new Random().Next(0, 4)}",
                Severity = new Random().Next(0, 4)
            };

            await repository.AddDbEventAsync(newEvent);

            await _hubContext.Clients.All.SendAsync("ReceiveDbEvent", newEvent);
        }
    }
}