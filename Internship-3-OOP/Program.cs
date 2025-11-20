using Internship_3_OOP.Classes;

namespace Internship_3_OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Helper.Initialize();
            Console.WriteLine("APLIKACIJA ZA UPRAVLJANJE AERODROMOM");
            ChooseFromMainMenu();
        }

        static void ChooseFromMainMenu()
        {
            while (true)
            {
                Console.Write("\n1 - Putnici\n2 - Letovi\n3 - Avioni\n4 - Posada\n5 - Izlaz iz programa\n\nOdabir: ");

                char choice = Console.ReadKey().KeyChar;

                Console.WriteLine("");

                switch (choice)
                {
                    case '1':
                        ChooseFromPassengersMenu();
                        break;
                    case '2':
                        ChooseFromFlightsMenu();
                        break;
                    case '3':
                        ChooseFromAirplanesMenu();
                        break;
                    case '4':
                        ChooseFromAircrewMenu();
                        break;
                    case '5':
                        return;
                    default:
                        Console.WriteLine("Unos nije valjan");
                        break;
                }
            }
        }

        static void ChooseFromPassengersMenu()
        {
            while (true)
            {
                Console.Write("\n1 - Registracija\n2 - Prijava\n3 - Povratak na prethodni izbornik\n\nOdabir: ");

                char choice = Console.ReadKey().KeyChar;

                Console.WriteLine("");

                switch (choice)
                {
                    case '1':
                        RegisterNewPassenger();
                        break;
                    case '2':
                        ChooseFromSignedPassengersMenu();
                        break;
                    case '3':
                        return;
                    default:
                        Console.WriteLine("Unos nije valjan");
                        break;
                }
            }
        }

        static void ChooseFromSignedPassengersMenu()
        {
            while (true)
            {
                Console.Write("\n1 - Prikaz svih letova\n2 - Odabir leta\n3 - Pretraživanje letova\n4 - Otkazivanje leta\n5 - Povratak na prethodni izbornik\n\nOdabir: ");

                char choice = Console.ReadKey().KeyChar;

                Console.WriteLine("");

                switch (choice)
                {
                    case '1':
                        break;
                    case '2':
                        break;
                    case '3':
                        ChooseFromSearchFlightsMenu();
                        break;
                    case '4':
                        break;
                    case '5':
                        return;
                    default:
                        Console.WriteLine("Unos nije valjan");
                        break;
                }
            }
        }

        static void ChooseFromSearchFlightsMenu()
        {
            while (true)
            {
                Console.Write("\nPretraživanje letova:\na - Po ID-u\nb - Po nazivu\n\nOdabir: ");

                char choice = Console.ReadKey().KeyChar;

                Console.WriteLine("");

                switch (choice)
                {
                    case 'a':
                        return;
                    case 'b':
                        return;
                    default:
                        Console.WriteLine("Unos nije valjan");
                        break;
                }
            }
        }

        static void ChooseFromFlightsMenu()
        {
            while (true)
            {
                Console.Write("\n1 - Prikaz svih letova\n2 - Dodavanje leta\n3 - Pretraživanje letova\n4 - Uređivanje leta\n5 - Brisanje leta\n6 - Povratak na prethodni izbornik\n\nOdabir: ");

                char choice = Console.ReadKey().KeyChar;

                Console.WriteLine("");

                switch (choice)
                {
                    case '1':
                        ShowFlights();
                        break;
                    case '2':
                        break;
                    case '3':
                        ChooseFromSearchFlightsMenu();
                        break;
                    case '4':
                        break;
                    case '5':
                        break;
                    case '6':
                        return;
                    default:
                        Console.WriteLine("Unos nije valjan");
                        break;
                }
            }
        }

        static void ChooseFromAirplanesMenu()
        {
            while (true)
            {
                Console.Write("\n1 - Prikaz svih aviona\n2 - Dodavanje novog aviona\n3 - Pretraživanje aviona\n4 - Brisanje aviona\n5 - Povratak na glavni izbornik\n\nOdabir: ");

                char choice = Console.ReadKey().KeyChar;

                Console.WriteLine("");

                switch (choice)
                {
                    case '1':
                        break;
                    case '2':
                        break;
                    case '3':
                        ChooseFromSearchAirplanesMenu();
                        break;
                    case '4':
                        ChooseFromDeleteAirplanesMenu();
                        break;
                    case '5':
                        return;
                    default:
                        Console.WriteLine("Unos nije valjan");
                        break;
                }
            }
        }

        static void ChooseFromSearchAirplanesMenu()
        {
            while (true)
            {
                Console.Write("\nPretraživanje aviona:\na - Po ID-u\nb - Po nazivu\n\nOdabir: ");

                char choice = Console.ReadKey().KeyChar;

                Console.WriteLine("");

                switch (choice)
                {
                    case 'a':
                        return;
                    case 'b':
                        return;
                    default:
                        Console.WriteLine("Unos nije valjan");
                        break;
                }
            }
        }

        static void ChooseFromDeleteAirplanesMenu()
        {
            while (true)
            {
                Console.Write("\nBrisanje aviona:\na - Po ID-u\nb - Po nazivu\n\nOdabir: ");

                char choice = Console.ReadKey().KeyChar;

                Console.WriteLine("");

                switch (choice)
                {
                    case 'a':
                        return;
                    case 'b':
                        return;
                    default:
                        Console.WriteLine("Unos nije valjan");
                        break;
                }
            }
        }

        static void ChooseFromAircrewMenu()
        {
            while (true)
            {
                Console.Write("\n1 - Prikaz svih posada\n2 - Kreiranje nove posade\n3 - Dodavanje nove osobe\n4 - Povratak na prethodni izbornik\n\nOdabir: ");

                char choice = Console.ReadKey().KeyChar;

                Console.WriteLine("");

                switch (choice)
                {
                    case '1':
                        break;
                    case '2':
                        break;
                    case '3':
                        break;
                    case '4':
                        return;
                    default:
                        Console.WriteLine("Unos nije valjan");
                        break;
                }
            }
        }

        static void RegisterNewPassenger()
        {
            Console.WriteLine("\nREGISTRACIJA NOVOG PUTNIKA\n");

            string email = Helper.ValidateEmail();
            string password = Helper.ValidatePassword();
            string first_name = Helper.ValidateName("ime");
            string last_name = Helper.ValidateName("prezime");
            DateOnly birth_date = Helper.ValidateBirthDate();

            AddNewPassenger(email, password, first_name, last_name, birth_date);
        }

        static void AddNewPassenger(string email, string password, string first_name, string last_name, DateOnly birth_date)
        {
            Console.WriteLine("Bok, {0}. Zelite li dovrsiti proces registracije? (DA/NE)", first_name);

            if (Helper.CheckInput())
            {
                Passenger.Passengers.Add(new Passenger(first_name, last_name, birth_date, email, password));
                Console.WriteLine("Proces registracije je dovrsen\n");
            }

            else
            {
                Console.WriteLine("Proces registracije je prekinut\n");
            }

            Console.Write("Pritisnite bilo koju tipku za nastavak... ");
            Console.ReadKey(true);
            Console.Clear();

            return;
        }

        static void ShowFlights()
        {
            Console.WriteLine("\n| {0, -36} | {1, -7} | {2, -20} | {3, -20} | {4, -10} | {5, -17} |\n", "ID", "Naziv", "Datum polaska", "Datum dolaska", "Udaljenost", "Vrijeme putovanja");

            foreach (var flight in Flight.Flights)
            {
                Console.WriteLine("| {0, -36} | {1, -7} | {2, -20} | {3, -20} | {4, -10:F2} | {5, -17} |\n", flight.Id, flight.Number, flight.DepartureTime, flight.ArrivalTime, (flight.Distance + "km"), (flight.Duration.Hours + "h " + flight.Duration.Minutes + "min"));
            }

            Console.Write("Pritisnite bilo koju tipku za nastavak... ");
            Console.ReadKey(true);
            Console.Clear();
        }
    }
}
