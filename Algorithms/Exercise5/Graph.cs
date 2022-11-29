using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Exercise5
{
    internal class Graph
    {

        public List<Edge> edges = new List<Edge>();     //lista krawedzi
        public List<int> nodes = new List<int>();       //lista wierzcholkow
        public Graph(string path) => readFile(path);

        public void PrintGraph()
        {
            foreach (var edge in edges) 
            {
                Console.WriteLine($"{edge.Vertex1} -> {edge.Vertex2} : {edge.Weight}");
            }
            
            Console.WriteLine();

            Console.WriteLine($"Nodes number: {nodes.Count}");

            var edges_sorted = edges.OrderBy(x => x.Weight);

            foreach (var edge in edges_sorted)
            {
                Console.WriteLine($"{edge.Vertex1} -> {edge.Vertex2} : {edge.Weight}");
            }
        }

        private void readFile(string path)
        {
            string s;
            StreamReader sr = File.OpenText(path);
            
            while ((s = sr.ReadLine()) != null)
            {
                string[] subs = s.Split(' ');               
                AddEdge(int.Parse(subs[0]),int.Parse(subs[1]), int.Parse(subs[2]));  
            }
            sr.Close();
            AddNodes();
        }

        private void AddNodes() 
        {
            foreach (var item in edges) 
            {
                if (!nodes.Contains(item.Vertex1))
                    nodes.Add(item.Vertex1);
                if (!nodes.Contains(item.Vertex2))
                    nodes.Add(item.Vertex2);
            }
        } 

        public void AddEdge(int vertex1, int vertex2, int weight) 
        {
            Edge edge = new Edge(vertex1, vertex2, weight);

            if(!edges.Contains(edge))
                edges.Add(edge);
        }

        public void RemoveEdge(int vertex1, int vertex2) 
        {
            var edge = edges.Single(x => x.Vertex1 == vertex1 && x.Vertex2 == vertex2);

            if (edges.Contains(edge))          
                edges.Remove(edge);            
        }
    }

 

    internal class Edge 
    {
        public readonly int Vertex1;
        public readonly int Vertex2;
        public readonly int Weight;
        
        public Edge(int vertex1, int vertex2, int weight) 
        {
            Vertex2 = vertex2;
            Vertex1 = vertex1;
            Weight = weight;
        }
    }
}
