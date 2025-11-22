using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_3_OOP.Classes
{
    internal class Aircrew
    {
        public string Name { get; set; }
        public List<Member> Members = new List<Member>();
        public static List<Aircrew> Aircrews = new List<Aircrew>();
        public DateTime Created { get; set; }
        public DateTime LastUpdated { get; set; }

        public Aircrew(string name) 
        {
            Name = name;
            Created = DateTime.Now;
            LastUpdated = DateTime.Now;
        }

        public static void ShowAircrew()
        {
            Console.WriteLine("\n{0, -16} {1}", "Naziv posade", "Lista clanova");

            foreach (var aircrew in Aircrews)
            {
                string members = string.Join(", ", aircrew.Members.Select(m => m.Role + " " + m.GetLastName()));
                Console.WriteLine("\n{0, -16} {1}", aircrew.Name, members);
                ShowMembers(aircrew);
            }

            Console.WriteLine("");
            Helper.PendingUser();
        }

        public static void ShowMembers(Aircrew aircrew)
        {
            Console.WriteLine("\n{0, -16} {1, -16} {2, -16} {3, -16} {4}", "Ime", "Prezime", "Pozicija", "Spol", "Datum rođenja");

            foreach (var member in aircrew.Members)
            {
                Console.WriteLine("{0, -16} {1, -16} {2, -16} {3, -16} {4}", member.GetFirstName(), member.GetLastName(), member.Role, member.Gender, member.GetBirthDate());
            }
        }

        public static void CreateNewAircrew()
        {
            Console.WriteLine("\nKREIRANJE NOVE POSADE\n");

            string name = Helper.ValidateAircrewName();

            Member? pilot = Helper.ValidatePilot();
            if (pilot == null) { Helper.UnavailableCrewMessage(); return; }

            Member? copilot = Helper.ValidateCopilot();
            if (copilot == null) { Helper.UnavailableCrewMessage(); return; }

            Member? attendant_1 = Helper.ValidateAttendant(new List<Member>());
            if (attendant_1 == null) { Helper.UnavailableCrewMessage(); return; }

            Member? attendant_2 = Helper.ValidateAttendant(new List<Member>() { attendant_1 });
            if (attendant_2 == null) { Helper.UnavailableCrewMessage(); return; }

            List<Member> members = new List<Member>()
            {
                pilot,
                copilot,
                attendant_1,
                attendant_2
            };

            AddNewAircrew(name, members);
        }

        static void AddNewAircrew(string name, List<Member> members)
        {
            Console.Write("\nZelite li dovrsiti proces kreiranja nove posade {0}? (DA/NE) ", name);

            if (Helper.CheckInput())
            {
                Aircrews.Add(new Aircrew(name)
                {
                    Members =
                    {
                        members[0],
                        members[1],
                        members[2],
                        members[3]
                    }
                }
                );

                Console.WriteLine("Proces kreiranja nove posade {0} je dovrsen\n", name);
            }

            else
            {
                Console.WriteLine("Proces kreiranja nove posade {0} je prekinut\n", name);
            }

            Helper.PendingUser();

            return;
        }
    }
}
