using Microsoft.Owin.Security;

namespace Hazzik.Owin.Security.TradeMe.Messages
{
    /// <summary>
    /// TradeMe request token
    /// </summary>
    public class RequestToken
    {
        /// <summary>
        /// Gets or sets the TradeMe token
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Gets or sets the TradeMe token secret
        /// </summary>
        public string TokenSecret { get; set; }

        public bool CallbackConfirmed { get; set; }

        /// <summary>
        /// Gets or sets a property bag for common authentication properties
        /// </summary>
        public AuthenticationProperties Properties { get; set; }
    }
}
