using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiMessagingDemo.Events
{
    public interface IEvent
    {
        void Publish<Event, Payload>(Payload p) where Event : BaseEvent<Payload>, new();
        void Publish<Event>() where Event : BaseEvent, new();
        void Subscribe<Event>(Action subscriberAction, ThreadOption threadOption = ThreadOption.PublisherThread, bool keepSubscriberReferenceAlive = false) where Event : BaseEvent, new();
        void Subscribe<Event, Payload>(Action<Payload> subscriberAction, ThreadOption threadOption = ThreadOption.PublisherThread, bool keepSubscriberReferenceAlive = false, Predicate<Payload> filter = null) where Event : BaseEvent<Payload>, new();
        void Unsubscribe<Event>(Action subscriberAction) where Event : BaseEvent, new();
        void Unsubscribe<Event, Payload>(Action<Payload> subscriberAction) where Event : BaseEvent<Payload>, new();
    }
}
