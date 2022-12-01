using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Exercise4
{

    internal class HashTable
    {
 
        private double alfa = (Math.Sqrt(5) - 1) / 2;






        //hash key is int
        public int HashFunction() 
        {



                return 1;          
        }

        int HashFunction(string input)
        {
            char[] ch;
            ch = input.ToCharArray();

            int i, sum;
            for ( sum = 0, i = 0; i < input.Length; i++)
                sum += ch[i];
            return sum % input.Length;
        }

        int HashFunction(int[] input) 
        {
            int i, sum;
            for (sum = 0, i = 0; i < input.Length; i++)
                sum += input[i];
            return sum % input.Length;
        }



        

        public void HashInsert() 
        {
           

        }

        public int HashSearch() 
        {

  

            return 1;        
        }

        public void HashDelete()
        {


        }
    }
}
