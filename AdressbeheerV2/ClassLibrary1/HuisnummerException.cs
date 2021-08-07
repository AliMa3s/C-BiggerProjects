using System;
using System.Runtime.Serialization;

namespace ClassLibrary1 {
    [Serializable]
    internal class HuisnummerException : Exception {
        public HuisnummerException() {
        }

        public HuisnummerException(string message) : base(message) {
        }

        public HuisnummerException(string message, Exception innerException) : base(message, innerException) {
        }

        protected HuisnummerException(SerializationInfo info, StreamingContext context) : base(info, context) {
        }
    }
}