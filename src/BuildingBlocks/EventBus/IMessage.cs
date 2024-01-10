namespace BuildingBlocks.EventBus;

public interface IMessage
{
    public DateTime CreatedAt{ get; set; }
    public Guid MessageID{ get; set; }
    public string IdentityContext { get; set; }
}