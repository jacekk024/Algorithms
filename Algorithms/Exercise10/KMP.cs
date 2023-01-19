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
            pi[1] = 0;

            int k = 0;
            for (int q = 2 ;q < M; q++ )
            {
                while (k > 0 && P[k+1] != P[q])
                    k = pi[k];
                if (P[k+1] == P[q]) 
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
            for (int i = 1; i < N; i++)
            {
                while (q > 0 && (P[q +1] != T[i]))
                    q = pi[q];
                if (P[q + 1] == T[i])
                    q++;

                 if (q == M - 1)
                 {
                        Console.WriteLine("Pattern found: " + (q - M)+1); // Pattern found on q-m;
                        q = pi[q];
                 }
            }
        }
    }
}
