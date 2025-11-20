namespace Internship_3_OOP.Classes
{
    internal class Person
    {
        protected string FirstName { get; set; }
        protected string LastName { get; set; }
        protected DateOnly BirthDate { get; set; }
        protected Guid Id { get; private set; }

        protected Person(string first_name, string last_name, DateOnly birth_date)
        {
            FirstName = first_name;
            LastName = last_name;
            BirthDate = birth_date;
            Id = Helper.GenerateGuid();
        }

        public string GetFirstName()
        {
            return FirstName;
        }

        public string GetLastName()
        {
            return LastName;
        }

        public DateOnly GetBirthDate()
        {
            return BirthDate;
        }

        public Guid GetId()
        {
            return Id;
        }
    }
}
