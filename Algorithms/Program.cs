using Algorithms.Exercise1;
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

                int[] timeUsed = {1,1,1};
                Exercise1.Permutation<int> perm = new Permutation<int>();
                perm.SetPermutationValues(data, timeUsed);
            }

            //Combination
            if (false) 
            {
                Exercise1.Combination<int> comb = new Exercise1.Combination<int>();
                int[] data = { 1, 2, 3, 8};
                comb.SetCombinationValues(data,2);         
            }

            //Variation
            if (true)
            {
                Exercise1.Variation<int> variation = new Exercise1.Variation<int>();
                int[] data = { 1, 2, 3, 4};
                int[] timeUsed = { 1, 1,1,1 };
                variation.SetVariationValues(data,3, timeUsed);
            }

            //Knight
            if (false) 
            {
                Exercise2.Knight knight = new Exercise2.Knight(5);
                knight.StartKnightTour();
            }
            //NQueen
            if (false)
            {
                Exercise2.Queen queen = new Exercise2.Queen(4);
                queen.StartSetQueen();
            }
        }   
    }   
}