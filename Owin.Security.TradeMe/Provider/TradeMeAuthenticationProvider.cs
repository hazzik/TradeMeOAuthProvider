using System;
using System.Threading.Tasks;

namespace Hazzik.Owin.Security.TradeMe
{
    /// <summary>
    /// Default <see cref="ITradeMeAuthenticationProvider"/> implementation.
    /// </summary>
    public class TradeMeAuthenticationProvider : ITradeMeAuthenticationProvider
    {
        /// <summary>
        /// Initializes a <see cref="TradeMeAuthenticationProvider"/>
        /// </summary>
        public TradeMeAuthenticationProvider()
        {
            OnAuthenticated = context => Task.FromResult<object>(null);
            OnReturnEndpoint = context => Task.FromResult<object>(null);
        }

        /// <summary>
        /// Gets or sets the function that is invoked when the Authenticated method is invoked.
        /// </summary>
        public Func<TradeMeAuthenticatedContext, Task> OnAuthenticated { get; set; }

        /// <summary>
        /// Gets or sets the function that is invoked when the ReturnEndpoint method is invoked.
        /// </summary>
        public Func<TradeMeReturnEndpointContext, Task> OnReturnEndpoint { get; set; }

        /// <summary>
        /// Invoked whenever TradeMe succesfully authenticates a user
        /// </summary>
        /// <param name="context">Contains information about the login session as well as the user <see cref="System.Security.Claims.ClaimsIdentity"/>.</param>
        /// <returns>A <see cref="Task"/> representing the completed operation.</returns>
        public virtual Task Authenticated(TradeMeAuthenticatedContext context)
        {
            return OnAuthenticated(context);
        }

        /// <summary>
        /// Invoked prior to the <see cref="System.Security.Claims.ClaimsIdentity"/> being saved in a local cookie and the browser being redirected to the originally requested URL.
        /// </summary>
        /// <param name="context"></param>
        /// <returns>A <see cref="Task"/> representing the completed operation.</returns>
        public virtual Task ReturnEndpoint(TradeMeReturnEndpointContext context)
        {
            return OnReturnEndpoint(context);
        }
    }
}
