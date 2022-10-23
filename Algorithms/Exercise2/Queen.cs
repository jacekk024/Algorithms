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
        private int boardSize;
        private int N;

        private int[] x = new int[8]; // pozycja w i-tej kolumnie
        private bool[] a = new bool[8]; //  brak hetmana w j−tym wierszu  
        private bool[] b = new bool[15]; // brak hetmana na k−tej przekątnej
        private bool[] c = new bool[15]; //  brak hetmana na k−tej przekątnej 


        public Queen(int N) 
        {
            this.N = N;
            boardSize = N * N;
            
            for(int i = 0; i < N; i++)
                a[i] = true;
            for (int j = 0; j < 15; j++) {
                b[j] = true;
                c[j] = true;
            }

        }

        void PrintQueenPosition() 
        {

            for (int i = 0; i < N; i++)
            {
                Console.WriteLine(x[i]);
            }

            //for (int i = 0; i < N; i++)
            //{
            //    for (int j = 0; j < N; j++)
            //        Console.Write(chessBoard[i,j]);
            //    Console.WriteLine();
            //}
        
        }

        public void StartSetQueen()
        {
            bool q = false;
            Try8Queen(1, q);
            PrintQueenPosition();
        }


        public void Try8Queen(int i,bool q) 
        {
            int j;

            j = -1;
            do
            {
                j = j + 1; 
                q = false;
                 if (a[j] && b[i+j] && c[i-j + 7])
                 {
                     x[i] = j;
                     a[j] = false; b[i + j] = false; c[i-j + 7] = false;
                     if (i < 7)
                     {
                        Try8Queen(i + 1, q);
                         if (!q) {
                            a[j] = true;
                            b[i + j] = true;
                            c[i-j + 7] = true;
                            }
                     } else q = true;
                 }
            } while (!q && (j != 7));
        }
    }
}
