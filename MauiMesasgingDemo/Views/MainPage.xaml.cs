using CommunityToolkit.Mvvm.Messaging;
using MauiMessagingDemo.ViewModels;
using MauiMessagingDemo.Messages;
using MauiMessagingDemo.Events;

namespace MauiMessagingDemo;

public partial class MainPage : ContentPage
{
    protected IEvent EventService { get; }
    public MainPage(MainPageViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
        EventService = Event.SharedInstance;
    }

    private void OnSendMessageClicked(object sender, EventArgs e)
	{
		WeakReferenceMessenger.Default.Send(new MyMessage("Hello World!"));
		EventService.Publish<LanguageChangedEvent>();

    }
}

