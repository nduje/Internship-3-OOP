namespace Internship_3_OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("APLIKACIJA ZA UPRAVLJANJE AERODROMOM");
            chooseFromMainMenu();
        }

        static void chooseFromMainMenu()
        {
            bool isOver = true;

            while (isOver)
            {
                Console.WriteLine("");

                showMainMenu();

                Console.Write("Odabir: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            chooseFromPassengersMenu();
                            break;
                        case 2:
                            chooseFromFlightsMenu();
                            break;
                        case 3:
                            chooseFromAirplanesMenu();
                            break;
                        case 4:
                            chooseFromAircrewMenu();
                            break;
                        case 5:
                            isOver = false;
                            break;
                        default:
                            Console.WriteLine("Unos nije valjan");
                            break;
                    }
                }

                else
                {
                    Console.WriteLine("Unos nije valjan");
                }
            }
        }

        static void showMainMenu()
        {
            Console.WriteLine("1 - Putnici");
            Console.WriteLine("2 - Letovi");
            Console.WriteLine("3 - Avioni");
            Console.WriteLine("4 - Posada");
            Console.WriteLine("5 - Izlaz iz programa");
            Console.WriteLine("");
        }

        static void chooseFromPassengersMenu()
        {
            bool isOver = true;

            while (isOver)
            {
                Console.WriteLine("");

                showPassengersMenu();

                Console.Write("Odabir: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            break;
                        case 2:
                            chooseFromSignedPassengersMenu();
                            break;
                        case 3:
                            isOver = false;
                            break;
                        default:
                            Console.WriteLine("Unos nije valjan");
                            break;
                    }
                }

                else
                {
                    Console.WriteLine("Unos nije valjan");
                }
            }
        }

        static void showPassengersMenu()
        {
            Console.WriteLine("1 - Registracija");
            Console.WriteLine("2 - Prijava");
            Console.WriteLine("3 - Povratak na prethodni izbornik");
            Console.WriteLine("");
        }

        static void chooseFromSignedPassengersMenu()
        {
            bool isOver = true;

            while (isOver)
            {
                Console.WriteLine("");

                showSignedPassengersMenu();

                Console.Write("Odabir: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            break;
                        case 2:
                            break;
                        case 3:
                            chooseFromSearchFlightsMenu();
                            break;
                        case 4:
                            break;
                        case 5:
                            isOver = false;
                            break;
                        default:
                            Console.WriteLine("Unos nije valjan");
                            break;
                    }
                }

                else
                {
                    Console.WriteLine("Unos nije valjan");
                }
            }
        }

        static void showSignedPassengersMenu()
        {
            Console.WriteLine("1 - Prikaz svih letova");
            Console.WriteLine("2 - Odabir leta");
            Console.WriteLine("3 - Pretraživanje letova");
            Console.WriteLine("4 - Otkazivanje leta");
            Console.WriteLine("5 - Povratak na prethodni izbornik");
            Console.WriteLine("");
        }

        static void chooseFromSearchFlightsMenu()
        {
            bool isOver = true;

            while (isOver)
            {
                Console.WriteLine("");

                showSearchFlightsMenu();

                Console.Write("Odabir: ");

                if (char.TryParse((Console.ReadLine() ?? "").ToLower(), out char choice))
                {
                    switch (choice)
                    {
                        case 'a':
                            isOver = false;
                            break;
                        case 'b':
                            isOver = false;
                            break;
                        default:
                            Console.WriteLine("Unos nije valjan");
                            break;
                    }
                }

                else
                {
                    Console.WriteLine("Unos nije valjan");
                }
            }
        }

        static void showSearchFlightsMenu()
        {
            Console.WriteLine("Pretraživanje letova:");
            Console.WriteLine("a - Po ID-u");
            Console.WriteLine("b - Po nazivu");
            Console.WriteLine("");
        }

        static void chooseFromFlightsMenu()
        {
            bool isOver = true;

            while (isOver)
            {
                Console.WriteLine("");

                showFightsMenu();

                Console.Write("Odabir: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            break;
                        case 2:
                            break;
                        case 3:
                            chooseFromSearchFlightsMenu();
                            break;
                        case 4:
                            break;
                        case 5:
                            break;
                        case 6:
                            isOver = false;
                            break;
                        default:
                            Console.WriteLine("Unos nije valjan");
                            break;
                    }
                }

                else
                {
                    Console.WriteLine("Unos nije valjan");
                }
            }
        }

        static void showFightsMenu()
        {
            Console.WriteLine("1 - Prikaz svih letova");
            Console.WriteLine("2 - Dodavanje leta");
            Console.WriteLine("3 - Pretraživanje letova");
            Console.WriteLine("4 - Uređivanje leta");
            Console.WriteLine("5 - Brisanje leta");
            Console.WriteLine("6 - Povratak na prethodni izbornik");
            Console.WriteLine("");
        }

        static void chooseFromAirplanesMenu()
        {
            bool isOver = true;

            while (isOver)
            {
                Console.WriteLine("");

                showAirplanesMenu();

                Console.Write("Odabir: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            break;
                        case 2:
                            break;
                        case 3:
                            chooseFromSearchAirplanesMenu();
                            break;
                        case 4:
                            chooseFromDeleteAirplanesMenu();
                            break;
                        case 5:
                            isOver = false;
                            break;
                        default:
                            Console.WriteLine("Unos nije valjan");
                            break;
                    }
                }

                else
                {
                    Console.WriteLine("Unos nije valjan");
                }
            }
        }

        static void showAirplanesMenu()
        {
            Console.WriteLine("1 - Prikaz svih aviona");
            Console.WriteLine("2 - Dodavanje novog aviona");
            Console.WriteLine("3 - Pretraživanje aviona");
            Console.WriteLine("4 - Brisanje aviona");
            Console.WriteLine("5 - Povratak na prethodni izbornik");
            Console.WriteLine("");
        }

        static void chooseFromSearchAirplanesMenu()
        {
            bool isOver = true;

            while (isOver)
            {
                Console.WriteLine("");

                showSearchAirplanesMenu();

                Console.Write("Odabir: ");

                if (char.TryParse((Console.ReadLine() ?? "").ToLower(), out char choice))
                {
                    switch (choice)
                    {
                        case 'a':
                            isOver = false;
                            break;
                        case 'b':
                            isOver = false;
                            break;
                        default:
                            Console.WriteLine("Unos nije valjan");
                            break;
                    }
                }

                else
                {
                    Console.WriteLine("Unos nije valjan");
                }
            }
        }

        static void showSearchAirplanesMenu()
        {
            Console.WriteLine("Pretraživanje aviona:");
            Console.WriteLine("a - Po ID-u");
            Console.WriteLine("b - Po nazivu");
            Console.WriteLine("");
        }

        static void chooseFromDeleteAirplanesMenu()
        {
            bool isOver = true;

            while (isOver)
            {
                Console.WriteLine("");

                showDeleteAirplanesMenu();

                Console.Write("Odabir: ");

                if (char.TryParse((Console.ReadLine() ?? "").ToLower(), out char choice))
                {
                    switch (choice)
                    {
                        case 'a':
                            isOver = false;
                            break;
                        case 'b':
                            isOver = false;
                            break;
                        default:
                            Console.WriteLine("Unos nije valjan");
                            break;
                    }
                }

                else
                {
                    Console.WriteLine("Unos nije valjan");
                }
            }
        }

        static void showDeleteAirplanesMenu()
        {
            Console.WriteLine("Brisanje aviona:");
            Console.WriteLine("a - Po ID-u");
            Console.WriteLine("b - Po nazivu");
            Console.WriteLine("");
        }

        static void chooseFromAircrewMenu()
        {
            bool isOver = true;

            while (isOver)
            {
                Console.WriteLine("");

                showAircrewMenu();

                Console.Write("Odabir: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            isOver = false;
                            break;
                        default:
                            Console.WriteLine("Unos nije valjan");
                            break;
                    }
                }

                else
                {
                    Console.WriteLine("Unos nije valjan");
                }
            }
        }

        static void showAircrewMenu()
        {
            Console.WriteLine("1 - Prikaz svih posada");
            Console.WriteLine("2 - Kreiranje nove posade");
            Console.WriteLine("3 - Dodavanje nove osobe");
            Console.WriteLine("4 - Povratak na prethodni izbornik");
            Console.WriteLine("");
        }
    }
}
