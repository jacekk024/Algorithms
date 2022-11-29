using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Algorithms.Exercise5
{
    internal class UnionFind
    {
        private Graph graph; // pobieramy graf;
        private List<Edge> kruskalMST = new List<Edge>(); // min drzewo rozpinajace

        private readonly int N; //licznosc zbioru / liczba wierzcholkow 
        private int[] T;        // Niech T będzie tablicą i T[i] = reprezentant zbioru
        private int pathCost = 0;

        public UnionFind(Graph graph)
        {
            this.graph = graph;
            N = graph.nodes.Count;
            T = Enumerable.Repeat(-1, N).ToArray();
        }
        
        public void PrintMST() 
        {
            Console.WriteLine("MST edges:");
            foreach (var edge in kruskalMST)
                Console.Write($"{edge.Vertex1} - {edge.Vertex2} \n");
            Console.WriteLine("T array:");
            for (int i = 0; i < N; i++)
                Console.Write($"T[{i}] = {T[i]} \n");

            Console.WriteLine($"Minimal cost of mst: {pathCost}");    
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
                    T[a] = b;
                    T[b]--;                   // to T[b] show the number of elements in set
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


        public void KruskalAlgorithm() 
        {
            // porzadkujemy krawedzie od najkrotszej do najdluzszej 
            var sortedEdges = graph.edges.OrderBy(x => x.Weight);
            int counter = 0;

            // wybieramy krawedzie najoptymalniejsze i dokladamy je do rozwiazania

            while (counter < N-1) 
            {
                foreach (var edge in sortedEdges)// wybieramy krawedzie najoptymalniejsze i dokladamy je do rozwiazania
                {
                    // bierzesz 1 wierzcholek i sprawdzasz dostepne krawedzie 
                    int vertex1 = edge.Vertex1 - 1; // wierzcholki mam ponumerowane od 1 do n
                    int vertex2 = edge.Vertex2 - 1;

                    if (Find(vertex1) != Find(vertex2)) //sprawdzamy czy nie zamyka sie cykl
                    {
                        pathCost += edge.Weight;
                        Union(vertex1, vertex2);
                        counter++;
                        kruskalMST.Add(edge);
                    }
                }   
            }
        }
    }
}
