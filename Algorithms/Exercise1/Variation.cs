using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Exercise1
{
    internal class Variation<T>
    {
        private List<T> variationList = new List<T>();
        private List<List<T>> allVariation = new List<List<T>>();
        private Stopwatch watch = new Stopwatch();

        private void ShowCombinationResult()
        {
            foreach (var variation in allVariation)
            {
                foreach (var item in variation)
                    Console.Write(item);
                Console.WriteLine();
            }
            Console.WriteLine("Time elapsed: " + watch.ElapsedMilliseconds + "ms");
        }

        public void SetVariationValues(T[] data,int k, int[] timeUsed)
        {
            try
            {
                watch.Start();
                VariatonUntil(data,0,k, timeUsed);
                watch.Stop();
                ShowCombinationResult();
            }
            catch (Exception)
            {
                Console.WriteLine("Incorrect size of arrays!");
            }
        }

        private void VariatonUntil(T[] data, int step,int k, int[] timeUsed) //tablicy timeUSed[]
        {
            if (step >= k)
            {
                allVariation.Add(new List<T>(variationList));
            }
            else
            {
                for (int i = step; i < data.Length; i++)
                {
                    if (timeUsed[i] == 0) // jesli nie mamy danej opcji to nie powtarzamy
                        continue;

                    timeUsed[i]--;

                    variationList.Add(data[i]);

                    VariatonUntil(data, step + 1,k, timeUsed);

                    timeUsed[i]++;
                    variationList.RemoveAt(variationList.Count - 1);
                }
            }
        }





    }
}
