using System;
using System.Collections.Generic;
using System.Text;
using GalaSoft.MvvmLight.Messaging;

namespace OnThisDay.Messaging
{
    public class ShowEventDetailMessage : MessageBase
    {
        public ShowEventDetailMessage(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
