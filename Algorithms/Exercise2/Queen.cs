using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Exercise2
{
    internal class Queen
    {
        private Stopwatch watch = new Stopwatch();
        private int[,] chessBoard;
        private int N;

        private int[] x; // pozycja w i-tej kolumnie
        private bool[] a; //  brak hetmana w j−tym wierszu  
        private bool[] b; // brak hetmana na k−tej przekątnej
        private bool[] c; //  brak hetmana na k−tej przekątnej 

        private int n;


        public Queen(int N) 
        {
            this.N = N;
            chessBoard = new int[N, N];

            n = N - 1;

            x= new int[N];
            a= new bool[N]; 
            b= new bool[2*N-1];
            c= new bool[2 *N-1];


            for (int i = 0; i < N; i++)
                a[i] = true;
            for (int j = 0; j < 2*N-1; j++) {
                b[j] = true;
                c[j] = true;
            }

        }

        void PrintQueenPosition() 
        {

            for (int i = 0, j = 1; i < N; j++, i++)
            {
                chessBoard[i, x[i]] = j;
            }

            for (int i = 0; i < N; i++)
                Console.Write(x[i]+1 + " ");
            Console.WriteLine();


            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                    Console.Write(chessBoard[i, j] + "");
                Console.WriteLine();
            }

        }

        public void StartSetQueen()
        {
            bool q = false;
            TryNQueen(0,ref q);
            PrintQueenPosition();
        }


        public void TryNQueen(int i,ref bool q) 
        {
            int j = -1;

          //  j = -1;
            do
            {
                j = j + 1; 
                q = false;
                 if (a[j] && b[i+j] && c[i-j + n])
                 {
                     x[i] = j;

                     a[j] = false;
                     b[i + j] = false;
                     c[i-j + n] = false;
                     if (i < n)
                     {
                        TryNQueen(i + 1,ref q);
                         if (!q) {
                            a[j] = true;
                            b[i+j] = true;
                            c[i-j+n] = true;
                         }
                     } 
                     else q = true;
                 }
            } while (!q && (j != n));
        }
    }
}
