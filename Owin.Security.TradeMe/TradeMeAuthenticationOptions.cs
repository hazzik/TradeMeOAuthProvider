using System;
using System.Collections.Generic;
using System.Net.Http;
using Hazzik.Owin.Security.TradeMe.Messages;
using Microsoft.Owin;
using Microsoft.Owin.Security;

namespace Hazzik.Owin.Security.TradeMe
{
    /// <summary>
    /// Options for the TradeMe authentication middleware.
    /// </summary>
    public class TradeMeAuthenticationOptions : AuthenticationOptions
    {
        private const string RequestTokenEndpoint = "https://secure.trademe.co.nz/Oauth/RequestToken";
        private const string AuthorizationEndpoint = "https://secure.trademe.co.nz/Oauth/Authorize";
        private const string AccessTokenEndpoint = "https://secure.trademe.co.nz/Oauth/AccessToken";
        private const string UserProfileEndpoint = "https://api.trademe.co.nz/v1/MyTradeMe/Summary.json";

        public class TradeMeAuthenticationEndpoints
        {
            /// <summary>
            /// Endpoint which is used to exchange code to request token
            /// </summary>
            /// <remarks>
            /// Defaults to https://secure.tmsandbox.co.nz/Oauth/RequestToken
            /// </remarks>
            public string RequestTokenEndpoint { get; set; }

            /// <summary>
            /// Endpoint which is used to redirect users to request TradeMe access
            /// </summary>
            /// <remarks>
            /// Defaults to https://secure.tmsandbox.co.nz/Oauth/Authorize
            /// </remarks>
            public string AuthorizationEndpoint { get; set; }

            /// <summary>
            /// Endpoint which is used to exchange code for access token
            /// </summary>
            /// <remarks>
            /// Defaults to https://secure.tmsandbox.co.nz/Oauth/AccessToken
            /// </remarks>
            public string AccessTokenEndpoint { get; set; }

            /// <summary>
            /// Endpoint which is used to obtain user information after authentication
            /// </summary>
            /// <remarks>
            /// Defaults to https://api.tmsandbox.co.nz/v1/MyTradeMe/Summary.json
            /// </remarks>
            public string UserProfileEndpoint { get; set; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TradeMeAuthenticationOptions"/> class.
        /// </summary>
        public TradeMeAuthenticationOptions()
            : base(Constants.DefaultAuthenticationType)
        {
            Caption = Constants.DefaultAuthenticationType;
            CallbackPath = new PathString("/signin-trademe");
            AuthenticationMode = AuthenticationMode.Passive;
            BackchannelTimeout = TimeSpan.FromSeconds(60);
            BackchannelCertificateValidator = null;
            Endpoints = new TradeMeAuthenticationEndpoints
            {
                RequestTokenEndpoint = RequestTokenEndpoint,
                AuthorizationEndpoint = AuthorizationEndpoint,
                AccessTokenEndpoint = AccessTokenEndpoint,
                UserProfileEndpoint = UserProfileEndpoint,

            };
            Scope = new List<string>
            {
                "MyTradeMeRead"
            };
        }

        public TradeMeAuthenticationEndpoints Endpoints { get; set; }

        /// <summary>
        /// A list of permissions to request.
        /// </summary>
        public IList<string> Scope { get; set; }

        /// <summary>
        /// Gets or sets the consumer key used to communicate with TradeMe.
        /// </summary>
        /// <value>The consumer key used to communicate with TradeMe.</value>
        public string ConsumerKey { get; set; }

        /// <summary>
        /// Gets or sets the consumer secret used to sign requests to TradeMe.
        /// </summary>
        /// <value>The consumer secret used to sign requests to TradeMe.</value>
        public string ConsumerSecret { get; set; }

        /// <summary>
        /// Gets or sets timeout value in milliseconds for back channel communications with TradeMe.
        /// </summary>
        /// <value>
        /// The back channel timeout.
        /// </value>
        public TimeSpan BackchannelTimeout { get; set; }

        /// <summary>
        /// Gets or sets the a pinned certificate validator to use to validate the endpoints used
        /// in back channel communications belong to TradeMe.
        /// </summary>
        /// <value>
        /// The pinned certificate validator.
        /// </value>
        /// <remarks>If this property is null then the default certificate checks are performed,
        /// validating the subject name and if the signing chain is a trusted party.</remarks>
        public ICertificateValidator BackchannelCertificateValidator { get; set; }

        /// <summary>
        /// The HttpMessageHandler used to communicate with TradeMe.
        /// This cannot be set at the same time as BackchannelCertificateValidator unless the value 
        /// can be downcast to a WebRequestHandler.
        /// </summary>
        public HttpMessageHandler BackchannelHttpHandler { get; set; }

        /// <summary>
        /// Get or sets the text that the user can display on a sign in user interface.
        /// </summary>
        public string Caption
        {
            get { return Description.Caption; }
            set { Description.Caption = value; }
        }

        /// <summary>
        /// The request path within the application's base path where the user-agent will be returned.
        /// The middleware will process this request when it arrives.
        /// Default value is "/signin-TradeMe".
        /// </summary>
        public PathString CallbackPath { get; set; }

        /// <summary>
        /// Gets or sets the name of another authentication middleware which will be responsible for actually issuing a user <see cref="System.Security.Claims.ClaimsIdentity"/>.
        /// </summary>
        public string SignInAsAuthenticationType { get; set; }

        /// <summary>
        /// Gets or sets the type used to secure data handled by the middleware.
        /// </summary>
        public ISecureDataFormat<RequestToken> StateDataFormat { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ITradeMeAuthenticationProvider"/> used to handle authentication events.
        /// </summary>
        public ITradeMeAuthenticationProvider Provider { get; set; }
    }
}
