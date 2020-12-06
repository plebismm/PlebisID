using System;
using System.Collections.Generic;
using System.Linq;

namespace Plebis.Core.Models
{
    public interface IAggregateRoot<out TKey> : IEntity<TKey>
    {
        public long Version { get; }
        IReadOnlyCollection<IDomainEvent<TKey>> Events { get; }
        void ClearEvents();
    }
}
