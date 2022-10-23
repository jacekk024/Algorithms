using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Exercise1
{
    internal class Combination<T>
    {
        private List<T> combinationResult = new List<T>();
        private List<List<T>> allCombination = new List<List<T>>();
        private Stopwatch watch = new Stopwatch();

        public void SetPermutationValues(T[] data, int[] timeUsed)
        {
            try
            {
                watch.Start();
                Permute(data, timeUsed);
                watch.Stop();
            }
            catch (Exception)
            {
                Console.WriteLine("Incorrect size of arrays!");
            }
        }

        public void ShowPermutationResult()
        {
            foreach (var combination in allCombination)
            {
                foreach (var item in combination)
                    Console.Write(item);
                Console.WriteLine();
            }
            Console.WriteLine("Time elapsed: " + watch.ElapsedMilliseconds + "ms");
        }



    }
}
