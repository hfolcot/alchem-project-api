using System;

namespace API.Entities;

public class DbEvent
{
    public int Id { get; set; }
    public int EventType { get; set; }
    public DateTime Timestamp { get; set; }
    public string Database { get; set; } = "";
    public int Severity { get; set; }
}
