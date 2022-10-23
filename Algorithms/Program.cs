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
                int[] data = { 1,2};
                float[] data2 = { 3.1F, 1.4F, 4.1F }; 
                string[] data3 = { "raz", "dwa", "trzy" };

                int[] timeUsed = {1,2};
                Exercise1.Permutation<int> perm = new Permutation<int>();
                perm.SetPermutationValues(data, timeUsed);
                perm.ShowPermutationResult();
            }
            //Knight
            if (false) 
            {
                Exercise2.Knight knight = new Exercise2.Knight(5);
                knight.StartKnightTour();
            }

            if (true)
            {
                Exercise2.Queen queen = new Exercise2.Queen(4);
                queen.StartSetQueen();
            }
        }   
    }   
}