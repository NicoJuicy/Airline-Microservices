using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuildingBlocks.Domain
{
    public interface IAggregate : IAggregate<int>
    {
    }

    public interface IAggregate<TId>
    {
        IEnumerable<IDomainEvent> Events { get; }
        void ClearEvents();
        public TId Id { get;}
    }
}