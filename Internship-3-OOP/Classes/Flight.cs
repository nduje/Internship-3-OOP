namespace Internship_3_OOP.Classes
{
    internal class Flight
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public double Distance { get; set; }
        public TimeSpan Duration { get; set; }
        public static List<Flight> Flights = new List<Flight>();
        public Airplane Airplane { get; set; }
        public Aircrew Aircrew { get; set; }
        public List<Passenger> Passengers { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastUpdated { get; set; }

        public Flight(string number, DateTime departureTime, DateTime arrivalTime, double distance, Airplane airplane, Aircrew aircrew)
        {
            Id = Guid.NewGuid();
            Number = number;
            DepartureTime = departureTime;
            ArrivalTime = arrivalTime;
            Distance = distance;
            Duration = CalculateDuration();
            Airplane = airplane;
            Aircrew = aircrew;
            Passengers = new List<Passenger>();
            Created = DateTime.Now;
            LastUpdated = DateTime.Now;
        }

        private TimeSpan CalculateDuration()
        {
            return ArrivalTime - DepartureTime;
        }

        public static void ShowFlights()
        {
            Console.WriteLine("\n{0, -42} {1, -8} {2, -24} {3, -24} {4, -16} {5, -24} {6, -16} {7}", "ID", "Naziv", "Datum polaska", "Datum dolaska", "Udaljenost", "Vrijeme putovanja", "Avion", "Posada");

            foreach (var flight in Flights)
            {
                Console.WriteLine("{0, -42} {1, -8} {2, -24} {3, -24} {4, -16:F2} {5, -24} {6, -16} {7}", flight.Id, flight.Number, flight.DepartureTime, flight.ArrivalTime, (flight.Distance + "km"), (flight.Duration.Hours + "h " + flight.Duration.Minutes + "min"), flight.Airplane.Name, flight.Aircrew.Name);
            }

            Helper.PendingUser();
        }

        public static void CreateNewFlight()
        {
            Console.WriteLine("\nDODAVANJE NOVOG LETA\n");

            string number = Helper.ValidateFlightNumber();
            DateTime departure_time = Helper.ValidateDateTime("polaska");
            DateTime arrival_time = Helper.ValidateDateTime("dolaska");

            if (departure_time > arrival_time)
            {
                Console.WriteLine("Vrijeme dolaska ne moze biti prije vremena polaska\nProces dodavanja leta je prekinut");
                Helper.PendingUser();
                return;
            }

            double distance = Helper.ValidateDistance();

            Airplane? airplane = Helper.ValidateAirplane();
            if (airplane == null) { Helper.UnavailableCrewMessage(); return; }

            Aircrew? aircrew = Helper.ValidateAircrew();
            if (aircrew == null) { Helper.UnavailableCrewMessage(); return; }

            AddNewFlight(number, departure_time, arrival_time, distance, airplane, aircrew);
        }

        public static void AddNewFlight(string number, DateTime departure_time, DateTime arrival_time, double distance, Airplane airplane, Aircrew aircrew)
        {
            Console.Write("\nZelite li dovrsiti proces dodavanja leta broj {0}? (DA/NE) ", number);

            if (Helper.CheckInput())
            {
                Flights.Add(new Flight(number, departure_time, arrival_time, distance, airplane, aircrew));
                Console.WriteLine("Proces dodavanja leta broj {0} je dovrsen", number);
            }

            else
            {
                Console.WriteLine("Proces dodavanja leta broj {0} je prekinut", number);
            }

            Helper.PendingUser();

            return;
        }

        public static void SearchFlightById()
        {
            Console.WriteLine("\nPRETRAŽIVANJE LETA PO IDENTIFIKATORU\n");

            while (true)
            {
                Console.Write("Odaberite let (unesite ID ili ostavite prazno za prekid): ");

                string? input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Proces pretraživanja je prekinut");
                    Helper.PendingUser();
                    return;
                }

                if (!Guid.TryParse(input, out Guid id))
                {
                    Console.WriteLine("Unos nije valjan\n");
                    continue;
                }

                Flight? flight = Flights.Find(a => a.Id == id);

                if (flight == null)
                {

                    Console.WriteLine("\nLet s identifikatorom {0} ne postoji", id);
                    Helper.PendingUser();
                    return;
                }

                Console.WriteLine("\n{0, -42} {1, -8} {2, -24} {3, -24} {4, -16} {5, -24} {6, -16} {7}", "ID", "Naziv", "Datum polaska", "Datum dolaska", "Udaljenost", "Vrijeme putovanja", "Avion", "Posada");
                Console.WriteLine("{0, -42} {1, -8} {2, -24} {3, -24} {4, -16:F2} {5, -24} {6, -16} {7}", flight.Id, flight.Number, flight.DepartureTime, flight.ArrivalTime, (flight.Distance + "km"), (flight.Duration.Hours + "h " + flight.Duration.Minutes + "min"), flight.Airplane.Name, flight.Aircrew.Name);

                Helper.PendingUser();

                return;
            }
        }

        public static void SearchFlightByName()
        {
            Console.WriteLine("\nPRETRAŽIVANJE LETA PO NAZIVU\n");

            while (true)
            {
                Console.Write("Odaberite let(ove) (unesite puni naziv ili ostavite prazno za prekid): ");

                string? number = Console.ReadLine();

                if (string.IsNullOrEmpty(number))
                {
                    Console.WriteLine("Proces pretraživanja je prekinut");
                    Helper.PendingUser();
                    return;
                }

                if (!Helper.IsFlightNumberValid(number))
                {
                    Console.WriteLine("Unos nije valjan");
                    continue;
                }

                List<Flight> flights = Flights.Where(a => a.Number == number).ToList();

                if (flights.Count == 0)
                {
                    Console.WriteLine("\nLet s nazivom {0} ne postoji", number);
                    Helper.PendingUser();
                    return;
                }

                Console.WriteLine("\n{0, -42} {1, -8} {2, -24} {3, -24} {4, -16} {5, -24} {6, -16} {7}", "ID", "Naziv", "Datum polaska", "Datum dolaska", "Udaljenost", "Vrijeme putovanja", "Avion", "Posada");

                foreach (var flight in flights)
                {
                    Console.WriteLine("{0, -42} {1, -8} {2, -24} {3, -24} {4, -16:F2} {5, -24} {6, -16} {7}", flight.Id, flight.Number, flight.DepartureTime, flight.ArrivalTime, (flight.Distance + "km"), (flight.Duration.Hours + "h " + flight.Duration.Minutes + "min"), flight.Airplane.Name, flight.Aircrew.Name);
                }

                Console.WriteLine("");

                Helper.PendingUser();

                return;
            }
        }

        public static void EditFlight()
        {
            Console.WriteLine("\nUREĐIVANJE POSTOJEĆEG LETA\n");

            while (true)
            {
                Console.Write("Odaberite let (unesite ID ili ostavite prazno za prekid): ");

                string? input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Proces uređivanja je prekinut");
                    Helper.PendingUser();
                    return;
                }

                if (!Guid.TryParse(input, out Guid id))
                {
                    Console.WriteLine("Unos nije valjan\n");
                    continue;
                }

                Flight? flight = Flights.Find(a => a.Id == id);

                if (flight == null)
                {
                    Console.WriteLine("Let s identifikatorom {0} ne postoji", id);
                    Helper.PendingUser();
                    return;
                }

                DateTime departure_time, arrival_time;
                Aircrew? aircrew;

                Console.Write("\nŽelite li promijeniti datum i vrijeme polaska? (DA/NE) ");

                if (Helper.CheckInput())
                {
                    departure_time = Helper.ValidateDateTime("polaska");
                }

                else { departure_time = flight.DepartureTime; }

                Console.Write("Želite li promijeniti datum i vrijeme dolaska? (DA/NE) ");

                if (Helper.CheckInput())
                {
                    arrival_time = Helper.ValidateDateTime("dolaska");
                }

                else { arrival_time = flight.ArrivalTime; }

                Console.Write("Želite li promijeniti posadu? (DA/NE) ");

                if (Helper.CheckInput())
                {
                    aircrew = Helper.ValidateAircrew();
                }

                else { aircrew = flight.Aircrew; }

                if ((departure_time == flight.DepartureTime) && (arrival_time == flight.ArrivalTime) && (aircrew == flight.Aircrew))
                {
                    Console.WriteLine("Nema nikakvih promjena");
                    Helper.PendingUser();
                    return;
                }

                ConfirmEditFlight(flight, departure_time, arrival_time, aircrew!);

                return;
            }
        }

        public static void ConfirmEditFlight(Flight flight, DateTime departure_time, DateTime arrival_time, Aircrew aircrew)
        {
            Console.Write("\nZelite li dovrsiti proces uredivanje leta {0}? (DA/NE) ", flight.Number);

            if (Helper.CheckInput())
            {
                flight.DepartureTime = departure_time;
                flight.ArrivalTime = arrival_time;
                flight.Aircrew = aircrew;
                flight.Duration = arrival_time - departure_time;
                flight.LastUpdated = DateTime.Now;

                Console.WriteLine("Proces uredivanja leta {0} je dovrsen\n", flight.Number);
                Console.WriteLine("{0, -42} {1, -8} {2, -24} {3, -24} {4, -16} {5, -24} {6, -16} {7}", "ID", "Naziv", "Datum polaska", "Datum dolaska", "Udaljenost", "Vrijeme putovanja", "Avion", "Posada");
                Console.WriteLine("{0, -42} {1, -8} {2, -24} {3, -24} {4, -16:F2} {5, -24} {6, -16} {7}", flight.Id, flight.Number, flight.DepartureTime, flight.ArrivalTime, (flight.Distance + "km"), (flight.Duration.Hours + "h " + flight.Duration.Minutes + "min"), flight.Airplane.Name, flight.Aircrew.Name);
            }

            else
            {
                Console.WriteLine("Proces uredivanja leta {0} je prekinut\n", flight.Number);
            }

            Helper.PendingUser();

            return;
        }

        public static void DeleteFlight()
        {
            Console.WriteLine("\nBRISANJE POSTOJEĆEG LETA\n");

            while (true)
            {
                Console.Write("Odaberite let (unesite ID ili ostavite prazno za prekid): ");

                string? input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Proces uređivanja je prekinut");
                    Helper.PendingUser();
                    return;
                }

                if (!Guid.TryParse(input, out Guid id))
                {
                    Console.WriteLine("Unos nije valjan\n");
                    continue;
                }

                Flight? flight = Flights.Find(a => a.Id == id);

                if (flight == null)
                {
                    Console.WriteLine("Let s identifikatorom {0} ne postoji", id);
                    Helper.PendingUser();
                    return;
                }

                if (flight.Passengers.Count > flight.Airplane.MaximumCapacity / 2)
                {
                    Console.WriteLine("\nPopunjeno je vise od 50% kapaciteta leta\nProces brisanja leta {0} je prekinut", flight.Number);
                    Helper.PendingUser();
                    return;
                }

                if (flight.DepartureTime < DateTime.Now.AddHours(24))
                {
                    Console.WriteLine("\nVrijeme polaska je za manje od 24 sata\nProces brisanja leta {0} je prekinut", flight.Number);
                    Helper.PendingUser();
                    return;
                }

                ConfirmDeleteFlight(flight);

                return;
            }
        }

        public static void ConfirmDeleteFlight(Flight flight)
        {
            Console.Write("\nZelite li dovrsiti proces brisanja leta {0}? (DA/NE) ", flight.Number);

            string number = flight.Number;

            if (Helper.CheckInput())
            {
                Flights.Remove(flight);
                Console.WriteLine("Proces brisanja leta {0} je dovrsen", number);
            }

            else
            {
                Console.WriteLine("Proces brisanja leta {0} je prekinut", flight.Number);
            }

            Helper.PendingUser();

            return;
        }
    }
}
