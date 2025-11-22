using Internship_3_OOP.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_3_OOP.Classes
{
    internal class Member : Person
    {
        public Genders Gender;
        public Roles Role;
        public static List<Member> Members = new List<Member>();

        public Member(string first_name, string last_name, DateOnly birth_date, Genders gender, Roles role) : base(first_name, last_name, birth_date)
        {
            Gender = gender;
            Role = role;
        }

        public static void CreateNewMember()
        {
            Console.WriteLine("\nDODAVANJE NOVE OSOBE\n");

            string first_name = Helper.ValidateName("ime");
            string last_name = Helper.ValidateName("prezime");
            DateOnly birth_date = Helper.ValidateBirthDate();
            Enums.Genders gender = Helper.ValidateGender();
            Enums.Roles role = Helper.ValidateRole();

            AddNewMember(first_name, last_name, birth_date, gender, role);
        }

        public static void AddNewMember(string first_name, string last_name, DateOnly birth_date, Enums.Genders gender, Enums.Roles role)
        {
            Console.Write("Zelite li dovrsiti proces dodavanja nove osobe {0} {1} ({2})? (DA/NE) ", first_name, last_name, role);

            if (Helper.CheckInput())
            {
                Members.Add(new Member(first_name, last_name, birth_date, gender, role));
                Console.WriteLine("Proces dodavanja nove osobe {0} {1} ({2}) je dovrsen\n", first_name, last_name, role);
            }

            else
            {
                Console.WriteLine("Proces dodavanja nove osobe {0} {1} ({2}) je prekinut\n", first_name, last_name, role);
            }

            Console.Write("Pritisnite bilo koju tipku za nastavak... ");
            Console.ReadKey(true);
            Console.Clear();

            return;
        }
    }
}
