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
        private Graph graphCopy;

        private int[] visited;
        private Stack<int> processed;
        private int[] scc;

        private int N; // ilosc wierzcholkow
        private int n;

        public TwoCNF(Graph graph)
        {
            this.graph = graph;
            graphCopy = graph;  
            N = graph.vertices.Count;
            visited = new int[N+1];
            scc = new int[N+1];
            processed = new Stack<int>(N);
            n = graph.n;
        }

        void DFS(int u,int k,bool flag)
        {
            var vertices = graph.vertices.First(x => x.number == u).neighbours;
            visited[u] = k;
            foreach (var v in vertices)
                if (visited[v] == 0) DFS(v,k,flag);
            if (flag)
                processed.Push(u);
            else
            {
                scc[u] = k;
                graph.vertices.First(x => x.number == u).scc = k;
            }
        }

        public void Print2CNF() 
        {
            var vertList = graphCopy.vertices.OrderBy(x => x.number).ToList();

            Console.WriteLine("SSS:");
            for (int i = 1; i <= N; i++)

                if (vertList[i - 1].number > n)
                {
                    int p = vertList[i - 1].number - n;
                    Console.WriteLine(-p + ":" + scc[i]);
                }
                else
                    Console.WriteLine(vertList[i - 1].number + ":" + scc[i]);
        }

        public void CheckLogicFormula() 
        {

            var vertList = graphCopy.vertices.OrderBy(x => x.number).ToList();

            int k = scc.Min()+1;

            while (k <= scc.Max())
            {
                var sccList = graph.vertices.FindAll(x => x.scc == k);

                foreach (var vertex in sccList)
                {
                    if (vertex.state == false)
                    {
                            vertex.state = true;

                            if (vertex.number <= n)
                                graphCopy.vertices.First(x => x.number == vertex.number + n).state = false;
                            else
                                graphCopy.vertices.First(x => x.number == vertex.number - n).state = false;
                    }
                }
                k++;
            }
            Console.WriteLine("==========================================");
            Console.WriteLine("Logic formula check");

            foreach (var vert in vertList) 
            {
                if(vert.number > n )
                    Console.WriteLine( $"{-(vert.number-n)}:{vert.state} scc:{vert.scc}");
                else
                    Console.WriteLine($"{vert.number}:{vert.state} scc:{vert.scc}");
            }

            bool result = true;
            bool val1, val2;
            foreach (var form in graphCopy.logicFormula)
            {
                if (form.Item1 < 0)
                    val1 = graphCopy.vertices.First(x => x.number == -form.Item1 + n).state;
                else
                    val1 = graphCopy.vertices.First(x => x.number == form.Item1).state;
                if (form.Item2 < 0)
                    val2 = graphCopy.vertices.First(x => x.number == -form.Item2 + n).state;
                else
                    val2 = graphCopy.vertices.First(x => x.number == form.Item2).state;



                result &= (val1 || val2);
            }

            graph.PrintLogicalFormula();
            Console.WriteLine("result is " + result);
        }

        public bool Algorithm2CNF() 
        {
            for (int u = 1; u <= N; u++)
                if (visited[u] == 0) 
                    DFS(u,1,true);

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
                    DFS(u, ++k,false);
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
