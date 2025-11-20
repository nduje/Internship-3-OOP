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

        public Flight(string number, DateTime departureTime, DateTime arrivalTime, double distance)
        {
            Id = Guid.NewGuid();
            Number = number;
            DepartureTime = departureTime;
            ArrivalTime = arrivalTime;
            Distance = distance;
            Duration = CalculateDuration();
        }

        private TimeSpan CalculateDuration()
        {
            return ArrivalTime - DepartureTime;
        }
    }
}
