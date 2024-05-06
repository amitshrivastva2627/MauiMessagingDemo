﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiMessagingDemo.Events
{
    abstract public class BaseViewModel : INotifyPropertyChanged
    {
        protected IEvent EventService { get; }

        public BaseViewModel()
        {
            EventService = Event.SharedInstance;
        }

        public abstract event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnAppearing()
        {
            // Subscribe to the BluetoothStateChangedEvent
            if (EventService != null)
            {
                // Subscribe to the BluetoothStateChangedEvent
                EventService.Subscribe<BluetoothStateChangedEvent, bool>(HandleBluetoothStateChanged, ThreadOption.UIThread);
            }
        }

        public virtual void OnDisappearing()
        {

            EventService.Unsubscribe<BluetoothStateChangedEvent, bool>(HandleBluetoothStateChanged);
        }

        private void HandleEvents(object sender, BaseEvent eventArgs)
        {
            // Handle the BaseEvent
        }

        private void HandleBluetoothStateChanged(bool isBluetoothEnabled)
        {
            // Handle the BluetoothStateChangedEvent
            // ...
        }
    }
}
