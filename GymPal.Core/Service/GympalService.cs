using GymPal.Core.Data;
using GymPal.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymPal.Core.Service
{
    public class GympalService
    {
        public static Repository myRepo = new Repository();
        public List<Machine> GetAllMachines()
        {
            return myRepo.GetAllMachines();
        }
    } 
}
