using System;
using System.Collections.Generic;
using System.Text;
using GalaSoft.MvvmLight.Messaging;

namespace OnThisDay.Messaging
{
    public class ShowEventDetailMessage : MessageBase
    {
        public string Name;

        public ShowEventDetailMessage(string name)
        {
            Name = name;
        }
    }
}
