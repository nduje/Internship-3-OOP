namespace Internship_3_OOP.Classes
{
    internal class Airplane
    {
        public Guid Id { get; private set; }
        public string Name { get; set; }
        public DateOnly ProductionYear { get; set; }
        public int TotalFlights { get; set; }
        public Dictionary<Enums.Classes, int> Capacities { get; set; }
        public int MaximumCapacity { get; set; }
        public int CurrentCapacity { get; set; }
        public static List<Airplane> Airplanes = new List<Airplane>();
        public DateTime Created { get; set; }
        public DateTime LastUpdated { get; set; }

        public Airplane(string name, DateOnly production_year, int total_flights, int standard_capacity, int business_capacity, int vip_capacity)
        {
            Id = Helper.GenerateGuid();
            Name = name;
            ProductionYear = production_year;
            TotalFlights = total_flights;
            Capacities = new Dictionary<Enums.Classes, int>
            {
                { Enums.Classes.Standard, standard_capacity },
                { Enums.Classes.Business, business_capacity },
                { Enums.Classes.VIP, vip_capacity }
            };
            MaximumCapacity = CalculateCapacity();
            CurrentCapacity = MaximumCapacity;
            Created = DateTime.Now;
            LastUpdated = DateTime.Now;
        }

        public Guid GetId()
        {
            return Id;
        }

        public int CalculateCapacity()
        {
            return Capacities[Enums.Classes.Standard] + Capacities[Enums.Classes.Business] + Capacities[Enums.Classes.VIP];
        }

        public static void ShowAirplanes()
        {
            Console.WriteLine("\n{0, -42} {1, -16} {2, -24} {3}", "ID", "Naziv", "Godina proizvodnje", "Broj letova");

            foreach (var airplane in Airplanes)
            {
                Console.WriteLine("{0, -42} {1, -16} {2, -24} {3}", airplane.Id, airplane.Name, airplane.ProductionYear.Year, airplane.TotalFlights);
            }

            Helper.PendingUser();
        }

        public static void CreateNewAirplane()
        {
            Console.WriteLine("\nDODAVANJE NOVOG AVIONA\n");

            string name = Helper.ValidateAirplaneName();
            DateOnly production_year = Helper.ValidateDate("proizvodnje");
            int total_flights = Helper.ValidateTotalFlights();
            int standard_capacity = Helper.ValidateCapacity(Enums.Classes.Standard);
            int business_capacity = Helper.ValidateCapacity(Enums.Classes.Business);
            int vip_capacity = Helper.ValidateCapacity(Enums.Classes.VIP);

            AddNewAirplane(name, production_year, total_flights, standard_capacity, business_capacity, vip_capacity);
        }

        public static void AddNewAirplane(string name, DateOnly production_year, int total_flights, int standard_capacity, int business_capacity, int vip_capacity)
        {
            Console.Write("Zelite li dovrsiti proces dodavanja aviona {0}? (DA/NE) ", name);

            if (Helper.CheckInput())
            {
                Airplanes.Add(new Airplane(name, production_year, total_flights, standard_capacity, business_capacity, vip_capacity));
                Console.WriteLine("Proces dodavanja aviona {0} je dovrsen\n", name);
            }

            else
            {
                Console.WriteLine("Proces dodavanja aviona {0} je prekinut\n", name);
            }

            Helper.PendingUser();

            return;
        }

        public static void SearchAirplaneById()
        {
            Console.WriteLine("\nPRETRAŽIVANJE AVIONA PO IDENTIFIKATORU\n");

            while (true)
            {
                Console.Write("Odaberite avion (unesite ID): ");

                if (!Guid.TryParse(Console.ReadLine(), out Guid id))
                {
                    Console.WriteLine("Unos nije valjan\n");
                    continue;
                }

                Airplane? airplane = Airplanes.Find(a => a.Id == id);

                if (airplane == null)
                {

                    Console.WriteLine("Avion s identifikatorom {0} ne postoji\n", id);
                    Helper.PendingUser();
                    return;
                }

                Console.WriteLine("\n| {0, -36} | {1, -16} | {2, -18} | {3, -11} |", "ID", "Naziv", "Godina proizvodnje", "Broj letova");
                Console.WriteLine("| {0, -36} | {1, -16} | {2, -18} | {3, -11} |\n", airplane.Id, airplane.Name, airplane.ProductionYear.Year, airplane.TotalFlights);

                Helper.PendingUser();

                return;
            }
        }

        public static void SearchAirplaneByName()
        {
            Console.WriteLine("\nPRETRAŽIVANJE AVIONA PO NAZIVU\n");

            while (true)
            {
                Console.Write("Odaberite avion(e) (unesite puni naziv): ");

                string? name = Console.ReadLine();

                if (string.IsNullOrEmpty(name) || !Helper.IsAirplaneNameValid(name))
                {
                    Console.WriteLine("Unos nije valjan\n");
                    continue;
                }

                List<Airplane> airplanes = Airplanes.Where(a => a.Name == name).ToList();

                if (airplanes.Count == 0)
                {
                    Console.WriteLine("Avion s nazivom {0} ne postoji\n", name);
                    Helper.PendingUser();
                    return;
                }

                Console.WriteLine("\n| {0, -36} | {1, -16} | {2, -18} | {3, -11} |", "ID", "Naziv", "Godina proizvodnje", "Broj letova");

                foreach (var airplane in airplanes)
                {
                    Console.WriteLine("| {0, -36} | {1, -16} | {2, -18} | {3, -11} |", airplane.Id, airplane.Name, airplane.ProductionYear.Year, airplane.TotalFlights);
                }

                Console.WriteLine("");

                Helper.PendingUser();

                return;
            }
        }

        public static void DeleteAirplaneById()
        {
            Console.WriteLine("\nBRISANJE AVIONA PO IDENTIFIKATORU\n");

            while (true)
            {
                Console.Write("Odaberite avion (unesite ID): ");

                if (!Guid.TryParse(Console.ReadLine(), out Guid id))
                {
                    Console.WriteLine("Unos nije valjan\n");
                    continue;
                }

                Airplane? airplane = Airplanes.Find(a => a.Id == id);

                if (airplane == null)
                {

                    Console.WriteLine("Avion s identifikatorom {0} ne postoji\n", id);
                    Helper.PendingUser();
                    return;
                }

                Console.Write("\nZelite li dovrsiti proces brisanja aviona {0} ({1})? (DA/NE) ", airplane.Name, airplane.Id);

                if (Helper.CheckInput())
                {
                    Airplanes.Remove(airplane);
                    Console.WriteLine("Proces brisanja aviona {0} ({1}) je dovrsen\n", airplane.Name, airplane.Id);
                }

                else
                {
                    Console.WriteLine("Proces brisanja aviona {0} ({1}) je prekinut\n", airplane.Name, airplane.Id);
                }

                Helper.PendingUser();

                return;
            }
        }

        public static void DeleteAirplaneByName()
        {
            Console.WriteLine("\nBRISANJE AVIONA PO NAZIVU\n");

            while (true)
            {
                Console.Write("Odaberite avion(e) (unesite puni naziv): ");

                string? name = Console.ReadLine();

                if (string.IsNullOrEmpty(name) || !Helper.IsAirplaneNameValid(name))
                {
                    Console.WriteLine("Unos nije valjan\n");
                    continue;
                }

                List<Airplane> airplanes = Airplanes.Where(a => a.Name == name).ToList();

                if (airplanes.Count == 0)
                {
                    Console.WriteLine("Avion s nazivom {0} ne postoji\n", name);
                    Helper.PendingUser();
                    return;
                }

                Console.Write("\nZelite li dovrsiti proces brisanja aviona {0} (ukupno: {1})? (DA/NE) ", name, airplanes.Count);

                if (Helper.CheckInput())
                {
                    foreach (var airplane in airplanes)
                    {
                        Airplanes.Remove(airplane);
                    }

                    Console.WriteLine("Proces brisanja aviona {0} (ukupno: {1}) je dovrsen\n", name, airplanes.Count);
                }

                else
                {
                    Console.WriteLine("Proces brisanja aviona {0} (ukupno: {1}) je prekinut\n", name, airplanes.Count);
                }

                Helper.PendingUser();

                return;
            }
        }
    }
}
