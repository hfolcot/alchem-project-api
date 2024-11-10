using API.Data;

public class PeriodicDbEventService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly TimeSpan _interval = TimeSpan.FromSeconds(180); // Set interval as needed

    public PeriodicDbEventService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
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
            var context = scope.ServiceProvider.GetRequiredService<DataContext>();

            var newEvent = new API.Entities.DbEvent
            {
                EventType = new Random().Next(1, 5),  // Random event type
                Timestamp = DateTime.Now,
                Database = "SampleDatabase",           // Or any other logic for database name
                Severity = new Random().Next(1, 5)     // Random severity level
            };

            context.DbEvents.Add(newEvent);
            await context.SaveChangesAsync();
        }
    }
}
