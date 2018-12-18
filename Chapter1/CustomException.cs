using System;
using System.Runtime.Serialization;

namespace Chapter1
{
    [Serializable]
    public class CustomException: Exception, ISerializable
    {
        public int OrderId { get; private set; }

        public CustomException(int orderId)
        {
            OrderId = orderId;
            this.HelpLink = "http://www.mydomain.com/infoaboutexception";
        }

        public CustomException(int orderId, string message)
            : base(message)
        {
            OrderId = orderId;
            this.HelpLink = "http://www.mydomain.com/infoaboutexception";
        }

        public CustomException(int orderId, string message, Exception innerException)
            : base(message, innerException)
        {
            OrderId = orderId;
            this.HelpLink = "http://www.mydomain.com/infoaboutexception";
        }

        protected CustomException(SerializationInfo info, StreamingContext context)
        {
            OrderId = (int)info.GetValue("OrderId", typeof(int));
        }
      
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("OrderId", OrderId, typeof(int));
        }
    }
}
