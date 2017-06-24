using GymPal.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymPal.Core.Data
{
    public class Repository
    {
        private static List<Routine> Routines = new List<Routine>()
        {
            new Routine()
            {
                 Name = "group1",
                 id = 1,
                 userid = 2,
                 Machines = new  List<Machine>(){

                        new Machine()
                        {
                             machineid = 1,
                              Name = "machine1",
                              PictureUrl="IMG_1039",
                               BeginDesc = "start nn",
                               shortDesc = "blshb blsh" 

                        },
                        new Machine()
                        {
                             machineid = 2,
                              Name = "machine2",
                              PictureUrl="john",
                               BeginDesc = "start nn",
                               shortDesc = "blshb blsh"

                        },
                        new Machine()
                        {
                             machineid = 3,
                              Name = "machine3",
                              PictureUrl="john",
                               BeginDesc = "start nn",
                               shortDesc = "blshb blsh"

                        }
                 }
            }
        };
        public List<Routine> GetRoutines()
        {
            return Routines;
        }
        public List<Machine> GetAllMachines()
        {
            IEnumerable<Machine> machines =
                from Routine in Routines
                from machine in Routine.Machines

                select machine;
            return machines.ToList<Machine>();
        }
    }
}
