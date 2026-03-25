/*
*  Copyright (c) 2021-2026 MASES s.r.l.
*
*  Licensed under the Apache License, Version 2.0 (the "License");
*  you may not use this file except in compliance with the License.
*  You may obtain a copy of the License at
*
*  http://www.apache.org/licenses/LICENSE-2.0
*
*  Unless required by applicable law or agreed to in writing, software
*  distributed under the License is distributed on an "AS IS" BASIS,
*  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
*  See the License for the specific language governing permissions and
*  limitations under the License.
*
*  Refer to LICENSE for more information.
*/

using MASES.JCOBridge.C2JBridge;
using MASES.JCOBridge.C2JBridge.JVMInterop;
using Org.Apache.Kafka.Common.Config.Types;
using System;
using System.Collections;
using System.Collections.Generic;

namespace MASES.KNet
{
    #region IKNetConfigurationFromMap
    /// <summary>
    /// Interface to simplify access the configuration information reported from JVM as <see cref="Java.Util.Map{K, V}"/>
    /// </summary>
    public interface IKNetConfigurationFromMap : IEnumerable<KeyValuePair<string, object>>
    {
        /// <summary>
        /// Returns <see langword="true"/> if the <paramref name="key"/> exist
        /// </summary>
        /// <param name="key">The key to check</param>
        /// <returns><see langword="short"/> if the <paramref name="key"/> exist</returns>
        bool Exist(string key);
        /// <summary>
        /// Returns <see langword="short"/> associated to <paramref name="key"/>
        /// </summary>
        /// <param name="key">The key to return</param>
        /// <returns>The <see langword="short"/> associated to <paramref name="key"/></returns>
        short GetShort(string key);
        /// <summary>
        /// Returns <see langword="int"/> associated to <paramref name="key"/>
        /// </summary>
        /// <param name="key">The key to return</param>
        /// <returns>The <see langword="int"/> associated to <paramref name="key"/></returns>
        int GetInt(string key);
        /// <summary>
        /// Returns <see langword="long"/> associated to <paramref name="key"/>
        /// </summary>
        /// <param name="key">The key to return</param>
        /// <returns>The <see langword="long"/> associated to <paramref name="key"/></returns>
        long GetLong(string key);
        /// <summary>
        /// Returns <see langword="double"/> associated to <paramref name="key"/>
        /// </summary>
        /// <param name="key">The key to return</param>
        /// <returns>The <see langword="double"/> associated to <paramref name="key"/></returns>
        double GetDouble(string key);
        /// <summary>
        /// Returns <see cref="System.Collections.Generic.List{T}"/> of <see langword="string"/> associated to <paramref name="key"/>
        /// </summary>
        /// <param name="key">The key to return</param>
        /// <returns>The <see cref="System.Collections.Generic.List{T}"/> of <see langword="string"/> associated to <paramref name="key"/></returns>
        System.Collections.Generic.List<string> GetList(string key);
        /// <summary>
        /// Returns <see langword="bool"/> associated to <paramref name="key"/>
        /// </summary>
        /// <param name="key">The key to return</param>
        /// <returns>The <see langword="bool"/> associated to <paramref name="key"/></returns>
        bool GetBoolean(string key);
        /// <summary>
        /// Returns <see langword="string"/> associated to <paramref name="key"/>
        /// </summary>
        /// <param name="key">The key to return</param>
        /// <returns>The <see langword="string"/> associated to <paramref name="key"/></returns>
        string GetString(string key);
        /// <summary>
        /// Returns <see cref="Password"/> associated to <paramref name="key"/>
        /// </summary>
        /// <param name="key">The key to return</param>
        /// <returns>The <see cref="Password"/> associated to <paramref name="key"/></returns>
        Password GetPassword(string key);
        /// <summary>
        /// Returns <see cref="Java.Lang.Class"/> associated to <paramref name="key"/>
        /// </summary>
        /// <param name="key">The key to return</param>
        /// <returns>The <see cref="Java.Lang.Class"/> associated to <paramref name="key"/></returns>
        Java.Lang.Class GetClass(string key);
    }

