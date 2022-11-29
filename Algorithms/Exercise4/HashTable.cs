using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Exercise4
{
    public class KeyValye<Key,Value> 
    {
        public Key key { get; set; }
        public Value value { get; set; }

        private List<KeyValye<Key,Value>> keys;

        public KeyValye(Key key, Value value) 
        {
            this.key = key;
            this.value = value;
        }
    }

    internal class HashTable<Key,Value,T>
    {
        private int M;

        private KeyValye<Key, Value>[] hashTable;

        public HashTable(int M)
        {
            this.M = M;
            hashTable = new KeyValye<Key, Value>[M];  
        }


        public int HashFunction(Value value) 
        {
                // funckja otrzymuje typ generyczny dla którego oblicza hash

                // moze być string, tablica int, lista, klasa..

                return 1;          
        }

        int HashString(string input)
        {
            char[] ch;
            ch = input.ToCharArray();

            int i, sum;
            for ( sum = 0, i = 0; i < input.Length; i++)
                sum += ch[i];
            return sum % M;
        }

        int HashIntiger(int[] input) 
        {
            int i, sum;
            for (sum = 0, i = 0; i < input.Length; i++)
                sum += input[i];
            return sum % M;
        }
        

        public void HashInsert(Key key, Value value) 
        {
            int ind = HashFunction(value);
            hashTable[ind] = new KeyValye<Key,Value>(key, value);

        }

        public Value HashSearch(Key key) 
        {
            //KeyValye<Key, Value> key1 = hashTable[HashFunction(value)];

    
            //    while (key1 != null)
            //    {
            //        if (key1.Equals(key))
            //            return key1.value;

            //    }
                     
                throw new Exception($"{key} was not found");
            
        }
    }
}
