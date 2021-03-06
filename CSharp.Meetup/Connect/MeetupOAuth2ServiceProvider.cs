﻿#region License

/*
 * Copyright 2002-2012 the original author or authors.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

#endregion

using System;
using CSharp.Meetup.Api.Impl;
using CSharp.Meetup.Api.Interfaces;
using Spring.Social.OAuth2;

namespace CSharp.Meetup.Connect
{
    /// <summary>
	/// Meetup <see cref="IServiceProvider"/> implementation.
    /// </summary>
    /// <author>Scott Smith</author>
	public class MeetupOAuth2ServiceProvider : AbstractOAuth2ServiceProvider<IMeetup>
    {
        /// <summary>
		/// Creates a new instance of <see cref="MeetupOAuth2ServiceProvider"/>.
        /// </summary>
        /// <param name="consumerKey">The application's API key.</param>
        /// <param name="consumerSecret">The application's API secret.</param>
		public MeetupOAuth2ServiceProvider(string consumerKey, string consumerSecret)
            : base(new OAuth2Template(consumerKey, consumerSecret,
				"https://secure.meetup.com/oauth2/authorize",
                "https://secure.meetup.com/oauth2/access"))
        {
        }

        /// <summary>
        /// Returns an API interface allowing the client application to access protected resources on behalf of a user.
        /// </summary>
        /// <param name="accessToken">The API access token.</param>
        /// <param name="secret">The access token secret.</param>
        /// <returns>A binding to the service provider's API.</returns>
		public override IMeetup GetApi(string accessToken)
        {
			return new MeetupOAuth2Template(accessToken);
        }
    }
}
