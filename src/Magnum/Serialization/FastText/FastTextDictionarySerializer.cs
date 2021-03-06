// Copyright 2007-2008 The Apache Software Foundation.
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
namespace Magnum.Serialization.FastText
{
	using System.Collections.Generic;

	public class FastTextDictionarySerializer<TKey, TValue> :
		FastTextKeyElementParser<TKey, TValue>,
		TypeSerializer<Dictionary<TKey, TValue>>
	{
		public FastTextDictionarySerializer(TypeSerializer<TKey> keyTypeSerializer,
		                                    TypeSerializer<TValue> elementTypeSerializer)
			: base(keyTypeSerializer, elementTypeSerializer)
		{
		}

		public TypeReader<Dictionary<TKey, TValue>> GetReader()
		{
			return value =>
				{
					Dictionary<TKey, TValue> values = DictionaryReader(value);

					return values;
				};
		}

		public TypeWriter<Dictionary<TKey, TValue>> GetWriter()
		{
			return DictionaryWriter;
		}
	}
}