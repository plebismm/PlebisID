using Plebis.Core.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Plebis.Core
{
    public interface IEventsService<TA, TKey>
        where TA : class, IAggregateRoot<TKey>
    {
        Task PersistAsync(TA aggregateRoot);
        Task<TA> RehydrateAsync(TKey key);
    }
}
