﻿// Copyright 2007-2008 The Apache Software Foundation.
//  
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use 
// this file except in compliance with the License. You may obtain a copy of the 
// License at 
// 
//     http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software distributed 
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, either express or implied. See the License for the 
// specific language governing permissions and limitations under the License.
namespace Magnum.Channels
{
	using System.Threading;
	using Configuration;
	using Configuration.Internal;


	public static class ExtensionsForSynchronizedChannels
	{
		public static SynchronizedChannelConnectionConfigurator<TChannel> OnCurrentSynchronizationContext<TChannel>(
			this ChannelConnectionConfigurator<TChannel> configurator)
		{
			var synchronizedConfigurator = new SynchronizedChannelConnectionConfiguratorImpl<TChannel>();

			configurator.SetChannelConfigurator(synchronizedConfigurator);

			return synchronizedConfigurator;
		}

		public static SynchronizedChannelConnectionConfigurator<TChannel> OnSynchronizationContext<TChannel>(
			this ChannelConnectionConfigurator<TChannel> configurator, SynchronizationContext synchronizationContext)
		{
			var synchronizedConfigurator = new SynchronizedChannelConnectionConfiguratorImpl<TChannel>(synchronizationContext);

			configurator.SetChannelConfigurator(synchronizedConfigurator);

			return synchronizedConfigurator;
		}
	}
}