using Algorithms.Exercise5;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Exercise9
{
    internal class PreFlow
    {
        private Graph graph;
        private int[] excess;
        private int[] height;
        private int N;

        public PreFlow(Graph graph) 
        {
            this.graph = graph;
            N = graph.vertices.Count;
            excess = new int[N];
            height = new int[N];
        }

        void Push(int u, int v)
        {

                var edge = graph.edges.First(x => x.Vertex1 == u && x.Vertex2 == v);
                int d = Math.Min(excess[u], edge.Weight - edge.Flow);
                
                graph.edges.First(x => x.Vertex1 == u && x.Vertex2 == v).Flow = graph.edges.First(x => x.Vertex1 == u && x.Vertex2 == v).Flow + d;
                graph.edges.First(x => x.Vertex2 == u && x.Vertex1 == v).Flow = graph.edges.First(x => x.Vertex2 == u && x.Vertex1 == v).Flow - d;
                excess[u] = excess[u] - d;
                excess[v] = excess[v] + d;
        }

        void Lift(int u)
        {
            for (int i = 0; i < N; i++) 
            {
                if (graph.edges[i].Vertex1 == u)               
                    if (graph.edges[i].Weight > graph.edges[i].Flow)
                        height[u] = Math.Min(height[i], graph.edges[i].Weight - graph.edges[i].Flow) + 1;
            }
        }

        public void InitilizePreFlow(int s) 
        {
            // Default after declaration
            //  foreach u ∈ V do
            //      h[u]=0, e[u]=0;
            //  foreach (u, v) ∈ E do
            //      f [u,v]=0, f [v,u]=0;

            height[s] = N;
            excess[s] = int.MaxValue;

            //preflow
            for (int u = 0; u < N; u++)
            {
                if (graph.edges[u].Vertex1 == s) 
                {
                    graph.edges[u].Flow = graph.edges[u].Weight;
                    excess[u] = graph.edges[u].Weight;
                    graph.edges.First(x => x.Vertex1 == u && x.Vertex2 == s).Weight = -graph.edges[u].Flow;
                }
            }
        }

        public int CheckExcess(int s) 
        {
            for (int i = 0; i < N; i++)
                if (excess[i] > 0 && i != s)
                    return i;
            return -1;
        }

        public void GenericPreFlow(int s,int t)
        {
            InitilizePreFlow(s);
            int u;
            while ((u = CheckExcess(s)) != -1)
            {
                for (int v = 0; v < N; v++) 
                {
                    int c = graph.edges[v].Weight;
                    int f = graph.edges[v].Flow;

                    if (height[u] > height[v] )
                        Push(u, v);
                    else
                        Lift(u);
                }
            }
            int max_flow = 0;
            for (int i = 0; i < N; i++)
                max_flow += graph.edges.First(x => x.Vertex1 == i && x.Vertex2 == t).Flow;

            Console.WriteLine($"Max flow is {max_flow}");
        }       
    }
}

