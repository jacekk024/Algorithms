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

        private void ShowVariationResult()
        {
            foreach (var variation in allVariation)
            {
                foreach (var item in variation)
                    Console.Write(item);
                Console.WriteLine();
            }
            Console.WriteLine("Time elapsed: " + watch.ElapsedMilliseconds + "ms");
        }

        public void SetVariationValues(T[] data,int k, int[] timeUsed,bool repetition)
        {
            try
            {
                watch.Start();
                if(repetition)
                    VariatonUntilWithRepetition(data,k);
                else
                    VariatonUntil(data, k, timeUsed);

                watch.Stop();
                ShowVariationResult();
            }
            catch (Exception)
            {
                Console.WriteLine("Incorrect size of arrays!");
            }
        }

        private void VariatonUntilWithRepetition(T[] data, int k)
        {
            if (k == 0)
            {
                allVariation.Add(new List<T>(variationList));
            }
            else
            {
                for (int i = 0; i < data.Length; i++)
                {

                    variationList.Add(data[i]);

                    VariatonUntilWithRepetition(data, k - 1);

                    variationList.RemoveAt(variationList.Count - 1);
                }
            }
        }

        private void VariatonUntil(T[] data,int k, int[] timeUsed) 
        {
            if (k == 0)
            {
                allVariation.Add(new List<T>(variationList));
            }
            else
            {
                for (int i = 0; i < timeUsed.Length; i++)
                {
                    if (timeUsed[i] == 0) // jesli nie mamy danej opcji to nie powtarzamy
                        continue;

                    timeUsed[i]--;

                    variationList.Add(data[i]);

                    VariatonUntil(data,k-1, timeUsed);

                    timeUsed[i]++;
                    variationList.RemoveAt(variationList.Count - 1);
                }
            }
        }
    }
}
