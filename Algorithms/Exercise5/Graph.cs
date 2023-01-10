using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Exercise5
{
    internal class Graph
    {

        public List<Edge> edges = new List<Edge>();     //lista krawedzi
        public List<int> nodes = new List<int>();       //lista wierzcholkow

        public List<Vertex> vertices = new List<Vertex>();  //lista  wierzcholka tarjan

        public bool isDirected = true;
        StringBuilder formula = new StringBuilder();

        public int n;

        public Graph(string path, bool isDirected)
        {
            this.isDirected = isDirected;
            readFile(path);
        }

        public Graph(string path)
        {
            ReadFile2CNF(path);
        }

        public Graph() { }


        public void TransposeGraph()
        {

           List<Vertex> verticesTranspose = new List<Vertex>();
           List<int> nodesTranspose = new List<int>();
            foreach (var vertex in vertices)
            {
                foreach(var neighbour in vertex.neighbours)
                {
                    Vertex v = new Vertex(neighbour);

                    if (!nodesTranspose.Contains(neighbour))
                    {
                        nodesTranspose.Add(neighbour);
                        verticesTranspose.Add(v);
                    }
                    if (!nodesTranspose.Contains(vertex.number)) // dodaje puste wierzcholki
                    {
                        Vertex v1 = new Vertex(vertex.number);
                        nodesTranspose.Add(vertex.number);
                        verticesTranspose.Add(v1);
                    }
                    verticesTranspose.Find(x => x.number == v.number).AddNeighbourToVertex(vertex.number);
                }
            }

            vertices = new List<Vertex>(verticesTranspose);
        }

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

        public void PrintLogicalFormula() 
        {
            int len = formula.Length;
            formula.Replace("&&", "",len-3,2);
            Console.WriteLine("Logical Formula:");
            Console.WriteLine(formula.ToString()+"\n");
        
        }


        public void TransformGraph()
        {
            int n = vertices.Max(x => x.number);

            foreach (var vertex in vertices)
            {
                if (vertex.number < 0)
                    vertex.number = -vertex.number + n;
                for (int i = 0; i < vertex.neighbours.Count; i++)
                {
                    if (vertex.neighbours[i] < 0)
                        vertex.neighbours[i] = -vertex.number + n;
                }
            }
        }


        private void ReadFile2CNF(string path)
        {
            string s;
            StreamReader sr = File.OpenText(path);

            n = int.Parse(sr.ReadLine());

            while ((s = sr.ReadLine()) != null)
            {
                string[] subs = s.Split(' ');
                int a = int.Parse(subs[0]);
                int b = int.Parse(subs[1]);

                formula.Append($"({a} || {b}) && ");



                if (a > 0 && b > 0)
                {
                    AddEdge(a + n, b, 0);
                    AddEdge(b + n, a, 0);
                }
                else if (a > 0 && b < 0)
                {
                    AddEdge(a + n, n - b, 0);
                    AddEdge(-b, a, 0);
                }
                else if (a < 0 && b > 0)
                {
                    AddEdge(-a,  b, 0);
                    AddEdge(b , n - a, 0);
                }
                else
                {
                    AddEdge(-a, n - b, 0);
                    AddEdge(-b, n - a, 0);
                }


                //AddEdge(-int.Parse(subs[0]), int.Parse(subs[1]),0);
                //AddEdge(-int.Parse(subs[1]), int.Parse(subs[0]), 0);

            }

          //  int n = vertices.Max(x => x.number);




            sr.Close();
            AddNodes();
            AddNeighbours();
        }


        private void readFile(string path)
        {
            string s;
            StreamReader sr = File.OpenText(path);
            
            while ((s = sr.ReadLine()) != null)
            {
                string[] subs = s.Split(' ');
                if(isDirected)
                    AddEdge(int.Parse(subs[0]),int.Parse(subs[1]), int.Parse(subs[2]));
                else 
                {
                    AddEdge(int.Parse(subs[0]), int.Parse(subs[1]), int.Parse(subs[2]));
                    AddEdge(int.Parse(subs[1]), int.Parse(subs[0]), int.Parse(subs[2]));

                }
            }
            sr.Close();
            AddNodes();
            AddNeighbours();
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

        private void AddNeighbours() 
        {

            foreach(var n in nodes) 
            {
                Vertex v = new Vertex(n);
                vertices.Add(v);

                var sortedVertex = edges.Where(x => x.Vertex1 == n).Select(x => x.Vertex2);

                foreach(var u in sortedVertex)
                    v.AddNeighbourToVertex(u);
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
    internal class Vertex
    {
        public int number;
        public List<int> neighbours = new List<int>();

        public Vertex(int number) => this.number = number;

        public void AddNeighbourToVertex(int u)
        {
            neighbours.Add(u); 
        }

        public void PrintNeighbours() 
        {
            Console.Write($"{number}: ");
            foreach (int i in neighbours)
                Console.Write($"{i} ");
            Console.WriteLine();
        }
    }
 

    internal class Edge 
    {
        public int Vertex1;
        public int Vertex2;
        public int Weight;
        
        public Edge(int vertex1, int vertex2, int weight) 
        {
            Vertex2 = vertex2;
            Vertex1 = vertex1;
            Weight = weight;
        }
    }
}
