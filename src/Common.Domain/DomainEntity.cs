namespace Common.Domain
{
    public abstract class DomainEntity : IEntity
    {
        public string Id { get; set; }
    }
}
