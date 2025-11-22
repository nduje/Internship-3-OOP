namespace Internship_3_OOP.Classes
{
    internal class Passenger : Person
    {
        string Email { get; set; }
        string Password { get; set; }
        public static List<Passenger> Passengers = new List<Passenger>();
        public static Passenger? SignedPassenger {  get; set; }

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
                Passenger.Passengers.Add(new Passenger(first_name, last_name, birth_date, email, password));
                Console.WriteLine("Proces registracije je dovrsen\n");
            }

            else
            {
                Console.WriteLine("Proces registracije je prekinut\n");
            }

            Helper.PendingUser();

            return;
        }
    }
}
