using System;
using System.Collections.Generic;
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




        public Knight(int n)
        {
            size = n*n;
            this.n = n;
            chessBoard = new int[n, n];
            chessBoard[1, 1] = 1;
            a = new int[] { 2, 1, -1, -2, -2, -1, 1, 2 };
            b = new int[] { 1, 2, 2, 1, -1, -2, -2, -1 };

        }

        public void PrintTour() 
        {
            for (int l = 0; l < n; l++)
            {
                for (int g = 0; g < n; g++)
                    Console.Write(chessBoard[l, g]);
                Console.WriteLine();
            }
        }

        public void TryNextMove(int i, int x, int y, bool[] q) 
        {
            int u, v,k;
            k = 0;
            do
            {
                k = k + 1;
                u = x + a[k];
                v = y + b[k]; // przemieszczanie sie konika po planszy wektor a i b
                if (((u >= 0) && (u < n)) && ((v >= 0) && (v < n)) && (chessBoard[u, v] == 0))
                {
                    chessBoard[u,v] = i; // postawienie konika szachowego na wybranym polu
                    if (i < size)
                    {
                        size--;
                        TryNextMove( i++,  x,  y, q);
                        if (!q[i])
                        {
                            chessBoard[u, v] = 0; // cofniecie ruchu konika szachowego 
                            size++;
                        }
                    }
                    else q[i] = true;
                }
            } while (!q[i] && size > 0);

        }
    }
}
