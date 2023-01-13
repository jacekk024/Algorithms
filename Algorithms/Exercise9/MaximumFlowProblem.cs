using Algorithms.Exercise5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Exercise9
{
    internal class MaximumFlowProblem
    {
        private Graph graph;
        private Graph rGraph;

        private int N;

        public MaximumFlowProblem(Graph graph, Graph rGraph) 
        {
            this.graph = graph;
            this.rGraph = rGraph;
            N = graph.vertices.Count;
        }

        bool bfs(int s, int t, int[] augmentingPath)
        {
            bool[] visited = new bool[N];

            List<int> que = new List<int>();
            que.Add(s);
            visited[s] = true;
            augmentingPath[s] = -1;


            while (que.Count != 0)
            {
                int u = que[0];
                que.RemoveAt(0);
                var vertices = graph.vertices.First(x => x.number == u).neighbours;

                foreach (var v in vertices)
                {
                    var edgeCost = graph.edges.First(x => x.Vertex1 == u && x.Vertex2 == v).Weight;


                    if (visited[v] == false && edgeCost > 0)
                    {

                        if (v == t)
                        {
                            augmentingPath[v] = u;
                            return true;
                        }
                        que.Add(v);
                        augmentingPath[v] = u;
                        visited[v] = true;
                    }
                }
            }
            return false;
        }


        public int fordFulkerson(int s,int t) 
        {
            int maxFlow = 0; // There is no flow initially
            int u,v; // vertecies of current edge

            int[] augmentingPath = new int[N];


            while (bfs(s,t, augmentingPath)) 
            {
                int cf = int.MaxValue;

                for (v = t; v != s; v = augmentingPath[v])
                {                                      
                    u = augmentingPath[v];

                    var cost = rGraph.edges.First(x => x.Vertex1 == u && x.Vertex2 == v).Weight;

                    cf = Math.Min(cf, cost);
                }

                for (v = t; v != s; v = augmentingPath[v])
                {
                    u = augmentingPath[v];
                    rGraph.edges.First(x => x.Vertex1 == u && x.Vertex2 == v).Weight -= cf;
                    rGraph.edges.First(x => x.Vertex1 == v && x.Vertex2 == u).Weight += cf;
                }

                // Add path flow to overall flow
                maxFlow += cf;
            }
            return maxFlow; 
        }
    }
}
