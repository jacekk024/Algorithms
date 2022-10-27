using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Exercise2
{
    internal class Knight
    {
        private int n;
        private int size;
        private int[,] chessBoard;
        private int[] a;
        private int[] b;
        private bool q;
        private Stopwatch watch = new Stopwatch();


        public Knight(int n)
        {
            size = n*n;
            this.n = n;
            chessBoard = new int[n, n];
            a = new int[] { 2, 1, -1, -2, -2, -1, 1, 2 }; 
            b = new int[] { 1, 2, 2, 1, -1, -2, -2, -1 };
        }

        public void PrintTour() 
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    Console.Write(chessBoard[i, j] + "  ");
                Console.WriteLine("\n");
            }
        }

        public void StartKnightTour()
        {
            chessBoard[0, 0] = 1;
            q = false;
            TryNextMove(2, 0, 0,ref q);

            if (q)
                PrintTour();
            else
                Console.WriteLine("No solutions!");
        }


        public void TryNextMove(int i, int x, int y,ref bool q) // dlaczego to ma być tablica??
        {
            int u, v;

            for (int k = 0; k < 8 && !q; k++)
            {               
                u = x + a[k];
                v = y + b[k]; // przemieszczanie sie konika po planszy wektor a i b

                if ((u >= 0 && u < n) && (v >= 0 && v < n) && (chessBoard[u, v] == 0))
                {
                    chessBoard[u, v] = i; // postawienie konika szachowego na wybranym polu
                    if (i < size)
                    {
                        TryNextMove(i + 1, u, v, ref q);
                        if (!q)
                            chessBoard[u, v] = 0; // cofniecie ruchu konika szachowego
                    }
                    else q = true;
                }

            }
        }
    }
}
