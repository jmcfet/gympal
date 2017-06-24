using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymPal.Core.Models
{
    public class Routine
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int? userid { get; set; }
        public int? cloned { get; set; }
        //      [JsonIgnore]
        public ICollection<Machine> Machines { get; set; }
    }
}
