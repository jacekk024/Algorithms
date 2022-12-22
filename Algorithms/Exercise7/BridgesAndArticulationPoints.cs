using Algorithms.Exercise5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Exercise7
{
    internal class BridgesAndArticulationPoints
    {

        private int[] visited;
        private int[] low;
        private Graph graph;
        private int size;
        private int count;

        private List<int> articulationPoints = new List<int>(); 

        public BridgesAndArticulationPoints(Graph graph) 
        {
            this.graph = graph;
            size = graph.vertices.Count;
            visited = new int[size];
            low = new int[size];
            count = 0;
        }

        public void FindArticulationPoints()
        {
            //set starting point
            Random rnd = new Random();
            int root = rnd.Next(0, size);
            Console.WriteLine($"root: {root+1}");

            ArticulationPointsDFS(root, root);

            foreach(var art in articulationPoints)
              Console.WriteLine($"{art + 1}  jest punktem artykulacji");

        }
        public void FindArticulationPoints(int root)
        {
            //set starting point 
            ArticulationPointsDFS(root, root);
        }


        //dodac przeciazenia losowania i ustawiania punktu startowego
        public void FindBridges() 
        {
            Random rnd = new Random();
            int root = rnd.Next(0, size);
            Console.WriteLine($"root: {root+1}");

            //set starting point
            BridgesDFS(root, root);
        }

        public void FindBridges(int root)
        {
            //set starting point
            BridgesDFS(root, root);
        }

        private void BridgesDFS(int u,int uFather) 
        {
            visited[u] = low[u] = ++count;

            var vertices = graph.vertices.Find(x => x.number-1 == u).neighbours;

            foreach (var v in vertices) 
            {
                if(v-1 != uFather) 
                {
                    if (visited[v - 1] == 0)
                    {
                        BridgesDFS(v-1, u);
                        low[u] = low[u] < low[v - 1] ? low[u] : low[v-1];
                    }
                    else
                        low[u] = low[u] < visited[v - 1] ? low[u] : visited[v-1];
                }
                
            }
                if (low[u] == visited[u] && u != uFather)
                    Console.WriteLine($"{u+1} {uFather+1} jest mostem");                 
        }

        private void ArticulationPointsDFS(int u, int uFather)
        {
            int countChildren = 0;

            visited[u] = low[u] = ++count;

            var vertices = graph.vertices.Find(x => x.number - 1 == u).neighbours;

            foreach (var v in vertices)
            {
                if (v - 1 != uFather)
                {
                    if (visited[v - 1] == 0)
                    {
                        countChildren++;

                        ArticulationPointsDFS(v - 1, u);
                        low[u] = low[u] < low[v - 1] ? low[u] : low[v - 1];
                    }
                    else
                        low[u] = low[u] < visited[v - 1] ? low[u] : visited[v - 1];
                }

                if (low[v - 1] >= visited[u] && u != uFather)
                {
                    if(!articulationPoints.Contains(u))
                        articulationPoints.Add(u);
                }
                if (uFather == u && countChildren>1)
                {
                    if (!articulationPoints.Contains(u ))
                        articulationPoints.Add(u);
                }
            }
        }
    }
}
