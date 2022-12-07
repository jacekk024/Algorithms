using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Exercise4
{

    internal class HashTable<T>
    {
        public List<T>[] hash;         // tablica haszujaca

        private readonly double alfa;   //
        private const int prime = 7919;
        private const int prime2 = 25229;
        private const int prime3 = 50423;

        private int M;                  // poczatkowy rozmiar tablicy    
        private int N;                  // całkowita liczba elementow

        public HashTable() 
        {
            M = 1024;
            N = 0;      
            hash = new List<T>[M];
            for (int i = 0; i < M; i++)
                hash[i] = new List<T>();
            alfa = (Math.Sqrt(5) - 1) / 2;  
        }

        public void PrintHashTable()
        {
            for (int i = 0; i < hash.Length; i++)
            {
                Console.Write($"{i}: ");
                foreach (T t in hash[i])
                    Console.Write($"{t} ");
                Console.WriteLine();
            }
            
        }

        //Hash function for class
        //private int HashString(string array, int m)
        //{
        //    byte[] byteArray = 
        //    ulong hashValue = 0;
        //    ulong pow = 1;
        //    ulong mod = (ulong)m;

        //    for (int i = 0; i < array.Length; i++)
        //    {
        //        hashValue = (uint)(hashValue + array[i] * pow);
        //        pow *= prime3;
        //    }

        //    hashValue = (hashValue % mod);
        //    return (int)hashValue;
        //}

        public int HashObject() 
        {








            return 1;
        }

        public int HashInt(int a, int m)
        {    
            double s = a * alfa;
            var x = s - Math.Truncate(s);
            x *= 1e9;
            int res = Convert.ToInt32(x);
            return res % M;
        }


        public int HashInt(int a)
        {
            a -= (a << 6);
            a ^= (a >> 17);
            a -= (a << 9);
            a ^= (a << 4);
            a -= (a << 3);
            a ^= (a << 10);
            a ^= (a >> 15);
            return (a % M);
        }



        public int HashDouble(double a, int m)
        {
            a *= 109;
            int tmp = (int)a;
            return HashInt(tmp, m);
        }




        //public int Hash(string value)
        //{
        //    byte[] valueByte = Encoding.ASCII.GetBytes(value);
        //    return HashFunction(valueByte, M);
        //}



        public void HashInsert(T value)
        {

            //sprawdznie czy N - wszystkich elementów / dlugosc tablicy > 1
            N++;
            if (N / M > 1)          
            {
                //resize 

            }
            else
            {
                int ind;
                Type type = typeof(T);

                if (type == typeof(int))
                {
                    ind = HashInt(Convert.ToInt32(value));
                    hash[ind].Add(value);
                }
                if (type == typeof(double))
                {
                    //ind = HashDouble(Convert.ToInt32(value));

                    //if (hash[ind].Contains(value))
                    //    return ind;
                }
                if (type == typeof(string))
                {
                    //byte[] valueByte = Encoding.ASCII.GetBytes(Convert.ToString(value));
                    //ind = HashString(Convert.ToBase64String( value), M);
                    //if (hash[ind].Contains(value))
                    //    return ind;
                }
            }
        }

        public void HashDelete(T value) 
        {
            N--;
            int ind = HashSearch(value);

            //if(hash[ind].Contains(value))
            //    hash[ind].Find(value).

        }




        public int HashSearch(T value)
        {
            Type type = typeof(T);
            int ind;


            if (type == typeof(int))
            {
                ind = HashInt(Convert.ToInt32(value));

                if (hash[ind].Contains(value))
                    return ind; 
            }
            if (type == typeof(double))
            {

                //ind = HashDouble(Convert.ToInt32(value));

                //if (hash[ind].Contains(value))
                //    return ind;
            }
            if (type == typeof(string))
            {
                //byte[] valueByte = Encoding.ASCII.GetBytes(Convert.ToString(value));
                //ind = HashString(Convert.ToBase64String( value), M);
                //if (hash[ind].Contains(value))
                //    return ind;
            }

            return -1;
        }
    }
}

