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
        public int Capacity { get; set; }
        public static List<Flight> Flights = new List<Flight>();

        public Flight(string number, DateTime departureTime, DateTime arrivalTime, double distance, int capacity)
        {
            Id = Guid.NewGuid();
            Number = number;
            DepartureTime = departureTime;
            ArrivalTime = arrivalTime;
            Distance = distance;
            Duration = CalculateDuration();
            Capacity = capacity;
        }

        private TimeSpan CalculateDuration()
        {
            return ArrivalTime - DepartureTime;
        }
    }
}
