using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_3_OOP.Classes
{
    internal class Initial
    {
        public static void Initialize()
        {
            InitializePassengers();
            InitializeAirplanes();
            InitializeMembers();
            InitializeAircrews();
            InitializeFlights();
        }

        private static void InitializePassengers()
        {
            Passenger.Passengers.Add(new Passenger("Duje", "Nikolic Malora", new DateOnly(2000, 12, 16), "duje@gmail.com", "Duje1234"));
            Passenger.Passengers.Add(new Passenger("Josko", "Diko", new DateOnly(2000, 11, 20), "josko@gmail.com", "Josko1234"));
        }


        private static void InitializeFlights()
        {
            Flight.Flights.Add(new Flight("LH256", new DateTime(2026, 11, 19, 14, 30, 0), new DateTime(2026, 11, 19, 18, 45, 0), 1200, Airplane.Airplanes[0], Aircrew.Aircrews[0]));
            Flight.Flights.Add(new Flight("AA100", new DateTime(2026, 11, 20, 9, 0, 0), new DateTime(2026, 11, 20, 11, 30, 0), 800, Airplane.Airplanes[1], Aircrew.Aircrews[1]));
        }

        private static void InitializeAirplanes()
        {
            Airplane.Airplanes.Add(new Airplane("Boeing 737", new DateOnly(2015, 6, 12), 1200, 50));
            Airplane.Airplanes.Add(new Airplane("Boeing 737", new DateOnly(2012, 3, 6), 1200, 50));
            Airplane.Airplanes.Add(new Airplane("Airbus A320", new DateOnly(2018, 3, 25), 950, 20));
            Airplane.Airplanes.Add(new Airplane("Embraer E195", new DateOnly(2020, 11, 5), 600, 5));
        }

        private static void InitializeMembers()
        {
            Member.Members.Add(new Member("Marko", "Kovacevic", new DateOnly(1980, 3, 12), Enums.Genders.Male, Enums.Roles.Pilot));
            Member.Members.Add(new Member("Luka", "Marinkovic", new DateOnly(1989, 11, 5), Enums.Genders.Male, Enums.Roles.Copilot));
            Member.Members.Add(new Member("Ana", "Babic", new DateOnly(1995, 9, 2), Enums.Genders.Female, Enums.Roles.Attendant));
            Member.Members.Add(new Member("Mia", "Saric", new DateOnly(1997, 6, 23), Enums.Genders.Female, Enums.Roles.Attendant));
            Member.Members.Add(new Member("Ivan", "Radic", new DateOnly(1978, 7, 27), Enums.Genders.Male, Enums.Roles.Pilot));
            Member.Members.Add(new Member("Petar", "Juric", new DateOnly(1991, 4, 18), Enums.Genders.Male, Enums.Roles.Copilot));
            Member.Members.Add(new Member("Toni", "Blazevic", new DateOnly(1994, 9, 30), Enums.Genders.Male, Enums.Roles.Attendant));
            Member.Members.Add(new Member("Sara", "Novak", new DateOnly(1998, 12, 14), Enums.Genders.Female, Enums.Roles.Attendant));
            Member.Members.Add(new Member("Tomislav", "Perkovic", new DateOnly(1982, 2, 14), Enums.Genders.Male, Enums.Roles.Pilot));
            Member.Members.Add(new Member("Karlo", "Mikic", new DateOnly(1990, 8, 9), Enums.Genders.Male, Enums.Roles.Copilot));
            Member.Members.Add(new Member("Ivana", "Sostaric", new DateOnly(1996, 1, 27), Enums.Genders.Female, Enums.Roles.Attendant));
            Member.Members.Add(new Member("Elena", "Vucetic", new DateOnly(1999, 5, 11), Enums.Genders.Female, Enums.Roles.Attendant));
        }

        private static void InitializeAircrews()
        {
            Aircrew.Aircrews.Add(new Aircrew("Alpha Crew")
            {
                Members =
                    {
                        Member.Members[0],
                        Member.Members[1],
                        Member.Members[2],
                        Member.Members[3]
                    }
            }
            );

            Aircrew.Aircrews.Add(new Aircrew("Bravo Crew")
            {
                Members =
                    {
                        Member.Members[4],
                        Member.Members[5],
                        Member.Members[6],
                        Member.Members[7]
                    }
            }
            );

            Aircrew.Aircrews.Add(new Aircrew("Charlie Crew")
            {
                Members =
                    {
                        Member.Members[8],
                        Member.Members[9],
                        Member.Members[10],
                        Member.Members[11]
                    }
            }
            );
        }
    }
}
