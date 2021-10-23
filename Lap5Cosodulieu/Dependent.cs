using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lap5Cosodulieu
{
    public class Dependent
    {

        public string Name { get; set; }
        public char Sex { get; set; }
        public string BirthDate
        { get; set; }
        public string Relationship
        { get; set; }// relationships
        public Employee DependentOf { get; set; }
    
    
}
}
