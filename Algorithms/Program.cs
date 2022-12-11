using Algorithms.Exercise1;
using Algorithms.Exercise2;
using Algorithms.Exercise3;
using Algorithms.Exercise4;
using Algorithms.Exercise5;
using System;



namespace Algorithms 
{
    class Test 
    {
        static void Main(string[] args) {

            //Permutation
            if (false) 
            {
                int[] data = { 1,2,3};
                float[] data2 = { 3.1F, 1.4F, 4.1F }; 
                string[] data3 = { "raz", "dwa", "trzy" };

                int[] timeUsed = {2,1,1};
                Permutation<int> perm = new Permutation<int>();
                perm.SetPermutationValues(data, timeUsed);
            }

            //Combination
            if (false) 
            {
                Combination<int> comb = new Combination<int>();
                int[] data = {1, 2,3,4,5};
                comb.SetCombinationValues(data,3);         
            }

            //Variation
            if (false)
            {
                Variation<int> variation = new Variation<int>();
                int[] data = { 1, 2, 3};
                int[] timeUsed = {1, 1,1};
                variation.SetVariationValues(data,2, timeUsed,false);
                Console.WriteLine();
            }

            //Knight
            if (false) 
            {
                int n = 9;
                    
                Knight knight = new Knight();
                knight.StartKnightTour(6,true);

                for(int i = 5; i <= n; i++) 
                {
                    knight.StartKnightTour(i,false);
                }            
            }
            //NQueen
            if (false)
            {
                Queen queen = new Queen(8);
                queen.StartSetQueen();
            }

            if (false)
            {
                WarnsdorfKnight warnsdorfKnight = new WarnsdorfKnight();

                warnsdorfKnight.StartKnightTour(90);
            }


            if (false)
            {
                HeuristicQueen heuristicQueen = new HeuristicQueen();
                //wyswietlanie czasow dla algorytmu warnsdorffa + trasa
                heuristicQueen.StartSetQueen(23, true);

                for (int i = 50; i < 400; i += 50)
                    heuristicQueen.StartSetQueen(i, false);
            }

            //Hash Table
            if (true) 
            {
                HashTable<double> hashTable3 = new HashTable<double>();



                int[] array1 = { 1, 2200, 301, 109,1111,100,200301, 2014,10406,23431, 1235401,10234,11111,403011,4456677,1928941,192841899,2,4 };
                int[] array2 = { 13, 31, 35, 9, 11, 100, 20301, 214, 1046, 2431, 135401, 1234, 111, 4311, 45677, 128941, 192841899, 20039, 4111 };
                int[] array3 = { 19, 22009, 3019, 1099, 11119, 1009, 2003019, 20149, 104069, 23991, 123512591, 1023334, 11143, 405349851};

                HashTable<int> hashTable = new HashTable<int>();


                string[] value2 = {"matylda","edmund","marcin","walery","grzegorz","ela","wacław","bartosz","czesław","witold","ewelina","martyna","roland","lucek","ludwig","Joahim","ZeoXi","LuaCin","Włochu" };
                string[] value = { "wojtus", "macius", "piekus", "rysiu", "stasiu" };
                string[] value4 = { "leon", "leokadia", "max", "Franc", "vitali","vasyl","craig","ludmiła","unungung", "Aalborg", "Aarhus", "Adrian", "Alojz", "Akwitania", "Aksu","a" };

                HashTable<string> hashTable1 = new HashTable<string>();

                Console.WriteLine("==========================");
                hashTable1.HashInsert(value2);
                hashTable.HashInsert(array1);

                //  hashTable1.PrintHashTable();
                hashTable.PrintHashTable();

                Console.WriteLine("==========================");
                hashTable1.HashInsert(value);
                hashTable.HashInsert(array2);

                //  hashTable1.PrintHashTable();
                hashTable.PrintHashTable();


                Console.WriteLine("==========================");
                hashTable1.HashInsert(value4);
                hashTable.HashInsert(array3);

                // hashTable1.PrintHashTable();
                hashTable.PrintHashTable();

            }


            if (false) 
            {
                Graph graph = new Graph(@"D:\dokumenty\Studia Infa Stosowana\semestr 2\ALGOR2\Algorithms\graph3.txt");
                graph.PrintGraph();
                UnionFind kruskal = new UnionFind(graph);
                kruskal.KruskalAlgorithm();
                kruskal.PrintMST();
            }
        }   
    }   
}