using Algorithms.Exercise1;
using Algorithms.Exercise2;
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

                //skoczek z marginesem?
                //drukowanie czasu dla kolejnych n + rozne rozmiary tablicy
            }
            //NQueen
            if (false)
            {
                Queen queen = new Queen(8);
                queen.StartSetQueen();
                //drukowanie czasu wszystkie rozwiazania 
            }



        }   
    }   
}