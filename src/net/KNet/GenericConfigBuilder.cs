/*
*  Copyright 2023 MASES s.r.l.
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

using Java.Util;
using System.Globalization;
using System;

namespace MASES.KNet
{
    /// <summary>
    /// Generic base configuration class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericConfigBuilder<T> : System.ComponentModel.INotifyPropertyChanged
        where T : GenericConfigBuilder<T>, new()
    {
        /// <summary>
        /// Creates an instance of <typeparamref name="T"/>
        /// </summary>
        /// <returns>The instance of <typeparamref name="T"/></returns>
        public static T Create() { return new T(); }
        /// <summary>
        /// Creates an instance of <typeparamref name="T"/>
        /// </summary>
        /// <param name="origin">Clone from this original instance</param>
        /// <returns>The instance of <typeparamref name="T"/> clone from <paramref name="origin"/> or new instance if <paramref name="origin"/> is <see langword="null"/></returns>
        public static T CreateFrom(T origin)
        {
            if (origin == null) return Create();
            var newT = new T
            {
                _options = new System.Collections.Generic.Dictionary<string, object>(origin._options)
            };
            return newT;
        }
        /// <summary>
        /// Converts <see cref="GenericConfigBuilder{T}"/> into <see cref="Properties"/>
        /// </summary>
        /// <param name="clazz"></param>
        public static implicit operator Properties(GenericConfigBuilder<T> clazz) { return clazz.ToProperties(); }

        /// <inheritdoc />
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        System.Collections.Generic.Dictionary<string, object> _options = new();
        /// <summary>
        /// Reads the <paramref name="propertyName"/> set
        /// </summary>
        /// <typeparam name="TData">The propert type</typeparam>
        /// <param name="propertyName">The property name to be get</param>
        /// <returns><typeparamref name="TData"/> or <see langword="default"/> if property does not exists</returns>
        public TData GetProperty<TData>(string propertyName)
        {
            if (_options.TryGetValue(propertyName, out var result))
            {
                return (TData)result;
            }
            return default;
        }
        /// <summary>
        /// Set the <paramref name="propertyName"/> with <paramref name="value"/>
        /// </summary>
        /// <param name="propertyName">The property name to be set</param>
        /// <param name="value">The property value to be set</param>
        public void SetProperty(string propertyName, object value)
        {
            if (!_options.ContainsKey(propertyName))
            {
                _options.Add(propertyName, value);
            }
            else _options[propertyName] = value;

            PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
        /// <summary>
        /// Cones this instance
        /// </summary>
        /// <returns><typeparamref name="T"/> cloned</returns>
        protected virtual T Clone()
        {
            var clone = new T
            {
                _options = new System.Collections.Generic.Dictionary<string, object>(_options)
            }; return clone;
        }
        /// <summary>
        /// Returns the <see cref="Properties"/> from the <typeparamref name="T"/> instance
        /// </summary>
        /// <returns><see cref="Properties"/> containing the properties</returns>
        public Properties ToProperties()
        {
            Properties props = new();
            foreach (var item in _options)
            {
                props.Put(item.Key, item.Value);
            }

            return props;
        }

        /// <summary>
        /// Returns the <see cref="Map{String, String}"/> from the <typeparamref name="T"/> instance
        /// </summary>
        /// <returns><see cref="Map{String, String}"/> containing the properties</returns>
        public Map<string, string> ToMap()
        {
            HashMap<string, string> props = new();
            foreach (var item in _options)
            {
                props.Put(item.Key, Convert.ToString(item.Value, CultureInfo.InvariantCulture));
            }

            return props;
        }
    }
}
