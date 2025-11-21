using System.Data.SqlTypes;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Internship_3_OOP.Classes
{
    internal class Helper
    {
        public static void Initialize()
        {
            InitializeAirplanes();
            InitializeMembers();
            InitializeAircrews();
            InitializeFlights();
        }

        private static void InitializeFlights()
        {
            Flight.Flights.Add(new Flight("LH256", new DateTime(2025, 11, 19, 14, 30, 0), new DateTime(2025, 11, 19, 18, 45, 0), 1200, Airplane.Airplanes[0], Aircrew.Aircrews[0]));
            Flight.Flights.Add(new Flight("AA100", new DateTime(2025, 11, 20, 9, 0, 0), new DateTime(2025, 11, 20, 11, 30, 0), 800, Airplane.Airplanes[1], Aircrew.Aircrews[1]));
        }

        private static void InitializeAirplanes()
        {
            Airplane.Airplanes.Add(new Airplane("Boeing 737", new DateOnly(2015, 6, 12), 1200));
            Airplane.Airplanes.Add(new Airplane("Boeing 737", new DateOnly(2012, 3, 6), 1200));
            Airplane.Airplanes.Add(new Airplane("Airbus A320", new DateOnly(2018, 3, 25), 950));
            Airplane.Airplanes.Add(new Airplane("Embraer E195", new DateOnly(2020, 11, 5), 600));
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

        public static Guid GenerateGuid()
        {
            return Guid.NewGuid();
        }

        public static string ValidateEmail()
        {
            string email;

            do
            {
                Console.Write("Unesite valjani email (example@example.com): ");
                email = Console.ReadLine() ?? "";
            } while (string.IsNullOrEmpty(email) || !Helper.IsEmailValid(email));

            Console.WriteLine("");

            return email;
        }

        public static bool IsEmailValid(string email)
        {
            var pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            return Regex.IsMatch(email, pattern);
        }

        public static string ValidatePassword()
        {
            string password;

            do
            {
                Console.Write("Unesite valjanu lozinku (najmanje 8 znakova - barem jedno veliko slovo, jedno malo slovo i jedan broj): ");
                password = Console.ReadLine() ?? "";
            } while (string.IsNullOrEmpty(password) || !Helper.IsPasswordValid(password));

            Console.WriteLine("");

            return password;
        }

        public static bool IsPasswordValid(string password)
        {
            var pattern = @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d).{8,}$";

            return Regex.IsMatch(password, pattern);
        }

        public static string ValidateName(string type)
        {
            var pattern = @"^[A-Za-zČčĆćĐđŠšŽž]+(?: [A-Za-zČčĆćĐđŠšŽž]+)*$";

            while (true)
            {
                Console.Write("Unesite {0}: ", type);
                string input = (Console.ReadLine() ?? "").Trim();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Unos ne smije biti prazan\n");
                    continue;
                }

                if (!Regex.IsMatch(input, pattern))
                {
                    Console.WriteLine("Unos smije sadržavati isključivo slova\n");
                    continue;
                }

                input = string.Join(" ", input.Split(' ').Select(i => char.ToUpper(i[0]) + i.Substring(1).ToLower()));

                Console.WriteLine("");

                return input;
            }
        }

        public static string ValidateFlightNumber()
        {
            string number;

            do
            {
                Console.Write("Unesite valjani broj leta (npr. LA205B - 2 slova, 1 do 4 znamenke, opcionalno A ili B): ");
                number = Console.ReadLine() ?? "";
            } while (string.IsNullOrEmpty(number) || !Helper.IsFlightNumberValid(number));

            Console.WriteLine("");

            return number;
        }

        public static bool IsFlightNumberValid(string number)
        {
            var pattern = @"^[A-Z]{2}\d{1,4}[AB]?$";

            return Regex.IsMatch(number, pattern);
        }

        public static DateOnly ValidateBirthDate()
        {
            DateOnly birth_date;
            int maximum_age = 100;
            int minimum_age = 10;
            DateOnly today = DateOnly.FromDateTime(DateTime.Today);

            while (true)
            {
                Console.Write("Unesite datum rođenja (npr. 01.03.2010.): ");

                if (!DateOnly.TryParseExact(Console.ReadLine() ?? "", "dd.MM.yyyy.", out birth_date))
                {
                    Console.WriteLine("Neispravan format datuma\n");
                    continue;
                }

                if (birth_date > today)
                {
                    Console.WriteLine("Datum ne može biti u budućnosti\n");
                    continue;
                }

                int age = today.Year - birth_date.Year;
                if (birth_date > today.AddYears(-age)) age--;

                if (age > maximum_age)
                {
                    Console.WriteLine("Osoba ne može imati više od {0} godina\n", maximum_age);
                    continue;
                }

                if (age < minimum_age)
                {
                    Console.WriteLine("Osoba ne može imati manje od {0} godina\n", minimum_age);
                    continue;
                }

                Console.WriteLine("");

                return birth_date;
            }
        }

        public static DateTime ValidateDateTime(string type)
        {
            return ValidateDate(type).ToDateTime(ValidateTime(type));
        }

        public static DateOnly ValidateDate(string type)
        {
            while (true)
            {
                Console.Write("Unesite datum {0} (npr. 01.01.2025.): ", type);

                if (DateOnly.TryParseExact(Console.ReadLine() ?? "", "dd.MM.yyyy.", out DateOnly date))
                {
                    Console.WriteLine("");
                    return date;
                }

                else
                {
                    Console.WriteLine("Neispravan format datuma\n");
                }
            }
        }

        public static TimeOnly ValidateTime(string type)
        {
            while (true)
            {
                Console.Write("Unesite vrijeme {0} (npr. 16:15): ", type);

                if (TimeOnly.TryParseExact(Console.ReadLine() ?? "", "HH:mm", out TimeOnly time))
                {
                    Console.WriteLine("");
                    return time;
                }

                else
                {
                    Console.WriteLine("Neispravan format vremena\n");
                }
            }
        }

        public static double ValidateDistance()
        {
            while (true)
            {
                Console.Write("Unesite udaljenost između polazišta i dolazišta (u kilometrima): ");

                if (!double.TryParse(Console.ReadLine(), out double distance))
                {
                    Console.WriteLine("Unos nije valjan\n");
                    continue;
                }

                if (distance <= 0)
                {
                    Console.WriteLine("Udaljenost ne može biti nula ili negativan broj\n");
                    continue;
                }


                Console.WriteLine("");
                return distance;
            }
        }

        public static string ValidateAirplaneName()
        {
            string name;

            do
            {
                Console.Write("Unesite valjano ime aviona (npr. Boeing 737): ");
                name = Console.ReadLine() ?? "";
            } while (string.IsNullOrEmpty(name) || !Helper.IsAirplaneNameValid(name));

            Console.WriteLine("");

            return name;
        }

        public static bool IsAirplaneNameValid(string name)
        {
            var pattern = @"^[A-Za-z0-9\s\.-]+$";

            return Regex.IsMatch(name, pattern);
        }

        public static string ValidateAircrewName()
        {
            string name;

            do
            {
                Console.Write("Unesite valjano ime posade (npr. Alpha Crew): ");
                name = Console.ReadLine() ?? "";
            } while (string.IsNullOrEmpty(name) || !Helper.IsAirplaneNameValid(name));

            return name;
        }

        public static bool IsAircrewNameValid(string name)
        {
            var pattern = @"^[A-Z][A-Za-z0-9\- ]{2,29}$";

            return Regex.IsMatch(name, pattern);
        }

        public static int ValidateTotalFlights()
        {
            while (true)
            {
                Console.Write("Unesite ukupan broj odrađenih letova: ");

                if (!int.TryParse(Console.ReadLine(), out int total_flights))
                {
                    Console.WriteLine("Unos nije valjan\n");
                    continue;
                }

                if (total_flights < 0)
                {
                    Console.WriteLine("Broj ne može negativan broj\n");
                    continue;
                }


                Console.WriteLine("");
                return total_flights;
            }
        }

        public static Enums.Genders ValidateGender()
        {
            while (true)
            {
                Console.Write("Spol osobe:\n1 - Male\n2 - Female\n\nOdabir: ");

                char choice = Console.ReadKey().KeyChar;

                Console.WriteLine("");

                switch (choice)
                {
                    case '1':
                        Console.WriteLine("");
                        return Enums.Genders.Male;
                    case '2':
                        Console.WriteLine("");
                        return Enums.Genders.Female;
                    default:
                        Console.WriteLine("Unos nije valjan\n");
                        break;
                }
            }
        }

        public static Enums.Roles ValidateRole()
        {
            while (true)
            {
                Console.Write("Pozicija osobe:\n1 - Pilot\n2 - Copilot\n3 - Attendant\n\nOdabir: ");

                char choice = Console.ReadKey().KeyChar;

                Console.WriteLine("");

                switch (choice)
                {
                    case '1':
                        Console.WriteLine("");
                        return Enums.Roles.Pilot;
                    case '2':
                        Console.WriteLine("");
                        return Enums.Roles.Copilot;
                    case '3':
                        Console.WriteLine("");
                        return Enums.Roles.Attendant;
                    default:
                        Console.WriteLine("Unos nije valjan\n");
                        break;
                }
            }
        }

        public static Member ValidatePilot()
        {
            List<Member> assigned_pilots = new List<Member>(Aircrew.Aircrews.SelectMany(a => a.Members)).Where(m => m.Role == Enums.Roles.Pilot).ToList();

            List<Member> unassigned_pilots = new List<Member>(Member.Members.Where(m => !assigned_pilots.Contains(m) && m.Role == Enums.Roles.Pilot)).ToList();

            if (unassigned_pilots.Count == 0)
            {
                Console.WriteLine("\nNe postoji niti jedan dostupan pilot");
                return null;
            }

            Console.WriteLine("\nPiloti koji nisu dodijeljeni niti jednoj posadi:\n");
            Console.WriteLine("{0, -16} {1, -16} {2, -16} {3, -16} {4}","Redni broj", "Ime", "Prezime", "Spol", "Datum rođenja");

            int counter = 0;

            foreach (var member in unassigned_pilots)
            {
                Console.WriteLine("{0, -16} {1, -16} {2, -16} {3, -16} {4}", ++counter, member.GetFirstName(), member.GetLastName(), member.Gender, member.GetBirthDate());
            }

            Console.Write("\nOdaberite redni broj člana kabinskog osoblja kojeg želite dodati\n");

            while (true)
            {
                Console.Write("\nOdabir: ");

                if (int.TryParse(Console.ReadLine(), out int index) && (index > 0 && index <= unassigned_pilots.Count))
                {
                    Console.WriteLine("\nOdabran je član kabinskog osoblja {0} {1}", unassigned_pilots[index - 1].GetFirstName(), unassigned_pilots[index - 1].GetLastName());
                    return unassigned_pilots[index - 1];
                }

                else 
                {
                    Console.WriteLine("Unos nije valjan");
                    continue;
                }
            }
        }

        public static Member ValidateCopilot()
        {
            List<Member> assigned_copilots = new List<Member>(Aircrew.Aircrews.SelectMany(a => a.Members)).Where(m => m.Role == Enums.Roles.Copilot).ToList();

            List<Member> unassigned_copilots = new List<Member>(Member.Members.Where(m => !assigned_copilots.Contains(m) && m.Role == Enums.Roles.Copilot)).ToList();

            if (unassigned_copilots.Count == 0)
            {
                Console.WriteLine("\nNe postoji niti jedan dostupan kopilot");
                return null;
            }

            Console.WriteLine("\nKopiloti koji nisu dodijeljeni niti jednoj posadi:\n");
            Console.WriteLine("{0, -16} {1, -16} {2, -16} {3, -16} {4}", "Redni broj", "Ime", "Prezime", "Spol", "Datum rođenja");

            int counter = 0;

            foreach (var member in unassigned_copilots)
            {
                Console.WriteLine("{0, -16} {1, -16} {2, -16} {3, -16} {4}", ++counter, member.GetFirstName(), member.GetLastName(), member.Gender, member.GetBirthDate());
            }

            Console.Write("\nOdaberite redni broj kopilota kojeg želite dodati\n");

            while (true)
            {
                Console.Write("\nOdabir: ");

                if (int.TryParse(Console.ReadLine(), out int index) && (index > 0 && index <= unassigned_copilots.Count))
                {
                    Console.WriteLine("\nOdabran je kopilot {0} {1}", unassigned_copilots[index - 1].GetFirstName(), unassigned_copilots[index - 1].GetLastName());
                    return unassigned_copilots[index - 1];
                }

                else
                {
                    Console.WriteLine("Unos nije valjan");
                    continue;
                }
            }
        }

        public static Member ValidateAttendant(List<Member> selected)
        {
            List<Member> assigned_attendants = new List<Member>(Aircrew.Aircrews.SelectMany(a => a.Members)).Where(m => m.Role == Enums.Roles.Attendant).ToList();

            List<Member> unassigned_attendants = new List<Member>(Member.Members.Where(m => !assigned_attendants.Contains(m) && !selected.Contains(m) && m.Role == Enums.Roles.Attendant)).ToList();

            if (unassigned_attendants.Count == 0)
            {
                Console.WriteLine("\nNe postoji niti jedan dostupan član kabinskog osoblja");
                return null;
            }

            Console.WriteLine("\nČlanovi kabinskog osoblja koji nisu dodijeljeni niti jednoj posadi:\n");
            Console.WriteLine("{0, -16} {1, -16} {2, -16} {3, -16} {4}", "Redni broj", "Ime", "Prezime", "Spol", "Datum rođenja");

            int counter = 0;

            foreach (var member in unassigned_attendants)
            {
                Console.WriteLine("{0, -16} {1, -16} {2, -16} {3, -16} {4}", ++counter, member.GetFirstName(), member.GetLastName(), member.Gender, member.GetBirthDate());
            }

            Console.Write("\nOdaberite redni broj člana kabinskog osoblja kojeg želite dodati\n");

            while (true)
            {
                Console.Write("\nOdabir: ");

                if (int.TryParse(Console.ReadLine(), out int index) && (index > 0 && index <= unassigned_attendants.Count))
                {
                    Console.WriteLine("\nOdabran je član kabinskog osoblja {0} {1}", unassigned_attendants[index - 1].GetFirstName(), unassigned_attendants[index - 1].GetLastName());
                    return unassigned_attendants[index - 1];
                }

                else
                {
                    Console.WriteLine("Unos nije valjan");
                    continue;
                }
            }
        }

        public static Airplane ValidateAirplane()
        {
            List<Airplane> unavailable_airplanes = new List<Airplane>(Flight.Flights.Select(a => a.Airplane)).ToList();

            List<Airplane> available_airplanes = new List<Airplane>(Airplane.Airplanes.Where(m => !unavailable_airplanes.Contains(m))).ToList();

            if (available_airplanes.Count == 0)
            {
                Console.WriteLine("\nNe postoji niti jedan dostupan avion");
                return null;
            }

            Console.WriteLine("\nAvioni koji nisu dodijeljeni niti jednom letu:\n");
            Console.WriteLine("{0, -16} {1, -42} {2, -16} {3, -24} {4}", "Redni broj", "ID", "Naziv", "Godina proizvodnje", "Broj letova");

            int counter = 0;

            foreach (var airplane in available_airplanes)
            {
                Console.WriteLine("{0, -16} {1, -42} {2, -16} {3, -24} {4}", ++counter, airplane.Id, airplane.Name, airplane.ProductionYear, airplane.TotalFlights);
            }

            Console.Write("\nOdaberite redni broj aviona kojeg želite dodijeliti letu\n");

            while (true)
            {
                Console.Write("\nOdabir: ");

                if (int.TryParse(Console.ReadLine(), out int index) && (index > 0 && index <= available_airplanes.Count))
                {
                    Console.WriteLine("\nOdabran je avion {0} ({1})", available_airplanes[index - 1].Name, available_airplanes[index - 1].Id);
                    return available_airplanes[index - 1];
                }

                else
                {
                    Console.WriteLine("Unos nije valjan");
                    continue;
                }
            }
        }

        public static Aircrew ValidateAircrew()
        {
            List<Aircrew> unavailable_aircrews = new List<Aircrew>(Flight.Flights.Select(a => a.Aircrew)).ToList();

            List<Aircrew> available_aircrews = new List<Aircrew>(Aircrew.Aircrews.Where(m => !unavailable_aircrews.Contains(m))).ToList();

            if (available_aircrews.Count == 0)
            {
                Console.WriteLine("\nNe postoji niti jedna dostupna posada");
                return null;
            }

            Console.WriteLine("\nPosade koje nisu dodijeljene niti jednom letu:\n");
            Console.WriteLine("\n{0, -16} {1, -16} {2}", "Redni broj" ,"Naziv posade", "Lista clanova");

            int counter = 0;

            foreach (var aircrew in available_aircrews)
            {
                string members = string.Join(", ", aircrew.Members.Select(m => m.Role + " " + m.GetLastName()));
                Console.WriteLine("{0, -16} {1, -16} {2}", ++counter, aircrew.Name, members);
            }

            Console.Write("\nOdaberite redni broj posade koju želite dodijeliti letu\n");

            while (true)
            {
                Console.Write("\nOdabir: ");

                if (int.TryParse(Console.ReadLine(), out int index) && (index > 0 && index <= available_aircrews.Count))
                {
                    Console.WriteLine("\nOdabrana je posada {0}", available_aircrews[index - 1].Name);
                    return available_aircrews[index - 1];
                }

                else
                {
                    Console.WriteLine("Unos nije valjan");
                    continue;
                }
            }
        }

        public static bool CheckInput()
        {
            string input = "";

            while (true)
            {
                input = Console.ReadLine()?.Trim().ToLower() ?? "";

                if (input == "da" || input == "ne")
                    break;

                else
                {
                    Console.Write("Unos nije valjan, ponovite upis (DA/NE) ");
                    continue;
                }
            }
;
            Console.WriteLine("");

            if (input == "da")
                return true;

            else return false;
        }
    }
}
