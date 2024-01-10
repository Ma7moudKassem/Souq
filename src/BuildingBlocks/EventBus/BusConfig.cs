namespace BuildingBlocks.EventBus;

public class BusConfig
{
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? QueueUrl { get; set; }
    public string? QueueName { get; set; }
    public int Retry { get; set; }
    public string? ExchangeType { get; set; }
}