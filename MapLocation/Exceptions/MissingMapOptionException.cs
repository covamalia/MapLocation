using System;

namespace MapLocation.Exceptions



{
        
    [Serializable]
    public class MissingMapOptionException : Exception
    {
        public MissingMapOptionException() { }
        public MissingMapOptionException(string message) : base(message) { }
        public MissingMapOptionException(string message, Exception inner) : base(message, inner) { }
        protected MissingMapOptionException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
