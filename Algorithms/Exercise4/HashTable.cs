using Microsoft.VisualBasic.FileIO;
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

        private const int prime = 7919;
        private const int prime2 = 25229;
        private const int prime3 = 50423;

        private int M;                  // poczatkowy rozmiar tablicy    
        private int N;                  // całkowita liczba elementow

        public double ratio;
        public HashTable() 
        {
            M = 10;
            N = 0;      
            hash = new List<T>[M];
            for (int i = 0; i < M; i++)
                hash[i] = new List<T>();
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
        
        private int HashString(string val, int m)
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(val);
            ulong hashValue = 0;
            ulong pow = 1;
            ulong mod = (ulong)m;

            for (int i = 0; i < val.Length; i++)
            {
                hashValue = (uint)(hashValue + byteArray[i] * pow);
                pow *= prime3;
            }

            hashValue = (hashValue % mod);
            return (int)hashValue;
        }

        //h(k) = floor (m * (k * c mod 1)) // Multiplication Method
        private int HashInt(int val)
        {
            double alfa =  (Math.Sqrt(5) - 1) / 2;

            uint hashValue = (uint)Math.Floor(M * ((val * alfa) % 1));

            return (int)(hashValue % M);
        }

        public int HashDouble(double a)
        {
            int hashValue;

            hashValue = (int)(a * 1e9);

            hashValue = HashInt(hashValue) % M;
            return hashValue;
        }

        public void HashInsert(T[] value)
        {           
            for (int i = 0; i < value.Length; i++)
                HashInsert(value[i]);
        }


        private bool CheckToResize() 
        {
            if ((ratio> 1.5 || ratio < 0.3) & N > 10)           
                return true;  
            else
                return false;
        }

        private int Hash(T value, bool option)
        {

            Type type = typeof(T);
            int ind;

            if (type == typeof(int))
            {
                ind = HashInt(Convert.ToInt32(value));

                if (option)
                    hash[ind].Add(value);

                if (hash[ind].Contains(value))
                    return ind; 
            }
            if (type == typeof(double))
            {

                ind = HashDouble(Convert.ToDouble(value));

                if (option)
                    hash[ind].Add(value);

                if (hash[ind].Contains(value))
                    return ind;
            }
            if (type == typeof(string))
            {
                ind = HashString(value.ToString(), M);

                if(option)
                    hash[ind].Add(value);

                if (hash[ind].Contains(value))
                    return ind;
            }
            else
            {
                // szukanie obiektow
            }
            return -1;
        }


        private void ResizeTable() 
        {
            List<T>[] hashTemp = new List<T>[M];         // tablica haszujaca

            for (int i = 0; i < M; i++)
                hashTemp[i] = new List<T>(hash[i]);

            if (ratio > 1.5) 
            {
                M *= 2;
                hash = new List<T>[M];
                for (int i = 0; i < M; i++)
                    hash[i] = new List<T>();

                for (int i = 0; i < hashTemp.Length; i++)
                    for(int j = 0; j < hashTemp[i].Count; j++)
                    {
                        Hash(hashTemp[i][j], true);
                    }
            }
            else if( ratio < 0.3) 
            {
                M /= 2;
                hash = new List<T>[M];
                for (int i = 0; i < M; i++)
                    hash[i] = new List<T>();


                for (int i = 0; i < hashTemp.Length; i++)
                    for (int j = 0; j < hashTemp[i].Count; j++)
                    {
                        Hash(hashTemp[i][j], true);
                    }
            }
        }

        public void HashInsert(T value)
        {
            ratio = N / (double)M;

            if (!CheckToResize())
            {
                N++;
                Hash(value, true);
            }
            else 
            {
                ResizeTable();
                N++;
                Hash(value, true);
            }
        }

        public void HashDelete(T value) 
        {
            N--;
            int ind = HashSearch(value);

            if (hash[ind].Contains(value)) 
                hash[ind].Remove(value);
        }

        public int HashSearch(T value)
        {
            return Hash(value, false);
        }
    }
}


