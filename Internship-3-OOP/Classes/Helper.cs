using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Internship_3_OOP.Classes
{
    internal class Helper
    {
        public static void Initialize()
        {
            InitializeFlights();
            InitializeAirplanes();
        }

        public static void InitializeFlights()
        {
            Flight.Flights.Add(new Flight("LH256", new DateTime(2025, 11, 19, 14, 30, 0), new DateTime(2025, 11, 19, 18, 45, 0), 1200));
            Flight.Flights.Add(new Flight("AA100", new DateTime(2025, 11, 20, 9, 0, 0), new DateTime(2025, 11, 20, 11, 30, 0), 800));
        }

        public static void InitializeAirplanes()
        {
            Airplane.Airplanes.Add(new Airplane("Boeing 737", new DateOnly(2015, 6, 12), 1200));
            Airplane.Airplanes.Add(new Airplane("Airbus A320", new DateOnly(2018, 3, 25), 950));
            Airplane.Airplanes.Add(new Airplane("Embraer E195", new DateOnly(2020, 11, 5), 600));
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
