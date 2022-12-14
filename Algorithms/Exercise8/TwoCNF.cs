using Algorithms.Exercise5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Exercise8
{
    internal class TwoCNF
    {
        private Graph graph;


        private int[] visited;
        private Stack<int> processed;
        private int[] scc;

        private int N; // ilosc wierzcholkow

        private int n;

        public TwoCNF(Graph graph)
        {
            this.graph = graph;
            N = graph.vertices.Count;
            visited = new int[N+1];
            scc = new int[N+1];
            processed = new Stack<int>(N);
            n = graph.n;
        }


        void DFS(int u,int k)
        {
            var vertices = graph.vertices.First(x => x.number == u).neighbours;
            visited[u] = k;
            foreach (var v in vertices)
                if (visited[v] == 0) DFS(v,k);
            processed.Push(u);       
        }

        void DFS2(int u, int k)
        {

            var vertices = graph.vertices.First(x => x.number == u).neighbours;
            visited[u] = k;
            scc[u] = k;
            foreach (var v in vertices)
                if (visited[v] == 0) DFS2(v, k);
        }

        public void Print2CNF() 
        {
            Console.WriteLine("SSS:");
            for (int i = 1; i <= N;i++ )
                Console.WriteLine(i +":"+ scc[i]);
        }

        public bool Algorithm2CNF() 
        {
            for (int u = 1; u <= N; u++)
                if (visited[u] == 0) 
                    DFS(u,1);

            graph.TransposeGraph();

            Console.WriteLine("Vertex neighbours list after transpose: ");
            foreach (var node in graph.vertices)
                node.PrintNeighbours();

            visited = new int[N+1];
            int k = 0;


            while (processed.Count != 0)
            {
                int u = processed.Peek();
                processed.Pop();
                if (visited[u] == 0)
                {
                    DFS2(u, ++k);
                }
            }

            for (int i = 1; i <= n; i++)
            {
                // jesli a i -a w jesdnej scc
                if (scc[i] == scc[i+n])                
                    return false;                             
            }



            return true;
        }
    }
}
