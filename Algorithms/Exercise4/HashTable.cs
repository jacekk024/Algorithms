using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Exercise4
{
    internal class HashTable
    {

        int h(string x, int M)
        {
            char[] ch;
            ch = x.ToCharArray();
            int xlength = x.Length;

            int i, sum;
            for (sum = 0, i = 0; i < x.Length; i++)
                sum += ch[i];
            return sum % M;
        }
    }
}
