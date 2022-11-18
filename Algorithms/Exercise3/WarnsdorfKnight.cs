using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Exercise3
{
    internal class WarnsdorfKnight
    {
        private int n;
        private int size;
        private int[,] chessBoard;
        private readonly int[] a = { 2, 1, -1, -2, -2, -1, 1, 2 };
        private readonly int[] b = { 1, 2, 2, 1, -1, -2, -2, -1 };
        private readonly Stopwatch watch = new();

        public void PrintTour()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    Console.Write(chessBoard[i, j] + "  ");
                Console.WriteLine("\n");
            }
            Console.WriteLine("Time elapsed: " + watch.ElapsedMilliseconds + "ms");
            watch.Restart();

        }

        public void PrintTourNoTime()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    Console.Write(chessBoard[i, j] + "  ");
                Console.WriteLine("\n");
            }
            Console.WriteLine("\n");
        }

        public void PrintTourTime()
        {
            Console.WriteLine($"Time elapsed for n = {n} : {watch.ElapsedMilliseconds} ms");
            watch.Restart();
        }

        public void StartKnightTour(int n)
        {
            size = n * n;
            this.n = n;
            chessBoard = new int[n, n];

            bool q = false;

            watch.Start();
            Warnsdorff(1, 15, 16, ref q);
            watch.Stop();

            if (q)
                PrintTour();     
            else
                Console.WriteLine("No solutions!");
        }

        private bool CheckLimits(int x, int y) 
        {
            return ((x >= 0 && y >= 0) && (x < n && y < n) && (chessBoard[x,y]==0));
        }

        private int CheckDegree(int x, int y) 
        {
            // minimalny ilosc ruchow ustawiona na 9  - mozliwych 8 + 1, obecny wynik
            int minInd = 9, currInd; 
            int indexMin = 0; // indeks minimalnego ruchu
            int nextX, nextY; // kolejne pozycje 

            for (int i = 0; i < 8; i++)
            {
                currInd = 0;
                nextX = x + a[i];
                nextY = y + b[i];
                if (CheckLimits(nextX,nextY))
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (CheckLimits(nextX + a[j], nextY + b[j]))
                            currInd++;
                    }
                    if (currInd < minInd)
                    {
                        minInd = currInd;
                        indexMin = i;
                    }
                }
            }
            return indexMin;
        }


        public void Warnsdorff(int i, int x, int y, ref bool q)
        {
            int u, v,ind;
            chessBoard[x, y] = i;// postawienie konika szachowego na polu (x,y)

            if (i < size)
            {
                ind = CheckDegree(x, y); // dobranie indeksu skoku o najnizszym koszcie 

                u = x + a[ind];
                v = y + b[ind]; // przemieszczanie sie konika po planszy 

                do
                {
                    Warnsdorff(i + 1, u, v, ref q);
                    if (!q)
                        chessBoard[u, v] = 0; // cofniecie ruchu konika szachowego
                }
                while (!q && CheckLimits(u, v));// dopoki nie ma rozwiazania i ruch mozliwy                      
            }
            else
                q = true; // otrzymalismy prawidlowe ulozenie konika
        }
    }
}
