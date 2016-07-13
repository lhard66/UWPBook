using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPBook
{
    public class Person
    {        
        public string Name { get; set; }
        public int Age { get; set; }
        public bool Sex { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
