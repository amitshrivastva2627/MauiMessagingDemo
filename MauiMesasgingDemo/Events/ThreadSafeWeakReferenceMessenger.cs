using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Messaging;

namespace MauiMessagingDemo.Events
{
    public class ThreadSafeWeakReferenceMessenger
    {
        private readonly WeakReferenceMessenger messenger;

        public ThreadSafeWeakReferenceMessenger()
        {
            messenger = WeakReferenceMessenger.Default;
        }

        public void Register<TMessage>(IRecipient<TMessage> recipient, ThreadOption threadOption) where TMessage : class
        {
            if (threadOption == ThreadOption.PublisherThread)
            {
                messenger.Register(recipient);
            }
            else
            {
                messenger.Register(new UIThreadRecipient<TMessage>(recipient));
            }
        }

        public void Unregister<TMessage>(IRecipient<TMessage> recipient) where TMessage : class
        {
            // Unregister the recipient from the messenger
            messenger.Unregister<TMessage>(recipient);
        }

        public void Send<TMessage>(TMessage message) where TMessage : class
        {
            messenger.Send(message);
        }

        private class UIThreadRecipient<T> : IRecipient<T> where T : class
        {
            private readonly IRecipient<T> recipient;

            public UIThreadRecipient(IRecipient<T> recipient)
            {
                this.recipient = recipient;
            }

            public void Receive(T message)
            {
                MainThread.BeginInvokeOnMainThread(() => recipient.Receive(message));
            }
        }
    }
}
