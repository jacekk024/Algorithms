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
                
                string[] value2 = {"matylda","edmund","marcin","walery","grzegorz","ela","wacław","bartosz","czesław","witold","ewelina","martyna","roland","lucek","ludwig","Joahim","ZeoXi","LuaCin","Włochu" };
                int[] value3 = { 1, 2200, 301, 109,1111,100,200301, 2014,10406,23431, 1235401,10234,11111,403011,4456677,1928941,192841899,2,4 };
                string[] value = { "wojtus", "macius", "piekus", "rysiu", "stasiu" };

                string[] value4 = { "leon", "leokadia", "max", "Franc", "vitali","vasyl","craig","ludmiła","unungung", "Aalborg", "Aarhus", "Adrian", "Alojz", "Akwitania", "Aksu","a" };

                HashTable<int> hashTable = new HashTable<int>();
                HashTable<string> hashTable1 = new HashTable<string>();


                hashTable1.HashInsert(value2);
                //Console.WriteLine($"Hash Search matylda: {hashTable1.HashSearch("matylda")}");
    
                hashTable1.PrintHashTable();
                Console.WriteLine("==========================");


                hashTable1.HashInsert(value);

                hashTable1.PrintHashTable();



                Console.WriteLine("==========================");
                hashTable1.HashInsert(value4);
                hashTable1.PrintHashTable();

                Console.WriteLine(hashTable1.N);
                Console.WriteLine(hashTable1.M);

                //   hashTable.HashInsert(value3);
                //  Console.WriteLine($"Hash Search 2200: {hashTable.HashSearch(2200)}");
                // hashTable.PrintHashTable();

                // Console.WriteLine("Usuwanie elementu z tablicy: ");
                //hashTable.HashDelete(2200);
                //    Console.WriteLine($"Hash Search 2200: {hashTable.HashSearch(2200)}");
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