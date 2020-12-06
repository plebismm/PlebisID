using Plebis.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plebis.Core.EventBus
{
    public interface IEventProducer<in TA, in TKey>
       where TA : IAggregateRoot<TKey>
    {
        Task DispatchAsync(TA aggregateRoot);
    }
}
