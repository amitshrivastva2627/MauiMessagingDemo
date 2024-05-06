using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace MauiMessagingDemo.Events
{
    public class BaseEvent : ValueChangedMessage<BaseEvent>
    {
        public BaseEvent() : base(null)
        {
        }
    }

    public class BaseEvent<TPayload> : ValueChangedMessage<BaseEvent<TPayload>>
    {
        public TPayload Payload { get; set; }

        public BaseEvent(TPayload payload) : base(null)
        {
            Payload = payload;
        }
    }
}
