using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_3_OOP.Classes
{
    internal class Menu
    {
        public static void ChooseFromMainMenu()
        {
            while (true)
            {
                Console.Write("\n1 - Putnici\n2 - Letovi\n3 - Avioni\n4 - Posada\n5 - Izlaz iz programa\n\nOdabir: ");

                char choice = Console.ReadKey().KeyChar;

                Console.WriteLine("");

                switch (choice)
                {
                    case '1':
                        ChooseFromPassengersMenu();
                        break;
                    case '2':
                        ChooseFromFlightsMenu();
                        break;
                    case '3':
                        ChooseFromAirplanesMenu();
                        break;
                    case '4':
                        ChooseFromAircrewMenu();
                        break;
                    case '5':
                        return;
                    default:
                        Console.WriteLine("Unos nije valjan");
                        break;
                }
            }
        }

        public static void ChooseFromPassengersMenu()
        {
            while (true)
            {
                Console.Write("\n1 - Registracija\n2 - Prijava\n3 - Povratak na prethodni izbornik\n\nOdabir: ");

                char choice = Console.ReadKey().KeyChar;

                Console.WriteLine("");

                switch (choice)
                {
                    case '1':
                        Passenger.RegisterNewPassenger();
                        break;
                    case '2':
                        Passenger.SignIn();
                        break;
                    case '3':
                        return;
                    default:
                        Console.WriteLine("Unos nije valjan");
                        break;
                }
            }
        }

        public static void ChooseFromSignedPassengersMenu()
        {
            while (true)
            {
                Console.Write("\n1 - Prikaz svih letova\n2 - Odabir leta\n3 - Pretraživanje letova\n4 - Otkazivanje leta\n5 - Povratak na prethodni izbornik\n\nOdabir: ");

                char choice = Console.ReadKey().KeyChar;

                Console.WriteLine("");

                switch (choice)
                {
                    case '1':
                        break;
                    case '2':
                        break;
                    case '3':
                        break;
                    case '4':
                        break;
                    case '5':
                        return;
                    default:
                        Console.WriteLine("Unos nije valjan");
                        break;
                }
            }
        }

        public static void ChooseFromFlightsMenu()
        {
            while (true)
            {
                Console.Write("\n1 - Prikaz svih letova\n2 - Dodavanje leta\n3 - Pretraživanje letova\n4 - Uređivanje leta\n5 - Brisanje leta\n6 - Povratak na prethodni izbornik\n\nOdabir: ");

                char choice = Console.ReadKey().KeyChar;

                Console.WriteLine("");

                switch (choice)
                {
                    case '1':
                        Flight.ShowFlights();
                        break;
                    case '2':
                        Flight.CreateNewFlight();
                        break;
                    case '3':
                        ChooseFromSearchFlightsMenu();
                        break;
                    case '4':
                        Flight.EditFlight();
                        break;
                    case '5':
                        Flight.DeleteFlight();
                        break;
                    case '6':
                        return;
                    default:
                        Console.WriteLine("Unos nije valjan");
                        break;
                }
            }
        }

        public static void ChooseFromSearchFlightsMenu()
        {
            while (true)
            {
                Console.Write("\nPretraživanje letova:\na - Po ID-u\nb - Po nazivu\n\nOdabir: ");

                char choice = Console.ReadKey().KeyChar;

                Console.WriteLine("");

                switch (choice)
                {
                    case 'a':
                        Flight.SearchFlightById();
                        return;
                    case 'b':
                        Flight.SearchFlightByName();
                        return;
                    default:
                        Console.WriteLine("Unos nije valjan");
                        break;
                }
            }
        }

        public static void ChooseFromAirplanesMenu()
        {
            while (true)
            {
                Console.Write("\n1 - Prikaz svih aviona\n2 - Dodavanje novog aviona\n3 - Pretraživanje aviona\n4 - Brisanje aviona\n5 - Povratak na glavni izbornik\n\nOdabir: ");

                char choice = Console.ReadKey().KeyChar;

                Console.WriteLine("");

                switch (choice)
                {
                    case '1':
                        Airplane.ShowAirplanes();
                        break;
                    case '2':
                        Airplane.CreateNewAirplane();
                        break;
                    case '3':
                        ChooseFromSearchAirplanesMenu();
                        break;
                    case '4':
                        ChooseFromDeleteAirplanesMenu();
                        break;
                    case '5':
                        return;
                    default:
                        Console.WriteLine("Unos nije valjan");
                        break;
                }
            }
        }

        public static void ChooseFromSearchAirplanesMenu()
        {
            while (true)
            {
                if (!Airplane.Airplanes.Any())
                {
                    Console.WriteLine("Ne postoji niti jedan avion u memoriji\n");
                    break;
                }

                Console.Write("\nPretraživanje aviona:\na - Po ID-u\nb - Po nazivu\n\nOdabir: ");

                char choice = Console.ReadKey().KeyChar;

                Console.WriteLine("");

                switch (choice)
                {
                    case 'a':
                        Airplane.SearchAirplaneById();
                        return;
                    case 'b':
                        Airplane.SearchAirplaneByName();
                        return;
                    default:
                        Console.WriteLine("Unos nije valjan");
                        break;

                }
            }
        }

        public static void ChooseFromDeleteAirplanesMenu()
        {
            while (true)
            {
                Console.Write("\nBrisanje aviona:\na - Po ID-u\nb - Po nazivu\n\nOdabir: ");

                char choice = Console.ReadKey().KeyChar;

                Console.WriteLine("");

                switch (choice)
                {
                    case 'a':
                        Airplane.DeleteAirplaneById();
                        return;
                    case 'b':
                        Airplane.DeleteAirplaneByName();
                        return;
                    default:
                        Console.WriteLine("Unos nije valjan");
                        break;
                }
            }
        }

        public static void ChooseFromAircrewMenu()
        {
            while (true)
            {
                Console.Write("\n1 - Prikaz svih posada\n2 - Kreiranje nove posade\n3 - Dodavanje nove osobe\n4 - Povratak na prethodni izbornik\n\nOdabir: ");

                char choice = Console.ReadKey().KeyChar;

                Console.WriteLine("");

                switch (choice)
                {
                    case '1':
                        Aircrew.ShowAircrew();
                        break;
                    case '2':
                        Aircrew.CreateNewAircrew();
                        break;
                    case '3':
                        Member.CreateNewMember();
                        break;
                    case '4':
                        return;
                    default:
                        Console.WriteLine("Unos nije valjan");
                        break;
                }
            }
        }
    }
}
