using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_3_OOP.Classes
{
    internal class Reservation
    {
        public Passenger Passenger { get; set; }
        public Flight Flight { get; set; }
        public Enums.Classes Category { get; set; }
        public static List<Reservation> Reservations = new List<Reservation>();

        public Reservation(Passenger passenger, Flight flight, Enums.Classes category)
        {
            Passenger = passenger;
            Flight = flight;
            Category = category;
        }
    }
}
