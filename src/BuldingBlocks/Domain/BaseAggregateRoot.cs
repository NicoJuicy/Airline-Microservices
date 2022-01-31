using System.Collections.Immutable;

namespace BuildingBlocks.Domain
{
    public abstract class BaseAggregateRoot<TKey> : IAggregate<TKey>
    {
        private readonly Queue<IDomainEvent> _events = new();

        public BaseAggregateRoot()
        {
        }

        protected BaseAggregateRoot(TKey id)
        {
            Id = id;
            LastModified = DateTime.Now;
            IsDeleted = false;
        }

        public DateTime LastModified { get; protected set; }
        public bool IsDeleted { get; protected set; }

        public IEnumerable<IDomainEvent> Events => _events.ToImmutableArray();

        protected void AddEvent(IDomainEvent @event)
        {
            _events.Enqueue(@event);

            // this.Apply(@event);

            // this.Version++;
        }

        public void ClearEvents()
        {
            _events.Clear();
        }

        public TKey Id { get; protected set; }


        public override bool Equals(object obj)
        {
            var entity = obj as BaseAggregateRoot<TKey>;
            return entity != null &&
                   GetType() == entity.GetType() &&
                   EqualityComparer<TKey>.Default.Equals(Id, entity.Id);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(GetType(), Id);
        }

        public static bool operator ==(BaseAggregateRoot<TKey> entity1, BaseAggregateRoot<TKey> entity2)
        {
            return EqualityComparer<BaseAggregateRoot<TKey>>.Default.Equals(entity1, entity2);
        }

        public static bool operator !=(BaseAggregateRoot<TKey> entity1, BaseAggregateRoot<TKey> entity2)
        {
            return !(entity1 == entity2);
        }
    }
}