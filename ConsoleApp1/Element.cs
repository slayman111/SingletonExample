using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public class Element : IElement
    {
        public Element()
        {
        }

        private static Dictionary<Type, IList<object>> _cache = new Dictionary<Type, IList<object>>();
        //private static Lazy<Element> _instance = new Lazy<Element>(() => new Element());
        //private static Element Instance => _instance.Value;
        //public ArrayList list;
        public IElement Registry<T>()
        {
            var type = typeof(T);
            if (!_cache.ContainsKey(type))
                _cache.Add(type, new List<object>());
            return this;
        }

        public IElement Drop(object obj)
        {
            var type = obj.GetType();
            if (!_cache.ContainsKey(type))
                _cache[type].Remove(obj);
            return this;
        }

        public IElement Drop<T>()
        {
            var type = typeof(T);
            _cache.Remove(type);
            return this;
        }

        public int CountOfType<T>()
        {
            var type = typeof(T);
            if (!_cache.ContainsKey(type)) 
                return 0;
            return _cache[type].Count;
        }

        public T GetFirstOfType<T>()
        {
            var type = typeof(T);
            if (_cache.ContainsKey(type))
                return (T)_cache[type].FirstOrDefault();
            return default;
        }

        public bool Contains(object obj)
        {
            Type type = obj.GetType();
            return _cache.ContainsKey(type) && _cache[type].Contains(obj);
        }

        public bool Contains<T>()
        {
            Type type = typeof(T);
            return _cache.ContainsKey(type);
        }

        public object GetOrAdd(object obj)
        {
            Type type = obj.GetType();
            if (!_cache.ContainsKey(type))
                throw new TypeAccessException("Unknown type");

            if (_cache[type].Contains(obj))
            {
                int idx = _cache[type].IndexOf(obj);
                return _cache[type].ToArray()[idx];
            }
            _cache[type].Add(obj);
            return obj;
        }
    }
}

