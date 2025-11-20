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
        Genders Gender;
        Roles Role;
        public static List<Member> Members = new List<Member>();

        public Member(string first_name, string last_name, DateOnly birth_date, Genders gender, Roles role) : base(first_name, last_name, birth_date)
        {
            Gender = gender;
            Role = role;
        }
    }
}
