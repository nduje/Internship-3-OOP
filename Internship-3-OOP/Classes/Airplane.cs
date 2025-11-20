namespace Internship_3_OOP.Classes
{
    internal class Airplane
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateOnly ProductionYear { get; set; }
        public int TotalFlights { get; set; }
        public static List<Airplane> Airplanes = new List<Airplane>(); 
        
        public Airplane(string name, DateOnly production_year, int total_flights)
        {
            Id = Helper.GenerateGuid();
            Name = name;
            ProductionYear = production_year;
            TotalFlights = total_flights;
        }
    }
}
