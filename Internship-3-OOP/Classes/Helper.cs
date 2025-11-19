using System.Text.RegularExpressions;

namespace Internship_3_OOP.Classes
{
    public class Helper
    {
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
