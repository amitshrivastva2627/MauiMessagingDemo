using CommunityToolkit.Mvvm.Messaging;
using MauiMessagingDemo.Events;
using MauiMessagingDemo.Messages;

namespace MauiMessagingDemo.ViewModels
{
    public class MainPageViewModel
    {
        protected IEvent EventService { get; }

        public MainPageViewModel()
        {
            WeakReferenceMessenger.Default.Register<MyMessage>(this, (r, m) =>
            {
                OnMessageReceived(m.Value);
            });
            EventService = Event.SharedInstance;
            EventService.Subscribe<LanguageChangedEvent>(HandleLanguageChanged, ThreadOption.UIThread);
        }

        private void HandleLanguageChanged()
        {
            throw new NotImplementedException();
        }

        private static void OnMessageReceived(string message)
        {
            Shell.Current.DisplayAlert("Message received", message, "OK");
        }
    }
}
