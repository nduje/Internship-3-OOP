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
        public Airplane Airplane { get; set; }
        public Aircrew Aircrew { get; set; }


        public Flight(string number, DateTime departureTime, DateTime arrivalTime, double distance, Airplane airplane, Aircrew aircrew)
        {
            Id = Guid.NewGuid();
            Number = number;
            DepartureTime = departureTime;
            ArrivalTime = arrivalTime;
            Distance = distance;
            Duration = CalculateDuration();
            Airplane = airplane;
            Aircrew = aircrew;
        }

        private TimeSpan CalculateDuration()
        {
            return ArrivalTime - DepartureTime;
        }
    }
}
