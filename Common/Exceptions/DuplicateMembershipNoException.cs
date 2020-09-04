using System;
using System.Runtime.Serialization;

namespace ClassManager.Common.Exceptions
{
    [Serializable]
    internal class DuplicateMembershipNoException : Exception
    {
        public DuplicateMembershipNoException()
        {
        }

        public DuplicateMembershipNoException(string message) : base(message)
        {
        }

        public DuplicateMembershipNoException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DuplicateMembershipNoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}