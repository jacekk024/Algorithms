using Algorithms.Exercise1;
using Algorithms.Exercise5;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Exercise6
{
    internal class Tarjan
    {

        private Graph graph;    // pobieramy graf;

        private readonly int N; //licznosc zbioru / liczba wierzcholkow 
        private int[] T;        // Niech T będzie tablicą i T[i] = reprezentant zbioru



        public Tarjan(Graph graph)
        {
            this.graph = graph;
            N = graph.nodes.Count;
            T = Enumerable.Repeat(-1, N).ToArray();
        }


        private void Union(int x, int y)
        {
            int a = Find(x), b = Find(y); // znajdujemy reprezentantow zbiorow
            if (a != b)
            {
                if (T[a] < T[b])            // liczby ujemne!!! mozna by dac abs
                {
                    int tmp = T[b];
                    T[a] += tmp;
                    T[b] = a;
                }
                else
                {                                   //if T[a] == T[b]
                    int tmp = T[a];
                    T[a] = b;
                    T[b] += tmp;                   // to T[b] show the number of elements in set
                }
            }
        }

        private int Find(int x) // find z kompresja sciezki
        {
            int r = x;
            while (T[r] > 0) r = T[r];
            if (T[r] > 0)
            {
                while (T[x] != r)
                {
                    int tmp = T[x];
                    T[x] = r;
                    x = tmp;
                }
            }
            return r;
        }


        public void TarjanAlg(int u) 
        {
            //MakeSet(u)
            //u.ancestor = u;
            //foreach v in u.children do
            //        Tarjan(v);
            //        Union(u, v);
            //        Find(u).ancestor = u;
            //u.color = black;

            //foreach v such that hu, vi in P do
            //    if v.color == black then
            //            wynik += [(u, v) −> Find(v).ancestor];

            //end
        }
    }
}
