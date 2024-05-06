using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Messaging;

namespace MauiMessagingDemo.Events
{
    public class EventRecipient<TMessage> : IRecipient<TMessage> where TMessage : class
    {
        private readonly Action<object, TMessage> action;
        private readonly Predicate<TMessage> filter;

        public EventRecipient(Action<object, TMessage> action, Predicate<TMessage> filter = null)
        {
            this.action = action;
            this.filter = filter;
        }

        public void Receive(TMessage message)
        {
            if (filter == null || filter(message))
            {
                action(this, message);
            }
        }
    }
}
