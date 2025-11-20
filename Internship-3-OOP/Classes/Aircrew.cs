using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_3_OOP.Classes
{
    internal class Aircrew
    {
        public string Name { get; set; }
        public List<Member> Members = new List<Member>();
        public static List<Aircrew> Aircrews = new List<Aircrew>();

        public Aircrew(string name) 
        {
            Name = name;
        }
    }
}
