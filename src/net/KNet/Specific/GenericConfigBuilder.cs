﻿/*
*  Copyright 2024 MASES s.r.l.
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
using MASES.KNet.Serialization;
using System.Linq;
using System.Collections.Concurrent;
using MASES.JCOBridge.C2JBridge;

namespace MASES.KNet
{
    /// <summary>
    /// Generic base configuration class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericConfigBuilder<T> : System.ComponentModel.INotifyPropertyChanged, IGenericSerDesFactory, IDisposable
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
                _options = new System.Collections.Generic.Dictionary<string, object>(origin._options),
                _KNetKeySerDes = origin._KNetKeySerDes,
                _KNetValueSerDes = origin._KNetValueSerDes,
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
        /// Verify if the <paramref name="propertyName"/> was previously set
        /// </summary>
        /// <param name="propertyName">The property name to be verified</param>
        /// <returns><see langword="true"/> if property exists, otherwise <see langword="false"/></returns>
        public bool ExistProperty(string propertyName)
        {
            return _options.ContainsKey(propertyName);
        }
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
                return result.Convert<TData>();
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
                _options = new System.Collections.Generic.Dictionary<string, object>(_options),
                _KNetKeySerDes = _KNetKeySerDes,
                _KNetValueSerDes = _KNetValueSerDes
            };
            return clone;
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
        public Map<Java.Lang.String, Java.Lang.String> ToMap()
        {
            HashMap<Java.Lang.String, Java.Lang.String> props = new();
            foreach (var item in _options)
            {
                props.Put(item.Key, Convert.ToString(item.Value, CultureInfo.InvariantCulture));
            }

            return props;
        }
        Type _KNetKeySerDes = null;
        /// <inheritdoc cref="IGenericSerDesFactory.KNetKeySerDes"/>
        public Type KNetKeySerDes
        {
            get { return _KNetKeySerDes; }
            set
            {
                if (value.GetConstructors().Single(ci => ci.GetParameters().Length == 0) == null)
                {
                    throw new ArgumentException($"{value.Name} does not contains a default constructor and cannot be used because it is not a valid Serializer type");
                }

                if (value.IsGenericType)
                {
                    var keyT = value.GetGenericArguments();
                    if (keyT.Length != 1) { throw new ArgumentException($"{value.Name} does not contains a single generic argument and cannot be used because it is not a valid Serializer type"); }
                    var t = value.GetGenericTypeDefinition();
                    if (t.GetInterface(typeof(ISerDes<>).Name) == null)
                    {
                        throw new ArgumentException($"{value.Name} does not implement IKNetSerDes<> and cannot be used because it is not a valid Serializer type");
                    }
                    _KNetKeySerDes = value;
                }
                else throw new ArgumentException($"{value.Name} is not a generic type and cannot be used as a valid ValueContainer type");
            }
        }

        Type _KNetValueSerDes = null;
        /// <inheritdoc cref="IGenericSerDesFactory.KNetValueSerDes"/>
        public Type KNetValueSerDes
        {
            get { return _KNetValueSerDes; }
            set
            {
                if (value.GetConstructors().Single(ci => ci.GetParameters().Length == 0) == null)
                {
                    throw new ArgumentException($"{value.Name} does not contains a default constructor and cannot be used because it is not a valid Serializer type");
                }

                if (value.IsGenericType)
                {
                    var keyT = value.GetGenericArguments();
                    if (keyT.Length != 1) { throw new ArgumentException($"{value.Name} does not contains a single generic argument and cannot be used because it is not a valid Serializer type"); }
                    var t = value.GetGenericTypeDefinition();
                    if (t.GetInterface(typeof(ISerDes<>).Name) == null)
                    {
                        throw new ArgumentException($"{value.Name} does not implement IKNetSerDes<> and cannot be used because it is not a valid Serializer type");
                    }
                    _KNetValueSerDes = value;
                }
                else throw new ArgumentException($"{value.Name} is not a generic type and cannot be used as a valid Serializer type");
            }
        }

        readonly ConcurrentDictionary<(Type, Type), object> _keySerDesComplete = new();

        /// <inheritdoc cref="IGenericSerDesFactory.BuildKeySerDes{TKey, TJVMTKey}"/>
        public ISerDes<TKey, TJVMTKey> BuildKeySerDes<TKey, TJVMTKey>()
        {
            lock (_keySerDesComplete)
            {
                if (!_keySerDesComplete.TryGetValue((typeof(TKey), typeof(TJVMTKey)), out object serDes))
                {
                    if (KNetSerialization.IsInternalManaged<TKey>())
                    {
                        serDes = new SerDes<TKey>();
                    }
                    else
                    {
                        if (KNetKeySerDes == null) throw new InvalidOperationException($"No default serializer available for {typeof(TKey)}, property {nameof(KNetKeySerDes)} shall be set.");
                        var tmp = KNetKeySerDes.MakeGenericType(typeof(TKey));
                        serDes = Activator.CreateInstance(tmp);
                    }
                    _keySerDesComplete[(typeof(TKey), typeof(TJVMTKey))] = serDes;
                }
                return serDes as ISerDes<TKey, TJVMTKey>;
            }
        }

        readonly ConcurrentDictionary<Type, object> _keySerDesSimple = new();

        /// <inheritdoc cref="IGenericSerDesFactory.BuildKeySerDes{TKey}"/>
        public ISerDes<TKey> BuildKeySerDes<TKey>()
        {
            lock (_keySerDesSimple)
            {
                if (!_keySerDesSimple.TryGetValue(typeof(TKey), out object serDes))
                {
                    if (KNetSerialization.IsInternalManaged<TKey>())
                    {
                        serDes = new SerDes<TKey>();
                    }
                    else
                    {
                        if (KNetKeySerDes == null) throw new InvalidOperationException($"No default serializer available for {typeof(TKey)}, property {nameof(KNetKeySerDes)} shall be set.");
                        var tmp = KNetKeySerDes.MakeGenericType(typeof(TKey));
                        serDes = Activator.CreateInstance(tmp);
                    }
                    _keySerDesSimple[typeof(TKey)] = serDes;
                }
                return serDes as ISerDes<TKey>;
            }
        }

        readonly ConcurrentDictionary<(Type, Type), object> _valueSerDesComplete = new();

        /// <inheritdoc cref="IGenericSerDesFactory.BuildValueSerDes{TValue, TJVMTValue}"/>
        public ISerDes<TValue, TJVMTValue> BuildValueSerDes<TValue, TJVMTValue>()
        {
            lock (_valueSerDesComplete)
            {
                if (!_valueSerDesComplete.TryGetValue((typeof(TValue), typeof(TJVMTValue)), out object serDes))
                {
                    if (KNetSerialization.IsInternalManaged<TValue>())
                    {
                        serDes = new SerDes<TValue>();
                    }
                    else
                    {
                        if (KNetValueSerDes == null) throw new InvalidOperationException($"No default serializer available for {typeof(TValue)}, property {nameof(KNetValueSerDes)} shall be set.");
                        var tmp = KNetValueSerDes.MakeGenericType(typeof(TValue));
                        serDes = Activator.CreateInstance(tmp);
                    }
                    _valueSerDesComplete[(typeof(TValue), typeof(TJVMTValue))] = serDes;
                }
                return serDes as ISerDes<TValue, TJVMTValue>;
            }
        }

        readonly ConcurrentDictionary<Type, object> _valueSerDesSimple = new();

        /// <inheritdoc cref="IGenericSerDesFactory.BuildValueSerDes{TValue}"/>
        public ISerDes<TValue> BuildValueSerDes<TValue>()
        {
            lock (_valueSerDesSimple)
            {
                if (!_valueSerDesSimple.TryGetValue(typeof(TValue), out object serDes))
                {
                    if (KNetSerialization.IsInternalManaged<TValue>())
                    {
                        serDes = new SerDes<TValue>();
                    }
                    else
                    {
                        if (KNetValueSerDes == null) throw new InvalidOperationException($"No default serializer available for {typeof(TValue)}, property {nameof(KNetValueSerDes)} shall be set.");
                        var tmp = KNetValueSerDes.MakeGenericType(typeof(TValue));
                        serDes = Activator.CreateInstance(tmp);
                    }
                    _valueSerDesSimple[typeof(TValue)] = serDes;
                }
                return serDes as ISerDes<TValue>;
            }
        }
        /// <inheritdoc cref="IGenericSerDesFactory.Clear"/>
        public void Clear()
        {
            foreach (IDisposable item in _keySerDesSimple.Values.Cast<IDisposable>())
            {
                item?.Dispose();
            }

            _keySerDesSimple.Clear();

            foreach (IDisposable item in _valueSerDesSimple.Values.Cast<IDisposable>())
            {
                item?.Dispose();
            }

            _valueSerDesSimple.Clear();
        }

        /// <inheritdoc cref="IDisposable.Dispose"/>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            Clear();
        }
    }
}
