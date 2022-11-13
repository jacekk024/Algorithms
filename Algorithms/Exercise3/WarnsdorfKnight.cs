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
        }

        public void StartKnightTour(int n)
        {
            size = n * n;
            this.n = n;
            chessBoard = new int[n, n];

            chessBoard[0, 0] = 1;
            bool q = false;


            watch.Start();
            TryNextMove(2, 0, 0, ref q);
            watch.Stop();

            if (q)
                PrintTourTime();     
            else
                Console.WriteLine("No solutions!");
        }

        private bool CheckLimits(int x, int y) 
        {

            return (x >= 0 && x < n) && (y >= 0 && y < n) && (chessBoard[x, y] == 0);
        }


        private int CheckDegree(int x, int y) 
        {
            int minInd = 0, Ind = 0;
            int indexMin = 0;



            // pierwsza opcja zliczanie jej mozliwosci ruchu
            // przejscie do kolejnej opcji zliczanie ruchow
            // i tak n mozliwych ruchow

            int nextX, nextY;

            for (int i = 0; i < 8; i++)
            {
                nextX = x + a[i];
                nextY = y + b[i];

                for (int j = 0; j < 8; j++)
                    if (CheckLimits(nextX + a[j], nextY + b[j]))
                    {
                        Ind++;
                    }
                if()
                if ((x + a[i] >= 0 && x + a[i] < n) && (y + b[i] >= 0 && y + b[i] < n)) // sprawdzenie dostepnych pozycji
                    count++; //zliczenie dostepnych pozycji 

            }
            return count;
        }


        public void TryNextMove(int i, int x, int y, ref bool q)
        {
            int u, v;

            for (int k = 0; k < 8 && !q; k++)
            {

                // uszereguj  wolne sasiednie pola dla x i y wg liczby ich wolnych sasiadow

                u = x + a[k];
                v = y + b[k]; // przemieszczanie sie konika po planszy wektor a i b

                if (CheckLimits(u,v))
                {
                    chessBoard[u, v] = i; // postawienie konika szachowego na wybranym polu
                   

                    if (i < size)
                    {
                        TryNextMove(i + 1, u, v, ref q);
                        if (!q)
                            chessBoard[u, v] = 0; // cofniecie ruchu konika szachowego
                    }
                    else
                        q = true;
                }
            }
        }
    }
}
