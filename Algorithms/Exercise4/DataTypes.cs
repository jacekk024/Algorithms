using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Exercise4
{
    class Person 
    {
        private string Name { get;}
        private string LastName { get;}

        private int Age { get; }

        private string[] ParentNames { get;}

        private int[] Id { get;}   

        public Person(string name, string lastName,int age, string[] paretsName, int[] id) 
        {
            Name = name;
            LastName = lastName;    
            Age = age;
            paretsName.CopyTo(ParentNames,0);
            id.CopyTo(Id,0);
        }
    }
}
