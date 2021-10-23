using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lap5Cosodulieu
{
    public class Project
    {
        public int PNumber { get; set; }
    public string PName { get; set; }
public string Location
{ get; set; }// relationships
        public Department ControlledBy { get; set; }
        public List<WorksOn> WorksOn { get; set; }
    }
}
