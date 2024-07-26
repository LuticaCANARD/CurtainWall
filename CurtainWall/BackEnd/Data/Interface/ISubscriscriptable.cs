using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CurtainWall.BackEnd.Data.Enum;

namespace CurtainWall.BackEnd.Data.Interface
{
    internal interface ISubscriscriptable
    {
        IPublishable<object> Publisher { get; }
        public void GetMessage(MessageType type);
        public void SendMessageToPublisher(MessageType type, params object?[] message);

    }
}
