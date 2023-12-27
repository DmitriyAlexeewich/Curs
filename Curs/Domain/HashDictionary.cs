using System.Collections;

namespace Curs.Domain
{
    public class HashDictionary<T, Y> where T : notnull
    {
        private readonly Hashtable _dictionary;

        public int Length => _dictionary.Count;
        public T[] Keys => GetItems<T>(_dictionary.Keys);
        public Y[] Values => GetItems<Y>(_dictionary.Values);

        public HashDictionary()
        {
            _dictionary = new Hashtable();
        }

        public void Add(T key, Y value)
        {
            try
            {
                if(key is null)
                    throw new ArgumentNullException(nameof(key));

                _dictionary.Add(key, value);
            }
            catch
            {
                throw new ArgumentException($"Dictionary already contains key: {key}");
            }
        }

        public void Remove(T key)
        {
            try
            {
                if (key is null)
                    throw new ArgumentNullException(nameof(key));

                _dictionary.Remove(key);
            }
            catch
            {
                throw new ArgumentException($"Dictionary not contains key: {key}");
            }
        }

        public Y GetElement(T key)
        {
            try
            {
                if (key is null)
                    throw new ArgumentNullException(nameof(key));

                var element = _dictionary[key];
                
                return (Y)element;
            }
            catch
            {
                throw new ArgumentException($"Dictionary not contains key: {key}");
            }
        }

        private K[] GetItems<K>(ICollection collection)
        {
            var elements = new List<K>();

            foreach (var element in collection)
                elements.Add((K)element);

            return elements.ToArray();
        }
    }
}
