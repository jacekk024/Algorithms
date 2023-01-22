using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Exercise10
{
    internal class KMP
    {
        int[] ComputePrefix(string P)
        {
            int M = P.Length;
            int[] pi = new int[M];
            pi[0] = 0;

            int k = 0;
            for (int q = 1 ;q < M; q++ )
            {
                while (k > 0 && P[k] != P[q])
                    k = pi[k];
                if (P[k] == P[q]) 
                    k++;
               
                pi[q] = k;
            }
            return pi;
        }

        public void MatcherKMP(string P, string T)
        {
            int N = T.Length;
            int M = P.Length;
            int[] pi = ComputePrefix(P);
            int q = 0;
            Console.WriteLine($"Text: {T}\nPattern: {P}");
            for (int i = 0; i < N; i++)
            {
                while (q > 0 && (P[q] != T[i]))
                    q = pi[q];
                if (P[q] == T[i])
                    q++;

                 if (q == M )
                 {      
                        Console.WriteLine($"Pattern found at index: {i - q + 1}"); // Pattern found on q-m;
                        q = pi[q - 1];
                 }
            }
        }
    }
}
