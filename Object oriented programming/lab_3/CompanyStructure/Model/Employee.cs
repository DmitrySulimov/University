namespace CompanyStructure.Model
{
    public class Employee : Person
    {
        public string Id { get; set; }
        public string Position { get; set; }
        public double Salary { get; set; }
        public Employee Supervisor { get; set; }

        public Employee(string name, string surname, string id, string position, double salary)
            : base(name, surname)
        {
            this.Id = id;
            this.Position = position;
            this.Salary = salary;
        }

        public override string ToString()
        {
            return $"{Id}: {Surname} {Name}, {Position} (salary: {Salary})";
        }
    }
}