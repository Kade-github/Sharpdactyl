using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpdactyl.Models.Client
{
    public class Memory
    {
        public int Current { get; set; }
        public int Limit { get; set; }
    }

    public class Cpu
    {
        public double Current { get; set; }
        public List<double> Cores { get; set; }
        public int Limit { get; set; }
    }

    public class Disk
    {
        public int Current { get; set; }
        public int Limit { get; set; }
    }

    public class UAttributes
    {
        public string State { get; set; }
        public Memory Memory { get; set; }
        public Cpu Cpu { get; set; }
        public Disk Disk { get; set; }
    }

    public class ServerUtil
    {
        public UAttributes Attributes { get; set; }
    }
}
