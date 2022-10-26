using System.Diagnostics;

namespace Algorithms.Exercise1
{
    internal class  Permutation<T>
    {
        private List<T> permutationResult = new List<T>();
        private List<List<T>> allPermutation = new List<List<T>>();
        private Stopwatch watch = new Stopwatch();


        public void SetPermutationValues(T[] data, int[] timeUsed) 
        {
            try
            {
                watch.Start();
                Permute(data, timeUsed);
                watch.Stop();            
            } 
            catch(Exception )
            {
                Console.WriteLine("Incorrect size of arrays!");
            }
        }

        public void ShowPermutationResult() 
        {
            foreach (var permutation in allPermutation)
            {
                foreach (var item in permutation)
                    Console.Write(item);
                Console.WriteLine();
            }
            Console.WriteLine("Time elapsed: " + watch.ElapsedMilliseconds + "ms");
        }

        private void Permute(T[] data, int[] timeUsed) //tablicy timeUSed[]
        {

            if (permutationResult.Count == timeUsed.Length) {
                allPermutation.Add(new List<T>(permutationResult));
            }
            else { 
                
                for(int i = 0; i < timeUsed.Length; i++) 
                {
                    if (timeUsed[i] == 0) // jesli nie mamy danej opcji to nie powtarzamy
                        continue;

                    timeUsed[i]--;
                    permutationResult.Add(data[i]);
                    Permute(data, timeUsed);

                    timeUsed[i]++;
                    permutationResult.RemoveAt(permutationResult.Count-1); 
                }     
            }
        }
    }
}
