namespace SSGP.Domain.Core;

public abstract class Entity
{
    private readonly List<DomainEvent> _domainEvents = new List<DomainEvent>();
    public IEnumerable<DomainEvent> DomainEvents => _domainEvents;

    protected void AddDomainEvent(DomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    protected void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}