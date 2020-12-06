using MediatR;
using System;

namespace Plebis.Core.EventBus
{
    public class EventReceived<TE> : INotification
    {
        public EventReceived(TE @event)
        {
            Event = @event;
        }

        public TE Event { get; }
    }
}
