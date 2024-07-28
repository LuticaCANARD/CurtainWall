using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CurtainWall.BackEnd.Data.Enum;

namespace CurtainWall.BackEnd.Data.Interface
{

    internal interface IPublishable<T> where T : notnull
    {
        Dictionary<T,ISubscriscriptable> Subscriscripts { get; }
        public void SendMessageToAll(MessageType type, params object? [] values);
        public void SendMessageToTarget(object key,MessageType type, params object? [] values);
        public void AddSubscribe(T key,ISubscriscriptable subscribe);
        public void RemoveSubscribe(ISubscriscriptable subscribe);
        public object GetMessageFromSubscriber(MessageType type,params object?[] values);
    }

}
