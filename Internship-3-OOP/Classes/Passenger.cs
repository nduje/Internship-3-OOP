using System.Diagnostics.Metrics;

namespace Internship_3_OOP.Classes
{
    internal class Passenger : Person
    {
        string Email { get; set; }
        string Password { get; set; }
        public static List<Passenger> Passengers = new List<Passenger>();
        public static Passenger? SignedPassenger { get; set; }
        public List<Flight> Flights = new List<Flight>();

        public Passenger(string first_name, string last_name, DateOnly birth_date, string email, string password) : base(first_name, last_name, birth_date)
        {
            Email = email;
            Password = password;
        }

        public static void RegisterNewPassenger()
        {
            Console.WriteLine("\nREGISTRACIJA NOVOG PUTNIKA\n");

            string email = Helper.ValidateEmail();
            string password = Helper.ValidatePassword();
            string first_name = Helper.ValidateName("ime");
            string last_name = Helper.ValidateName("prezime");
            DateOnly birth_date = Helper.ValidateBirthDate();

            AddNewPassenger(email, password, first_name, last_name, birth_date);
        }

        public static void AddNewPassenger(string email, string password, string first_name, string last_name, DateOnly birth_date)
        {
            Console.Write("Bok, {0}. Zelite li dovrsiti proces registracije? (DA/NE) ", first_name);

            if (Helper.CheckInput())
            {
                Passengers.Add(new Passenger(first_name, last_name, birth_date, email, password));
                Console.WriteLine("Proces registracije je dovrsen\n");
            }

            else
            {
                Console.WriteLine("Proces registracije je prekinut\n");
            }

            Helper.PendingUser();

            return;
        }

        public static void SignIn()
        {
            Console.WriteLine("\nPRIJAVA PUTNIKA\n");

            string email = Helper.ValidateEmail();
            string password = Helper.ValidatePassword();

            Passenger? passenger = Passenger.Passengers.Find(p => p.Email == email && p.Password == password);

            if (passenger == null)
            {
                Console.WriteLine("Pogrešan email ili lozinka");
                Helper.PendingUser();
                SignedPassenger = null;
                return;
            }

            Console.WriteLine("Dobro došao, {0}", passenger.FirstName);
            Helper.PendingUser();

            SignedPassenger = passenger;
            Menu.ChooseFromSignedPassengersMenu();

            return;
        }

        public static void ShowReservedFlights()
        {
            Console.WriteLine("\nPRIKAZ SVIH LETOVA\n");

            List<Flight>? flights = SignedPassenger?.Flights.ToList();

            if (flights == null || flights.Count == 0)
            {
                Console.WriteLine("Ne postoji niti jedan rezervirani let");
                Helper.PendingUser();
                return;
            }

            Console.WriteLine("{0, -42} {1, -8} {2, -24} {3, -24} {4, -16} {5, -24} {6, -16} {7}", "ID", "Naziv", "Datum polaska", "Datum dolaska", "Udaljenost", "Vrijeme putovanja", "Avion", "Posada");

            foreach (var flight in flights)
            {
                Console.WriteLine("{0, -42} {1, -8} {2, -24} {3, -24} {4, -16:F2} {5, -24} {6, -16} {7}", flight.Id, flight.Number, flight.DepartureTime, flight.ArrivalTime, (flight.Distance + "km"), (flight.Duration.Hours + "h " + flight.Duration.Minutes + "min"), flight.Airplane.Name, flight.Aircrew.Name);
            }

            Helper.PendingUser();
        }

        public static void ReserveFlight()
        {
            Flight? flight = Helper.ValidateAvailableFlight();

            if (flight == null)
            {
                Console.WriteLine("Proces rezervacije je prekinut");
                Helper.PendingUser();
                return;
            }

            Enums.Classes category = Helper.ValidateCategory(flight);

            ConfirmReserveFlight(flight, category);

            return;
        }

        public static void ConfirmReserveFlight(Flight flight, Enums.Classes category)
        {
            Console.Write("\nZelite li dovrsiti proces rezervacije leta {0}? (DA/NE) ", flight.Number);

            if (Helper.CheckInput())
            {
                SignedPassenger?.Flights.Add(flight);
                flight.Airplane.Capacities[category]--;
                flight.Airplane.CurrentCapacity--;
                flight.Airplane.LastUpdated = DateTime.Now;
                flight.Passengers.Add(SignedPassenger!);
                Reservation.Reservations.Add(new Reservation(SignedPassenger!, flight, category));

                Console.WriteLine("Rezerviran je let {0}\n", flight.Number);
                Console.WriteLine("{0, -42} {1, -8} {2, -24} {3, -24} {4, -16} {5, -24} {6, -16} {7}", "ID", "Naziv", "Datum polaska", "Datum dolaska", "Udaljenost", "Vrijeme putovanja", "Avion", "Posada");
                Console.WriteLine("{0, -42} {1, -8} {2, -24} {3, -24} {4, -16:F2} {5, -24} {6, -16} {7}", flight.Id, flight.Number, flight.DepartureTime, flight.ArrivalTime, (flight.Distance + "km"), (flight.Duration.Hours + "h " + flight.Duration.Minutes + "min"), flight.Airplane.Name, flight.Aircrew.Name);
            }

            else
            {
                Console.WriteLine("Proces rezervacije leta {0} je prekinut", flight.Number);
            }

            Helper.PendingUser();

            return;
        }

        public static void SearchReservedFlightById()
        {
            Console.WriteLine("\nPRETRAŽIVANJE REZERVIRANOG LETA PO IDENTIFIKATORU\n");

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

                Flight? flight = SignedPassenger?.Flights.Find(a => a.Id == id);

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

        public static void SearchReservedFlightByName()
        {
            Console.WriteLine("\nPRETRAŽIVANJE REZERVIRANOG LETA PO NAZIVU\n");

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

                List<Flight>? flights = SignedPassenger?.Flights.Where(a => a.Number == number).ToList();

                if (flights == null || flights.Count == 0)
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

        public static void CancelFlight()
        {
            Flight? flight = Helper.ValidateReservedFlight();

            if (flight == null)
            {
                Console.WriteLine("Proces rezervacije je prekinut");
                Helper.PendingUser();
                return;
            }

            if (flight.DepartureTime < DateTime.Now.AddHours(24))
            {
                Console.WriteLine("Nije moguće otkazati let koji polijeće unutar 24 sata");
                Helper.PendingUser();
                return;
            }


            Reservation reservation = Reservation.Reservations.FirstOrDefault(c => c.Passenger == SignedPassenger && c.Flight == flight)!;
            Enums.Classes category = reservation.Category;

            ConfirmCancelFlight(flight, category, reservation);

            return;
        }

        public static void ConfirmCancelFlight(Flight flight, Enums.Classes category, Reservation reservation)
        {
            Console.Write("\nZelite li dovrsiti proces otkazivanja leta {0}? (DA/NE) ", flight.Number);

            if (Helper.CheckInput())
            {
                SignedPassenger?.Flights.Remove(flight);
                flight.Airplane.Capacities[category]++;
                flight.Airplane.CurrentCapacity++;
                flight.Airplane.LastUpdated = DateTime.Now;
                flight.Passengers.Remove(SignedPassenger!);
                Reservation.Reservations.Remove(reservation);

                Console.WriteLine("Otkazan je let {0}", flight.Number);
            }

            else
            {
                Console.WriteLine("Proces rezervacije leta {0} je prekinut", flight.Number);
            }

            Helper.PendingUser();

            return;
        }
    }
}