    #endregion

    #region KNetConfigurationFromMap
    /// <summary>
    /// Implementation class for <see cref="IKNetConfigurationFromMap"/>
    /// </summary>
    class KNetConfigurationFromMap : IKNetConfigurationFromMap
    {
        readonly Java.Util.Map<Java.Lang.String, object> _configuration;
        readonly Java.Util.Map<Java.Lang.String, Java.Lang.String> _configuration1;
        public KNetConfigurationFromMap(Java.Util.Map<Java.Lang.String, object> configuration)
        {
            _configuration = configuration;
        }

        public KNetConfigurationFromMap(Java.Util.Map<Java.Lang.String, Java.Lang.String> configuration)
        {
            _configuration1 = configuration;
        }

        object GetValue(string key)
        {
            if (_configuration != null && _configuration.ContainsKey(key))
            {
                return _configuration.Get(key);
            }
            else if (_configuration1 != null)
            {
                throw new InvalidOperationException($"Only string values can be read.");
            }
            throw new InvalidOperationException($"Configuration key \"{key}\" is not available.");
        }

        /// <inheritdoc/>
        public bool Exist(string key)
        {
            return (_configuration != null) ? _configuration.ContainsKey(key) : _configuration1.ContainsKey(key);
        }
        /// <inheritdoc/>
        public short GetShort(string key)
        {
            if (_configuration1 != null)
            {
                if (_configuration1.ContainsKey(key))
                {
                    var value = _configuration1.Get(key);
                    return short.TryParse(value, out var converted) ? converted
                                                                    : throw new InvalidCastException($"Key \"{key}\" returns a value {value} cannot be converted in short"); ;
                }
                throw new InvalidOperationException($"Configuration key \"{key}\" is not available.");
            }

            var result = GetValue(key);

            if (result is short data)
            {
                return data;
            }
            else if (result is IJavaObject obj)
            {
                return obj.Convert<short>();
            }
            else throw new InvalidCastException($"Key \"{key}\" returns a value {(result ?? "null")} cannot be converted in short");
        }
        /// <inheritdoc/>
        public int GetInt(string key)
        {
            if (_configuration1 != null)
            {
                if (_configuration1.ContainsKey(key))
                {
                    var value = _configuration1.Get(key);
                    return int.TryParse(value, out var converted) ? converted
                                                                  : throw new InvalidCastException($"Key \"{key}\" returns a value {value} cannot be converted in int"); ;
                }
                throw new InvalidOperationException($"Configuration key \"{key}\" is not available.");
            }

            var result = GetValue(key);

            if (result is int data)
            {
                return data;
            }
            else if (result is IJavaObject obj)
            {
                return obj.Convert<int>();
            }
            else throw new InvalidCastException($"Key \"{key}\" returns a value {(result ?? "null")} cannot be converted in int");
        }
        /// <inheritdoc/>
        public long GetLong(string key)
        {
            if (_configuration1 != null)
            {
                if (_configuration1.ContainsKey(key))
                {
                    var value = _configuration1.Get(key);
                    return long.TryParse(value, out var converted) ? converted
                                                                   : throw new InvalidCastException($"Key \"{key}\" returns a value {value} cannot be converted in long"); ;
                }
                throw new InvalidOperationException($"Configuration key \"{key}\" is not available.");
            }

            var result = GetValue(key);

            if (result is long data)
            {
                return data;
            }
            else if (result is IJavaObject obj)
            {
                return obj.Convert<long>();
            }
            else throw new InvalidCastException($"Key \"{key}\" returns a value {(result ?? "null")} cannot be converted in long");
        }
        /// <inheritdoc/>
        public double GetDouble(string key)
        {
            if (_configuration1 != null)
            {
                if (_configuration1.ContainsKey(key))
                {
                    var value = _configuration1.Get(key);
                    return double.TryParse(value, out var converted) ? converted
                                                                     : throw new InvalidCastException($"Key \"{key}\" returns a value {value} cannot be converted in double"); ;
                }
                throw new InvalidOperationException($"Configuration key \"{key}\" is not available.");
            }

            var result = GetValue(key);

            if (result is double data)
            {
                return data;
            }
            else if (result is IJavaObject obj)
            {
                return obj.Convert<double>();
            }
            else throw new InvalidCastException($"Key \"{key}\" returns a value {(result ?? "null")} cannot be converted in double");
        }
        /// <inheritdoc/>
        public System.Collections.Generic.List<string> GetList(string key)
        {
            if (_configuration1 != null)
            {
                throw new InvalidOperationException($"Cannot manage configuration key \"{key}\" as List.");
            }

            var result = GetValue(key);

            if (result is IJavaObject obj)
            {
                var lst = JVMBridgeBase.WrapsDirect<Java.Util.List<Java.Lang.String>>(obj);
                System.Collections.Generic.List<string> newLst = new System.Collections.Generic.List<string>();
                foreach (var item in lst)
                {
                    newLst.Add(item);
                }
                return newLst;
            }
            else throw new InvalidCastException($"Key \"{key}\" returns a value {(result ?? "null")} cannot be converted in short");
        }
        /// <inheritdoc/>
        public bool GetBoolean(string key)
        {
            if (_configuration1 != null)
            {
                if (_configuration1.ContainsKey(key))
                {
                    var value = _configuration1.Get(key);
                    return bool.TryParse(value, out var converted) ? converted
                                                                   : throw new InvalidCastException($"Key \"{key}\" returns a value {value} cannot be converted in bool"); ;
                }
                throw new InvalidOperationException($"Configuration key \"{key}\" is not available.");
            }

            var result = GetValue(key);

            if (result is bool data)
            {
                return data;
            }
            else if (result is IJavaObject obj)
            {
                return obj.Convert<bool>();
            }
            else throw new InvalidCastException($"Key \"{key}\" returns a value {(result ?? "null")} cannot be converted in bool");
        }
        /// <inheritdoc/>
        public string GetString(string key)
        {
            if (_configuration1 != null)
            {
                if (_configuration1.ContainsKey(key))
                {
                    return _configuration1.Get(key);
                }
                throw new InvalidOperationException($"Configuration key \"{key}\" is not available.");
            }

            var result = GetValue(key);

            if (result is string data)
            {
                return data;
            }
            else if (result is IJavaObject obj)
            {
                return obj.Convert<string>();
            }
            else throw new InvalidCastException($"Key \"{key}\" returns a value {(result ?? "null")} cannot be converted in string");
        }
        /// <inheritdoc/>
        public Password GetPassword(string key)
        {
            if (_configuration1 != null)
            {
                throw new InvalidOperationException($"Cannot manage configuration key \"{key}\" as Password.");
            }

            var result = GetValue(key);

            if (result is Password data)
            {
                return data;
            }
            else if (result is IJavaObject obj)
            {
                return JVMBridgeBase.WrapsDirect<Password>(obj);
            }
            else throw new InvalidCastException($"Key \"{key}\" returns a value {(result ?? "null")} cannot be converted in Password");
        }
        /// <inheritdoc/>
        public Java.Lang.Class GetClass(string key)
        {
            if (_configuration1 != null)
            {
                throw new InvalidOperationException($"Cannot manage configuration key \"{key}\" as Class.");
            }

            var result = GetValue(key);

            if (result is Java.Lang.Class data)
            {
                return data;
            }
            else if (result is IJavaObject obj)
            {
                return JVMBridgeBase.WrapsDirect<Java.Lang.Class>(obj);
            }
            else throw new InvalidCastException($"Key \"{key}\" returns a value {(result ?? "null")} cannot be converted in Class");
        }
        /// <inheritdoc/>
        public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            if (_configuration != null)
            {
                foreach (var item in _configuration.EntrySet())
                {
                    yield return new KeyValuePair<string, object>(item.Key, item.Value);
                }
            }
            else if (_configuration1 != null)
            {
                foreach (var item in _configuration1.EntrySet())
                {
                    yield return new KeyValuePair<string, object>(item.Key, item.Value);
                }
            }
            else throw new InvalidOperationException("Unable to execute enumeration.");
        }
        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    #endregion

}
