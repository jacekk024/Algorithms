using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Exercise3
{
    internal class HeuristicQueen
    {
        private Stopwatch watch = new Stopwatch();
        private int[,] chessBoard;
        private int N;
        private int[] column; // pozycja w i-tej kolumnie

    
        private void PrintQueenPosition()
        {
            for (int i = 0, j = 1; i < N; j++, i++)
            {
                chessBoard[i, column[i]] = j;
            }

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                    Console.Write(chessBoard[i, j] + " ");
                Console.WriteLine();
            }
        }

        private void PrintQueenTime() 
        {
            Console.WriteLine($"Time elapsed: {watch.ElapsedMilliseconds} ms for {N} elements");
            watch.Restart();
        }

        //permution ensure no conflicts on rows and columns
        private void Permutation() 
        {
            column = Enumerable.Repeat(-1, N).ToArray();//fill array with -1
            int tmp;
            int ind = 0;
            Random rnd = new Random();
            while(ind < N) 
            {
                tmp = rnd.Next(0,N);
                
                if (!column.Contains(tmp)) // if x doesn`t contains tmp save this value
                {
                    column[ind] = tmp;
                    ind++;
                }
            }
        }

        private bool IsAttacked(int pos)
        {

            for(int i = 0; i < N; i++) 
            {
                if (i != pos)
                {
                    if (i + column[i] == pos + column[pos] || i - column[i] == pos - column[pos])
                        return true;
                }
            }
            return false;
        }

        private void SwapQueen(int i, int j) 
        {
            int iQueen = column[i];
            int jQueen = column[j];
            column[i] = jQueen;
            column[j] = iQueen;
        }
        private bool CheckReductionOfCollisions(int i, int j) 
        {
           int countOldConf = CollisionNumber();

           SwapQueen(i, j);

           int countNewConf = CollisionNumber();

           SwapQueen(i, j);

           return countNewConf < countOldConf;
        }

        private int CollisionNumber() 
        {
            int countConflicts = 0;
            for(int i = 0; i < N;i++)
            {
                    if(IsAttacked(i))
                        countConflicts++;
            }
            return countConflicts;
        }

        private void QueenSearch() 
        {
            int swapsPerformed = 0;

            while (CollisionNumber() != 0) // when there is no collisions stops 
            {
                Permutation();
                do
                {
                    for (int i = 0; i < N; i++)
                    {
                        for (int j = i + 1; j < N; j++)
                        {
                            if (IsAttacked(i) || IsAttacked(j))
                            {
                                if (CheckReductionOfCollisions(i, j))
                                {
                                    SwapQueen(i, j);
                                    swapsPerformed++;
                                }
                            }
                        }
                    }
                } while (swapsPerformed == 0);
            }
        }

        public void StartSetQueen(int lenght, bool option)
        {
            N = lenght;
            chessBoard = new int[N, N];
          
            Permutation();
            watch.Start();
            QueenSearch();
            watch.Stop();

            if (option)
                PrintQueenPosition();
            else
                PrintQueenTime();    
        }
    }
}
