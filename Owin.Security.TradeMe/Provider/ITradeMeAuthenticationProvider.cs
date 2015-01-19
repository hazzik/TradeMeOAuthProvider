using System.Threading.Tasks;

namespace Hazzik.Owin.Security.TradeMe
{
    /// <summary>
    /// Specifies callback methods which the <see cref="TradeMeAuthenticationMiddleware"></see> invokes to enable developer control over the authentication process. />
    /// </summary>
    public interface ITradeMeAuthenticationProvider
    {
        /// <summary>
        /// Invoked whenever TradeMe succesfully authenticates a user
        /// </summary>
        /// <param name="context">Contains information about the login session as well as the user <see cref="System.Security.Claims.ClaimsIdentity"/>.</param>
        /// <returns>A <see cref="Task"/> representing the completed operation.</returns>
        Task Authenticated(TradeMeAuthenticatedContext context);

        /// <summary>
        /// Invoked prior to the <see cref="System.Security.Claims.ClaimsIdentity"/> being saved in a local cookie and the browser being redirected to the originally requested URL.
        /// </summary>
        /// <param name="context"></param>
        /// <returns>A <see cref="Task"/> representing the completed operation.</returns>
        Task ReturnEndpoint(TradeMeReturnEndpointContext context);
    }
}
