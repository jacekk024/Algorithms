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
                string value = "matyluyvdcyuvdscyda1111eubciuebciuebcuieb";
                string[] value2 = {"matyla","edmund","marcin","walery" };
                int[] value3 = { 1, 2200, 301, 109 };
                double[] value4 = { 1.23, 1.44, 0.11, 0.0001 };


                HashTable<int> hashTable = new HashTable<int>();


                Console.WriteLine(hashTable.HashInt(17283));
                Console.WriteLine(hashTable.hash.Length);
                //hashTable.hash[hashTable.HashInt(17283)].Add(17283);
                hashTable.HashInsert(17283);
                Console.WriteLine($"Hash Search: {hashTable.HashSearch(17283)}");
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