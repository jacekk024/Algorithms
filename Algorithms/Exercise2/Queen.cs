﻿using System;
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
            x= new int[N]; //pozycja hetmana w i-tej kolumnie
            a= new bool[N]; // brak hetmana w j-tym wierszu
            b= new bool[2*N-1]; // brak hetmana na k-tej przekatnej
            c= new bool[2*N-1]; // brak hetmana na k-tej przekatnej


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
            Console.WriteLine();

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                    Console.Write(chessBoard[i, j] + " ");
                Console.WriteLine();
            }
            Console.WriteLine("Time elapsed: "+ watch.ElapsedMilliseconds + "ms");

        }

        public void StartSetQueen()
        {
            bool q = false;
            watch.Start();
            TryNQueen(1,ref q);
            watch.Stop();
            PrintQueenPosition();
        }


        public void TryNQueen(int i,ref bool q) 
        {
             int j = -1;

             do
             {
                j = j + 1; // zaczynamy od j =0 
                q = false;
                if (a[j] && b[i + j] && c[i - j + n])
                {
                    x[i] = j;
                    a[j] = false;
                    b[i + j] = false;
                    c[i - j + n] = false;
                    if (i < n)
                    {
                        TryNQueen(i + 1, ref q);
                        if (!q)
                        {
                            a[j] = true;
                            b[i + j] = true;
                            c[i - j + n] = true;
                        }
                    }
                    else q = true;
                }        
             } while (!q && (j != n));
        }
    }
}
