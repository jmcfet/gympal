using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymPal.Core.Models
{
    public class Machine
    {
        public int machineid { get; set; }
        public string Name { get; set; }
        public string PictureUrl { get; set; }
        public string Video { get; set; }
        public string shortDesc { get; set; }
        public string EntryDesc { get; set; }
        public string BeginDesc { get; set; }
        public string ExitDesc { get; set; }
        public string FormDesc { get; set; }

        //public ICollection<MachineAttr> attributes { get; set; }
        //[JsonIgnore]
        //public ICollection<Routine> routines { get; set; }
        //[JsonIgnore]
        //public ICollection<MuscleGroups> groups { get; set; }
    }
}
