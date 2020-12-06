using Plebis.Core.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Plebis.Core
{
    public interface IEventsRepository<TA, TKey>
        where TA : class, IAggregateRoot<TKey>
    {
        Task AppendAsync(TA aggregateRoot);
        Task<TA> RehydrateAsync(TKey key);
    }
}
