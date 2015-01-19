using System;
using Owin;

namespace Hazzik.Owin.Security.TradeMe
{
    /// <summary>
    /// Extension methods for using <see cref="TradeMeAuthenticationMiddleware"/>
    /// </summary>
    public static class TradeMeAuthenticationExtensions
    {
        /// <summary>
        /// Authenticate users using TradeMe
        /// </summary>
        /// <param name="app">The <see cref="IAppBuilder"/> passed to the configuration method</param>
        /// <param name="options">Middleware configuration options</param>
        /// <returns>The updated <see cref="IAppBuilder"/></returns>
        public static IAppBuilder UseTradeMeAuthentication(this IAppBuilder app, TradeMeAuthenticationOptions options)
        {
            if (app == null)
            {
                throw new ArgumentNullException("app");
            }
            if (options == null)
            {
                throw new ArgumentNullException("options");
            }

            app.Use(typeof(TradeMeAuthenticationMiddleware), app, options);
            return app;
        }

        /// <summary>
        /// Authenticate users using TradeMe
        /// </summary>
        /// <param name="app">The <see cref="IAppBuilder"/> passed to the configuration method</param>
        /// <param name="consumerKey">The TradeMe-issued consumer key</param>
        /// <param name="consumerSecret">The TradeMe-issued consumer secret</param>
        /// <returns>The updated <see cref="IAppBuilder"/></returns>
        public static IAppBuilder UseTradeMeAuthentication(
            this IAppBuilder app,
            string consumerKey,
            string consumerSecret)
        {
            return UseTradeMeAuthentication(
                app,
                new TradeMeAuthenticationOptions
                {
                    ConsumerKey = consumerKey,
                    ConsumerSecret = consumerSecret,
                });
        }
    }
}
