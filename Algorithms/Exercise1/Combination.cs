using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Exercise1
{
    internal class Combination<T>
    {
        private List<T> combinationList = new List<T>();
        private List<List<T>> allCombination = new List<List<T>>();
        private Stopwatch watch = new Stopwatch();

        private void ShowCombinationResult()
        {
            foreach (var combination in allCombination)
            {
                foreach (var item in combination)
                    Console.Write(item);
                Console.WriteLine();
            }
            Console.WriteLine("Time elapsed: " + watch.ElapsedMilliseconds + "ms");
        }

        public void SetCombinationValues(T[] data,int k)
        {
            try
            {
                watch.Start();
                CombinationUntil(data,k,0);
                watch.Stop();
                ShowCombinationResult();
            }
            catch (Exception)
            {
                Console.WriteLine("Incorrect size of arrays!");
            }
        }

        private void CombinationUntil(T[]data,int step, int k) //tablicy timeUSed[]
        {
            if (step == 0)
            {
                allCombination.Add(new List<T>(combinationList));
            }
            else
            {
                for (int i = k; i < data.Length; i++)
                {
                    combinationList.Add(data[i]);

                    CombinationUntil(data, step - 1, i + 1);

                    combinationList.RemoveAt(combinationList.Count - 1);
                }
            }
        }
    }
}
