using Internship_3_OOP.Classes;
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
                        CreateNewFlight();
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
                        ShowAirplanes();
                        break;
                    case '2':
                        CreateNewAirplane();
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
                if (!Airplane.Airplanes.Any())
                {
                    Console.WriteLine("Ne postoji niti jedan avion u memoriji\n");
                    break;
                }

                Console.Write("\nPretraživanje aviona:\na - Po ID-u\nb - Po nazivu\n\nOdabir: ");

                char choice = Console.ReadKey().KeyChar;

                Console.WriteLine("");

                switch (choice)
                {
                    case 'a':
                        SearchAirplaneById();
                        return;
                    case 'b':
                        SearchAirplaneByName();
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
                        DeleteAirplaneById();
                        return;
                    case 'b':
                        DeleteAirplaneByName();
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
                        ShowAircrew();
                        break;
                    case '2':
                        CreateNewAircrew();
                        break;
                    case '3':
                        CreateNewMember();
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
            Console.Write("Bok, {0}. Zelite li dovrsiti proces registracije? (DA/NE) ", first_name);

            if (Helper.CheckInput())
            {
                Passenger.Passengers.Add(new Passenger(first_name, last_name, birth_date, email, password));
                Console.WriteLine("Proces registracije je dovrsen\n");
            }

            else
            {
                Console.WriteLine("Proces registracije je prekinut\n");
            }

            PendingUser();

            return;
        }

        static void ShowFlights()
        {
            Console.WriteLine("\n| {0, -36} | {1, -7} | {2, -20} | {3, -20} | {4, -10} | {5, -17} |\n", "ID", "Naziv", "Datum polaska", "Datum dolaska", "Udaljenost", "Vrijeme putovanja");

            foreach (var flight in Flight.Flights)
            {
                Console.WriteLine("| {0, -36} | {1, -7} | {2, -20} | {3, -20} | {4, -10:F2} | {5, -17} |\n", flight.Id, flight.Number, flight.DepartureTime, flight.ArrivalTime, (flight.Distance + "km"), (flight.Duration.Hours + "h " + flight.Duration.Minutes + "min"));
            }

            PendingUser();
        }

        static void CreateNewFlight()
        {
            Console.WriteLine("\nDODAVANJE NOVOG LETA\n");

            string number = Helper.ValidateFlightNumber();
            DateTime departure_time = Helper.ValidateDateTime("polaska");
            DateTime arrival_time = Helper.ValidateDateTime("dolaska");
            double distance = Helper.ValidateDistance();

            AddNewFlight(number, departure_time, arrival_time, distance);
        }

        static void AddNewFlight(string number, DateTime departure_time, DateTime arrival_time, double distance)
        {
            Console.Write("Zelite li dovrsiti proces dodavanja leta broj {0}? (DA/NE) ", number);

            if (Helper.CheckInput())
            {
                Flight.Flights.Add(new Flight(number, departure_time, arrival_time, distance));
                Console.WriteLine("Proces dodavanja leta broj {0} je dovrsen\n", number);
            }

            else
            {
                Console.WriteLine("Proces dodavanja leta broj {0} je prekinut\n", number);
            }

            PendingUser();

            return;
        }

        static void ShowAirplanes()
        {
            Console.WriteLine("\n| {0, -36} | {1, -16} | {2, -18} | {3, -11} |\n", "ID", "Naziv", "Godina proizvodnje", "Broj letova");

            foreach (var airplane in Airplane.Airplanes)
            {
                Console.WriteLine("| {0, -36} | {1, -16} | {2, -18} | {3, -11} |\n", airplane.Id, airplane.Name, airplane.ProductionYear.Year, airplane.TotalFlights);
            }

            PendingUser();
        }

        static void CreateNewAirplane()
        {
            Console.WriteLine("\nDODAVANJE NOVOG AVIONA\n");

            string name = Helper.ValidateAirplaneName();
            DateOnly production_year = Helper.ValidateDate("proizvodnje");
            int total_flights = Helper.ValidateTotalFlights();

            AddNewFlight(name, production_year, total_flights);
        }

        static void SearchAirplaneById()
        {
            Console.WriteLine("\nPRETRAŽIVANJE AVIONA PO IDENTIFIKATORU\n");

            while (true)
            {
                Console.Write("Odaberite avion (unesite ID): ");

                if (!Guid.TryParse(Console.ReadLine(), out Guid id))
                {
                    Console.WriteLine("Unos nije valjan\n");
                    continue;
                }

                Airplane? airplane = Airplane.Airplanes.Find(a => a.Id == id);

                if (airplane == null)
                {

                    Console.WriteLine("Avion s identifikatorom {0} ne postoji\n", id);
                    PendingUser();
                    return;
                }

                Console.WriteLine("\n| {0, -36} | {1, -16} | {2, -18} | {3, -11} |", "ID", "Naziv", "Godina proizvodnje", "Broj letova");
                Console.WriteLine("| {0, -36} | {1, -16} | {2, -18} | {3, -11} |\n", airplane.Id, airplane.Name, airplane.ProductionYear.Year, airplane.TotalFlights);

                PendingUser();

                return;
            }
        }

        static void SearchAirplaneByName()
        {
            Console.WriteLine("\nPRETRAŽIVANJE AVIONA PO NAZIVU\n");

            while (true)
            {
                Console.Write("Odaberite avion (unesite naziv): ");

                string? name = Console.ReadLine();

                if (string.IsNullOrEmpty(name) || !Helper.IsAirplaneNameValid(name))
                {
                    Console.WriteLine("Unos nije valjan\n");
                    continue;
                }

                List<Airplane> airplanes = Airplane.Airplanes.Where(a => a.Name == name).ToList();

                if (airplanes == null)
                {

                    Console.WriteLine("Avion s nazivom {0} ne postoji\n", name);
                    PendingUser();
                    return;
                }

                Console.WriteLine("\n| {0, -36} | {1, -16} | {2, -18} | {3, -11} |", "ID", "Naziv", "Godina proizvodnje", "Broj letova");

                foreach (var airplane in airplanes)
                {
                    Console.WriteLine("| {0, -36} | {1, -16} | {2, -18} | {3, -11} |", airplane.Id, airplane.Name, airplane.ProductionYear.Year, airplane.TotalFlights);
                }

                Console.WriteLine("");

                PendingUser();

                return;
            }
        }

        static void DeleteAirplaneById()
        {
            Console.WriteLine("\nBRISANJE AVIONA PO IDENTIFIKATORU\n");

            while (true)
            {
                Console.Write("Odaberite avion (unesite ID): ");

                if (!Guid.TryParse(Console.ReadLine(), out Guid id))
                {
                    Console.WriteLine("Unos nije valjan\n");
                    continue;
                }

                Airplane? airplane = Airplane.Airplanes.Find(a => a.Id == id);

                if (airplane == null)
                {

                    Console.WriteLine("Avion s identifikatorom {0} ne postoji\n", id);
                    PendingUser();
                    return;
                }

                Console.Write("\nZelite li dovrsiti proces brisanja aviona {0} ({1})? (DA/NE) ", airplane.Name, airplane.Id);

                if (Helper.CheckInput())
                {
                    Airplane.Airplanes.Remove(airplane);
                    Console.WriteLine("Proces brisanja aviona {0} ({1}) je dovrsen\n", airplane.Name, airplane.Id);
                }

                else
                {
                    Console.WriteLine("Proces brisanja aviona {0} ({1}) je prekinut\n", airplane.Name, airplane.Id);
                }

                PendingUser();

                return;
            }
        }

        static void DeleteAirplaneByName()
        {

        }

        static void AddNewFlight(string name, DateOnly production_year, int total_flights)
        {
            Console.Write("Zelite li dovrsiti proces dodavanja aviona {0}? (DA/NE) ", name);

            if (Helper.CheckInput())
            {
                Airplane.Airplanes.Add(new Airplane(name, production_year, total_flights));
                Console.WriteLine("Proces dodavanja aviona {0} je dovrsen\n", name);
            }

            else
            {
                Console.WriteLine("Proces dodavanja aviona {0} je prekinut\n", name);
            }

            PendingUser();

            return;
        }

        static void ShowAircrew()
        {
            Console.WriteLine("\n{0, -16} {1}", "Naziv posade", "Lista clanova");

            foreach (var aircrew in Aircrew.Aircrews)
            {
                string members = string.Join(", ", aircrew.Members.Select(m => m.Role + " " + m.GetLastName()));
                Console.WriteLine("\n{0, -16} {1}\n", aircrew.Name, members);
                ShowMembers(aircrew);
            }

            Console.WriteLine("");
            PendingUser();
        }

        static void ShowMembers(Aircrew aircrew)
        {
            Console.WriteLine("{0, -16} {1, -16} {2, -16} {3, -16} {4}", "Ime", "Prezime", "Pozicija", "Spol", "Datum rođenja");

            foreach (var member in aircrew.Members)
            {
                Console.WriteLine("{0, -16} {1, -16} {2, -16} {3, -16} {4}", member.GetFirstName(), member.GetLastName(), member.Role, member.Gender, member.GetBirthDate());
            }
        }

        static void CreateNewAircrew()
        {
            Console.WriteLine("\nKREIRANJE NOVE POSADE\n");

            string name = Helper.ValidateAircrewName();
            
            Member? pilot = Helper.ValidatePilot();
            if (pilot == null) { UnavailableCrewMessage(); return; }

            Member? copilot = Helper.ValidateCopilot();
            if (copilot == null) { UnavailableCrewMessage(); return; }

            Member? attendant_1 = Helper.ValidateAttendant(new List<Member>());
            if (attendant_1 == null) { UnavailableCrewMessage(); return; }

            Member? attendant_2 = Helper.ValidateAttendant(new List<Member>() { attendant_1 });
            if (attendant_2 == null) { UnavailableCrewMessage(); return; }

            List<Member> members = new List<Member>()
            {
                pilot,
                copilot,
                attendant_1,
                attendant_2
            };

            AddNewAircrew(name, members);
        }

        static void AddNewAircrew(string name, List<Member> members)
        {
            Console.Write("\nZelite li dovrsiti proces kreiranja nove posade {0}? (DA/NE) ", name);

            if (Helper.CheckInput())
            {
                Aircrew.Aircrews.Add(new Aircrew(name)
                {
                    Members =
                    {
                        members[0],
                        members[1],
                        members[2],
                        members[3]
                    }
                }
                );

                Console.WriteLine("Proces kreiranja nove posade {0} je dovrsen\n", name);
            }

            else
            {
                Console.WriteLine("Proces kreiranja nove posade {0} je prekinut\n", name);
            }

            PendingUser();

            return;
        }

        static void UnavailableCrewMessage()
        {
            Console.WriteLine("Proces kreiranja nove posade je prekinut\n");
            PendingUser();
        }

        static void PendingUser()
        {
            Console.Write("Pritisnite bilo koju tipku za nastavak... ");
            Console.ReadKey(true);
            Console.Clear();
        }

        static void CreateNewMember()
        {
            Console.WriteLine("\nDODAVANJE NOVE OSOBE\n");

            string first_name = Helper.ValidateName("ime");
            string last_name = Helper.ValidateName("prezime");
            DateOnly birth_date = Helper.ValidateBirthDate();
            Enums.Genders gender = Helper.ValidateGender();
            Enums.Roles role = Helper.ValidateRole();

            AddNewMember(first_name, last_name, birth_date, gender, role);
        }

        static void AddNewMember(string first_name, string last_name, DateOnly birth_date, Enums.Genders gender, Enums.Roles role)
        {
            Console.Write("Zelite li dovrsiti proces dodavanja nove osobe {0} {1} ({2})? (DA/NE) ", first_name, last_name, role);

            if (Helper.CheckInput())
            {
                Member.Members.Add(new Member(first_name, last_name, birth_date, gender, role));
                Console.WriteLine("Proces dodavanja nove osobe {0} {1} ({2}) je dovrsen\n", first_name, last_name, role);
            }

            else
            {
                Console.WriteLine("Proces dodavanja nove osobe {0} {1} ({2}) je prekinut\n", first_name, last_name, role);
            }

            Console.Write("Pritisnite bilo koju tipku za nastavak... ");
            Console.ReadKey(true);
            Console.Clear();

            return;
        }
    }
}
