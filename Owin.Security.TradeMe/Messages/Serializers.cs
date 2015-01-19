﻿using Microsoft.Owin.Security.DataHandler.Serializer;

namespace Hazzik.Owin.Security.TradeMe.Messages
{
    /// <summary>
    /// Provides access to a request token serializer
    /// </summary>
    public static class Serializers
    {
        static Serializers()
        {
            RequestToken = new RequestTokenSerializer();
        }

        /// <summary>
        /// Gets or sets a statically-avaliable serializer object. The value for this property will be <see cref="RequestTokenSerializer"/> by default.
        /// </summary>
        public static IDataSerializer<RequestToken> RequestToken { get; set; }
    }
}
