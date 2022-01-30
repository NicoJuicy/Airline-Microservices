using System;

namespace BuildingBlocks.Domain
{
    public interface IAggregate : IAggregate<int>
    {
    }

    public interface IAggregate<TId>
    {
        public TId Id { get;}
    }
}