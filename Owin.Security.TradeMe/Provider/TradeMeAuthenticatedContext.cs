using System.Security.Claims;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Provider;
using Newtonsoft.Json.Linq;

namespace Hazzik.Owin.Security.TradeMe
{
    /// <summary>
    /// Contains information about the login session as well as the user <see cref="System.Security.Claims.ClaimsIdentity"/>.
    /// </summary>
    public class TradeMeAuthenticatedContext : BaseContext
    {
        /// <summary>
        /// Initializes a <see cref="TradeMeAuthenticatedContext"/>
        /// </summary>
        /// <param name="context">The OWIN environment</param>
        /// <param name="user">The JSON serialized user</param>
        /// <param name="accessToken">TradeMe access token</param>
        /// <param name="accessTokenSecret">TradeMe access token secret</param>
        public TradeMeAuthenticatedContext(
            IOwinContext context,
            JObject user,
            string accessToken,
            string accessTokenSecret)
            : base(context)
        {
            User = user;
            MemberId = TryGetValue(user, "MemberId");
            NickName = TryGetValue(user, "Nickname");
            Email = TryGetValue(user, "Email");
            AccessToken = accessToken;
            AccessTokenSecret = accessTokenSecret;
        }

        /// <summary>
        /// Gets the JSON-serialized user
        /// </summary>
        /// <remarks>
        /// Contains the TradeMe user obtained from TradeMe
        /// </remarks>
        public JObject User { get; private set; }

        /// <summary>
        /// Gets the primary email address for the account
        /// </summary>
        public string Email { get; private set; }

        /// <summary>
        /// Gets the TradeMe user ID
        /// </summary>
        public string MemberId { get; private set; }

        /// <summary>
        /// Gets the TradeMe nickname
        /// </summary>
        public string NickName { get; private set; }

        /// <summary>
        /// Gets the TradeMe access token
        /// </summary>
        public string AccessToken { get; private set; }

        /// <summary>
        /// Gets the TradeMe access token secret
        /// </summary>
        public string AccessTokenSecret { get; private set; }

        /// <summary>
        /// Gets the <see cref="ClaimsIdentity"/> representing the user
        /// </summary>
        public ClaimsIdentity Identity { get; set; }

        /// <summary>
        /// Gets or sets a property bag for common authentication properties
        /// </summary>
        public AuthenticationProperties Properties { get; set; }

        private static string TryGetValue(JObject user, string propertyName)
        {
            JToken value;
            return user.TryGetValue(propertyName, out value) ? value.ToString() : null;
        }
    }
}
