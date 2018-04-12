using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hash_table
{

    struct KeyVal<TKey, TVal>
    {
        public TKey key { get; set; }
        public TVal value { get; set; }
    }

    class MyHashTable<TKey, TVal>
    {
        readonly int size = 255;
        private Dictionary<TKey, TVal>[] items;

        public MyHashTable(int s)
        {
            size = s;
            items = new Dictionary<TKey, TVal>[size];
        }

        private int GetArrayPos(TKey key)
        {
            int position = key.GetHashCode() % size;
            return Math.Abs(position);
        }

        public void Add(TKey key, TVal value)
        {
            int position = GetArrayPos(key);
            if (items[position] == null)
                items[position] = new Dictionary<TKey, TVal>();
            items[position].Add(key, value);
        }

        public TVal GetByKey(TKey key)
        {
            int position = GetArrayPos(key);
            Dictionary<TKey, TVal> dict = items[position]; //
            if((dict.Keys != null)&&(dict.ContainsKey(key)))
            {
                return dict[key];
            }     
            else if (dict.Keys == null) throw new KeyNotFoundException("Key not found.. (●o≧д≦)o");
            return default(TVal);
        }
        

        public void Delete(TKey key)
        { 
            int position = GetArrayPos(key);
            Dictionary<TKey, TVal> dict = items[position]; 
            if (dict.ContainsKey(key))
            {
                dict.Remove(key);
            }
            throw new KeyNotFoundException("Key not found.. (●o≧д≦)o");
        }
    }
}
