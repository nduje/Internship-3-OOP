namespace Internship_3_OOP.Classes
{
    internal class Airplane
    {
        public Guid Id { get; private set; }
        public string Name { get; set; }
        public DateOnly ProductionYear { get; set; }
        public int TotalFlights { get; set; }
        public int Capacity { get; set; }
        public static List<Airplane> Airplanes = new List<Airplane>(); 
        
        public Airplane(string name, DateOnly production_year, int total_flights, int capacity)
        {
            Id = Helper.GenerateGuid();
            Name = name;
            ProductionYear = production_year;
            TotalFlights = total_flights;
            Capacity = capacity;
        }

        public Guid GetId()
        {
            return Id;
        }
    }
}
