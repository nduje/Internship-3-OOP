using Internship_3_OOP.Classes;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Internship_3_OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Helper.Initialize();
            Console.WriteLine("APLIKACIJA ZA UPRAVLJANJE AERODROMOM");
            Menu.ChooseFromMainMenu();
        }
    }
}
