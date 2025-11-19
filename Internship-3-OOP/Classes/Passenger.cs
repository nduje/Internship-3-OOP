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
    }
}
