﻿using Neutronium.MVVMComponents;
using Neutronium.MVVMComponents.Relay;
using DriverExplorer.Application.WindowServices;

namespace DriverExplorer.ViewModel.Modal {
    public class MessageModalViewModel {
        public string Title { get; }
        public string Message { get; }
        public string OkMessage { get; }

        public ISimpleCommand OkCommand { get; }

        public MessageModalViewModel(MessageInformation messageInformation) {
            Title = messageInformation.Title;
            Message = messageInformation.Message;
            OkMessage = messageInformation.OkMessage;

            OkCommand = new RelaySimpleCommand(Ok);
        }

        protected virtual void Ok() {
        }
    }
}