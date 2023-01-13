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

        private Graph graph;        // pobieramy graf;

        private readonly int N;     // Licznosc zbioru / liczba wierzcholkow 
        private int[] T;            // Niech T będzie tablicą i T[i] = reprezentant zbioru
        private int[] ancestor;     // Tablica przodkow wierzcholka
        private bool[] processed;    // Tablica wierzcholkow przetworzonych

        List<Tuple<int, int>> list;

        public Tarjan(Graph graph)
        {
            this.graph = graph;
            N = graph.vertices.Count;

            T = new int[N];
            processed = new bool[N];
            ancestor = new int[N];
           
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




        public void FindNearestCommonAncestor(List<Tuple<int, int>> list) 
        {
            this.list = new List<Tuple<int, int>>(list);
            Console.WriteLine(list.Count);
            TarjanAlg(0);// zaczynasz od pierwszego wierzcholka w drzewie 
        }

        private void MakeSet(int u) 
        {
            T[u] = -1; //ustawiamy wierzcholek jako reprezentanta    
        }

        private void TarjanAlg(int u) 
        {
            MakeSet(u);

            ancestor[u] = u; // 

            //sasiedzi wierzcholka u
            var vertices = graph.vertices.First(x => x.number == u+1).neighbours;

            //przechodzimy po sasiadach  wierzcholka u
            foreach (var v in vertices)
            {
                //v jest od 1 do N dlatego daje v-1
                TarjanAlg(v-1);
                Union(u, v-1);
                ancestor[Find(u)] = u;
            }

            processed[u] = true; // jesli nie ma juz sasiadow to oznaczamy ze przetworzony
  
            //sprawdzamy kolejnych par wierzcholkow czy wierzcholek jest na liscie zapytan
            for (int i = 0; i < list.Count;i++) 
            {
                //jesli u rowny pierwszemu wierzcholkowi to sprawdzamy czy przeciwlegly przetworzony
                if(u == list[i].Item1-1 && processed[list[i].Item2-1])
                    Console.WriteLine($"Nearest Common Ancestor for {list[i].Item1} and {list[i].Item2}: {ancestor[Find(list[i].Item2-1)] + 1}");     
                else if(u == list[i].Item2-1 && processed[list[i].Item1-1])
                    Console.WriteLine($"Nearest Common Ancestor for {list[i].Item1} and {list[i].Item2}: {ancestor[Find(list[i].Item1-1)] + 1}");
            }
        }
    }
}
