using JWT.Exceptions;

namespace Ibanity.Apis.Client.Webhooks
{
    /// <summary>
    /// Invalid webhook signature.
    /// </summary>
    public class InvalidSignatureException : IbanityException
    {
        /// <summary>
        /// Build a new instance.
        /// </summary>
        /// <param name="innerException">JWT exception</param>
        public InvalidSignatureException(SignatureVerificationException innerException) :
            base("Invalid signature: " + innerException.Message, innerException)
        {
        }

        /// <summary>
        /// Build a new instance.
        /// </summary>
        /// <param name="message">Error description</param>
        public InvalidSignatureException(string message) :
            base("Invalid signature: " + message)
        {
        }
    }
}
