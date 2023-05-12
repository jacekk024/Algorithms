using Algorithms.Exercise1;
using Algorithms.Exercise10;
using Algorithms.Exercise2;
using Algorithms.Exercise3;
using Algorithms.Exercise4;
using Algorithms.Exercise5;
using Algorithms.Exercise6;
using Algorithms.Exercise7;
using Algorithms.Exercise8;
using Algorithms.Exercise9;
using System;



namespace Algorithms 
{
    class Test 
    {
        static void Main(string[] args)
        {

            //Permutation
            if (false)
            {
                int[] data = { 1, 2, 3 };
                float[] data2 = { 3.1F, 1.4F, 4.1F };
                string[] data3 = { "raz", "dwa", "trzy" };

                int[] timeUsed = { 2, 1, 1 };
                Permutation<int> perm = new Permutation<int>();
                perm.SetPermutationValues(data, timeUsed);
            }

            //Combination
            if (false)
            {
                Combination<int> comb = new Combination<int>();
                int[] data = { 1, 2, 3};
                comb.SetCombinationValues(data, 2);
            }

            //Variation
            if (false)
            {
                Variation<int> variation = new Variation<int>();
                int[] data = { 1, 2, 3 };
                int[] timeUsed = { 1, 1, 1 };
                variation.SetVariationValues(data, 2, timeUsed, false);
                Console.WriteLine();
            }

            //Knight
            if (false)
            {
                int n = 9;

                Knight knight = new Knight();
                knight.StartKnightTour(6, true);

                for (int i = 5; i <= n; i++)
                {
                    knight.StartKnightTour(i, false);
                }
            }
            //NQueen
            if (false)
            {
                Queen queen = new Queen(8);
                queen.StartSetQueen();
            }

            if (false)
            {
                WarnsdorfKnight warnsdorfKnight = new WarnsdorfKnight();

                warnsdorfKnight.StartKnightTour(90);
            }


            if (false)
            {
                HeuristicQueen heuristicQueen = new HeuristicQueen();
                //wyswietlanie czasow dla algorytmu warnsdorffa + trasa
                heuristicQueen.StartSetQueen(23, true);

                for (int i = 50; i < 400; i += 50)
                    heuristicQueen.StartSetQueen(i, false);
            }

            //Hash Table
            if (false)
            {

                double[] doubleArray1 = { 1.23, 1.9, 9.88, 1111.24, 901.3, 1.292, 9.12435, 8.123, 92847.124, 91.123, 0.000134, 1.000054, 19.0001, 8.91, 10.0001, 5.001 };
                double[] doubleArray2 = { 0.22123, 112.549, 91.0018, 113.44414, 1901.39, 11.2292, 39.124335, 80.123, 99847.0124, 915.1123, 0.000134134, 1.000054123, 12319.0001, 824.951, 130.10001, 54.0501 };
                double[] doubleArray3 = { 13.233, 1.39, 93.881, 11121.24, 9201.3, 1.2952, 93.1342435, 38.123, 9327847.1224, 931.1323, 0.30004134, 31.0400054, 149.00061, 8.951, 130.002301, 55.4001 };


                HashTable<double> hashTable2 = new HashTable<double>();

                int[] array1 = { 1, 2200, 301, 109, 1111, 100, 200301, 2014, 10406, 23431, 1235401, 10234, 11111, 403011, 4456677, 1928941, 192841899, 2, 4 };
                int[] array2 = { 13, 31, 35, 9, 11, 100, 20301, 214, 1046, 2431, 135401, 1234, 111, 4311, 45677, 128941, 192841899, 20039, 4111 };
                int[] array3 = { 19, 22009, 3019, 1099, 11119, 1009, 2003019, 20149, 104069, 23991, 123512591, 1023334, 11143, 405349851 };

                HashTable<int> hashTable = new HashTable<int>();


                string[] value2 = { "matylda", "edmund", "marcin", "walery", "grzegorz", "ela", "wacław", "bartosz", "czesław", "witold", "ewelina", "martyna", "roland", "lucek", "ludwig", "Joahim", "ZeoXi", "LuaCin", "Włochu" };
                string[] value = { "wojtus", "macius", "piekus", "rysiu", "stasiu" };
                string[] value4 = { "leon", "leokadia", "max", "Franc", "vitali", "vasyl", "craig", "ludmiła", "unungung", "Aalborg", "Aarhus", "Adrian", "Alojz", "Akwitania", "Aksu", "a" };

                HashTable<string> hashTable1 = new HashTable<string>();

                Console.WriteLine("==========================");
                hashTable1.HashInsert(value2);
                hashTable.HashInsert(array1);
                hashTable2.HashInsert(doubleArray1);


                hashTable1.PrintHashTable();
                //hashTable.PrintHashTable();
                //hashTable2.PrintHashTable();

                // string element = "matylda";

                // Console.WriteLine($"{element} ind: {hashTable1.HashSearch(element)}");


                Console.WriteLine("==========================");
                hashTable1.HashInsert(value);
                hashTable.HashInsert(array2);
                hashTable2.HashInsert(doubleArray2);


                hashTable1.PrintHashTable();
                //hashTable.PrintHashTable();
                //hashTable2.PrintHashTable();


                Console.WriteLine("==========================");
                hashTable1.HashInsert(value4);
                hashTable.HashInsert(array3);
                hashTable2.HashInsert(doubleArray3);


                hashTable1.PrintHashTable();
                //hashTable.PrintHashTable();
                //hashTable2.PrintHashTable();
            }

            //Kruskal
            if (false)
            {
                Graph graph = new Graph(@"D:\dokumenty\Studia Infa Stosowana\semestr 2\ALGOR2\Algorithms\graph3.txt",true);
                graph.PrintGraph();
                UnionFind kruskal = new UnionFind(graph);
                kruskal.KruskalAlgorithm();
                kruskal.PrintMST();
            }

            //Tarjan
            if (false)
            {

                Graph graph = new Graph(@"D:\dokumenty\Studia Infa Stosowana\semestr 2\ALGOR2\Algorithms\tarjan2.txt",true);
                graph.PrintGraph();

                Console.WriteLine("Vertex neighbours list: ");
                foreach (var node in graph.vertices)
                    node.PrintNeighbours();

                //  tarjan
                //var tuple1 = new Tuple<int, int>(5, 4);
                //var tuple2 = new Tuple<int, int>(6, 7);
                //var tuple3 = new Tuple<int, int>(3, 9);
                //var tuple4 = new Tuple<int, int>(6, 2);
                //var tuple5 = new Tuple<int, int>(2, 10);

                //var tuple6 = new Tuple<int, int>(1, 7);
                //var tuple7 = new Tuple<int, int>(10, 8);

                //var tuple8 = new Tuple<int, int>(6, 4);

                //var tuple9 = new Tuple<int, int>(9, 4);//
                //var tuple10 = new Tuple<int, int>(7, 9);

                //tarjan2
                var tuple1 = new Tuple<int, int>(1, 2);
                var tuple2 = new Tuple<int, int>(3, 4);

                var tuple3 = new Tuple<int, int>(2, 5);

                var tuple4 = new Tuple<int, int>(8, 7);
                var tuple5 = new Tuple<int, int>(2, 8);

                List<Tuple<int, int>> list = new List<Tuple<int, int>>();

                list.Add(tuple1);
                list.Add(tuple2);
                list.Add(tuple3);
                list.Add(tuple4);
                list.Add(tuple5);

                //list.Add(tuple6);
                //list.Add(tuple7);
                //list.Add(tuple8);
                //list.Add(tuple9);
                //list.Add(tuple10);

                Console.WriteLine();
                Tarjan tarjan = new Tarjan(graph);
                tarjan.FindNearestCommonAncestor(list);

            }

            //Bridges and articulation points  
            if (false)
            {
                Graph graph = new Graph(@"D:\dokumenty\Studia Infa Stosowana\semestr 2\ALGOR2\Algorithms\bridges.txt",false);
                //graph.PrintGraph();

                Console.WriteLine("Vertex neighbours list: ");
                foreach (var node in graph.vertices)
                    node.PrintNeighbours();

                BridgesAndArticulationPoints alg = new BridgesAndArticulationPoints(graph);
                alg.FindBridges();

                Graph graph2 = new Graph(@"D:\dokumenty\Studia Infa Stosowana\semestr 2\ALGOR2\Algorithms\ArticulationPoints.txt",false);

                //graph2.PrintGraph();

                Console.WriteLine("Vertex neighbours list: ");
                foreach (var node in graph2.vertices)
                    node.PrintNeighbours();


                BridgesAndArticulationPoints alg2 = new BridgesAndArticulationPoints(graph2);
                alg2.FindArticulationPoints();
            }
            //2CNF
            if (false)  
            {
                Graph graph = new Graph(@"D:\dokumenty\Studia Infa Stosowana\semestr 2\ALGOR2\Algorithms\2CNF3.txt");
                graph.PrintLogicalFormula();
                graph.PrintGraph();

                Console.WriteLine("Vertex neighbours list: ");
                foreach (var node in graph.vertices)
                    node.PrintNeighbours();

                Console.WriteLine("2cnf Vertieces neighbours list: ");
                foreach (var node in graph._2cnfVertieces)
                    node.PrintNeighbours();

                TwoCNF alg = new(graph);

                if (alg.Algorithm2CNF())
                {
                    Console.WriteLine("The given expression is satisfiable.");
                    alg.Print2CNF();
                    alg.CheckLogicFormula();
                }
                else
                    Console.WriteLine("The given expression is unsatisfiable.");
            }
            //Maximum Flow Problem
            if (false) 
            {
                Graph graph = new(@"D:\dokumenty\Studia Infa Stosowana\semestr 2\ALGOR2\Algorithms\max_flow.txt",true);
                Graph rGraph = new(@"D:\dokumenty\Studia Infa Stosowana\semestr 2\ALGOR2\Algorithms\max_flow.txt", false,2);


                MaximumFlowProblem alg = new MaximumFlowProblem(graph, rGraph);

                rGraph.PrintGraph();

                Console.WriteLine("Vertieces neighbours list: ");
                foreach (var node in graph.vertices)
                    node.PrintNeighbours();

                Console.WriteLine("The maximum possible flow is "
                          + alg.fordFulkerson(0, 5));

            }

            //PreFlow Problem
            if (true)
            {
               // Graph graph = new Graph(@"D:\dokumenty\Studia Infa Stosowana\semestr 2\ALGOR2\Algorithms\max_flow.txt", true);
                Graph rGraph = new(@"D:\dokumenty\Studia Infa Stosowana\semestr 2\ALGOR2\Algorithms\Data Files\max_flow.txt", false, 2);

                PreFlow alg = new PreFlow(rGraph);

                rGraph.PrintGraph();

                alg.GenericPreFlow(0, 5);
            }

            //KMP algorithm 
            if (false)
            {
                string txt = "ABABDABACDABABCABAB";
                string pat = "ABABCABAB";

                string txt2 = "ababcabababc";
                string pat2 = "abc";

                string txt3 = "Ala ma kota. Ala kota ma. Ma kota Ala. Każda Ala chce kota.";
                string pat3 = "Ala";

                KMP alg = new();
                alg.MatcherKMP(pat, txt);
                alg.MatcherKMP(pat2, txt2);
                alg.MatcherKMP(pat3, txt3);
            }
        }
    }
}