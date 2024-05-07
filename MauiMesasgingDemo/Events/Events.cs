using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Messaging;

namespace MauiMessagingDemo.Events
{
    public partial class Event : IEvent
    {
        static Lazy<IEvent> instance = new Lazy<IEvent>(() => new Event(), System.Threading.LazyThreadSafetyMode.PublicationOnly);
        public static IEvent SharedInstance => instance.Value;

        private readonly ThreadSafeWeakReferenceMessenger messenger1 = new ThreadSafeWeakReferenceMessenger();
        // create a messenger object from WeakReferenceMessenger
        private readonly WeakReferenceMessenger messenger = WeakReferenceMessenger.Default;

        public void Publish<Event, Payload>(Payload p) where Event : BaseEvent<Payload>, new()
        {
            //send the event with the payload using the messenger
            messenger1.Send(new Event { Payload = p });
        }

        public void Publish<Event>() where Event : BaseEvent, new()
        {
            messenger1.Send(new Event());
        }

        public void Subscribe<Event>(Action subscriberAction, ThreadOption threadOption = ThreadOption.PublisherThread, bool keepSubscriberReferenceAlive = false) where Event : BaseEvent, new()
        {
            var recipient = new EventRecipient<Event>(subscriberAction);
            messenger1.Register<Event>(recipient, threadOption);
            // register the recipient with the messenger Event type and subscriberAction as the recipient method
        }

        public void Subscribe<Event, Payload>(Action<Payload> subscriberAction, ThreadOption threadOption = ThreadOption.PublisherThread, bool keepSubscriberReferenceAlive = false, Predicate<Payload> filter = null) where Event : BaseEvent<Payload>, new()
        {
            //var recipient = new EventRecipient<Event<Payload>>(subscriberAction, filter);
            // create a new EventRecipient object 
            //var recipient = new EventRecipient<BaseEvent<Payload>>(subscriberAction, filter);
            // register the recipient with the messenger
            //messenger.Register(recipient, threadOption);
        }

        public void Unsubscribe<Event>(Action subscriberAction) where Event : BaseEvent, new()
        {
            var recipient = new EventRecipient<Event>(subscriberAction);
            messenger1.Unregister<Event>(recipient);
        }

        public void Unsubscribe<Event, Payload>(Action<Payload> subscriberAction) where Event : BaseEvent<Payload>, new()
        {
            //var recipient = new EventRecipient<Event<Payload>>(subscriberAction);
            //messenger.Unregister(recipient);
        }
    }
}
