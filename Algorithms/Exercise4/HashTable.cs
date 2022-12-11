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

        public int M;                  // poczatkowy rozmiar tablicy    
        public int N;                  // całkowita liczba elementow

        public double ratio;
        public HashTable() 
        {
            M = 10;
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
        private int HashString(string array, int m)
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(array);
            ulong hashValue = 0;
            ulong pow = 1;
            ulong mod = (ulong)m;

            for (int i = 0; i < array.Length; i++)
            {
                hashValue = (uint)(hashValue + byteArray[i] * pow);
                pow *= prime3;
            }

            hashValue = (hashValue % mod);
            return (int)hashValue;
        }

        //to jeszcze poprawic na to z tutorialu
        private int HashInt(int a)
        {
            uint b = (uint)a; 

            b -= (b << 6);
            b ^= (b >> 17);
            b -= (b << 9);
            b ^= (b << 4);
            b -= (b << 3);
            b ^= (b << 10);
            b ^= (b >> 15);
            b = (uint)(b * alfa);
            return (int)(b % M);
        }



        public int HashDouble(double a)
        {
            int hashValue = 0;

            int k = (int)a;

            for (int i = 0; i < M; i++)
                hashValue += HashInt(k) + i * HashInt(k);

            hashValue = hashValue % M;
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
                        int ind;
                        Type type = typeof(T);

                        if (type == typeof(int))
                        {
                            ind = HashInt(Convert.ToInt32(hashTemp[i][j]));
                            hash[ind].Add(hashTemp[i][j]);
                        }
                        else if (type == typeof(double))
                        {
                            ind = HashDouble(Convert.ToDouble(hashTemp[i][j]));

                            hash[ind].Add(hashTemp[i][j]);

                        }
                        else if (type == typeof(string))
                        {
                            ind = HashString(hashTemp[i][j].ToString(), M);
                            hash[ind].Add(hashTemp[i][j]);
                        }
                        else
                        {
                            //dodanie obiektow klas
                            // nie jest obowiazkowe
                        }
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
                        int ind;
                        Type type = typeof(T);

                        if (type == typeof(int))
                        {
                            ind = HashInt(Convert.ToInt32(hashTemp[i][j]));
                            hash[ind].Add(hashTemp[i][j]);
                        }
                        else if (type == typeof(double))
                        {
                            ind = HashDouble(Convert.ToDouble(hashTemp[i][j]));

                            hash[ind].Add(hashTemp[i][j]);

                        }
                        else if (type == typeof(string))
                        {
                            ind = HashString(hashTemp[i][j].ToString(), M);
                            hash[ind].Add(hashTemp[i][j]);
                        }
                        else
                        {
                            //dodanie obiektow klas
                            // nie jest obowiazkowe
                        }
                    }               
            }
        }


        public void HashInsert(T value)
        {

            ratio = N / (double)M;


            if (!CheckToResize())
            {
                N++;
                int ind;
                Type type = typeof(T);

                if (type == typeof(int))
                {
                    ind = HashInt(Convert.ToInt32(value));
                    hash[ind].Add(value);
                }
                else if (type == typeof(double))
                {
                    ind = HashDouble(Convert.ToDouble(value));

                    hash[ind].Add(value);

                }
                else if (type == typeof(string))
                {
                    ind = HashString(value.ToString(), M);
                    hash[ind].Add(value);
                }
                else
                {
                    //dodanie obiektow klas
                    // nie jest obowiazkowe
                }
            }
            else 
            {
                ResizeTable();
                N++;
                int ind;
                Type type = typeof(T);

                if (type == typeof(int))
                {
                    ind = HashInt(Convert.ToInt32(value));
                    hash[ind].Add(value);
                }
                else if (type == typeof(double))
                {
                    ind = HashDouble(Convert.ToDouble(value));

                    hash[ind].Add(value);

                }
                else if (type == typeof(string))
                {
                    ind = HashString(value.ToString(), M);
                    hash[ind].Add(value);
                }
                else
                {
                    //dodanie obiektow klas
                    // nie jest obowiazkowe
                }
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

                ind = HashDouble(Convert.ToDouble(value));

                if (hash[ind].Contains(value))
                    return ind;
            }
            if (type == typeof(string))
            {
                ind = HashString(value.ToString(), M);
                if (hash[ind].Contains(value))
                    return ind;
            }
            else 
            {
                // szukanie obiektow
            }
            return -1;
        }
    }
}


