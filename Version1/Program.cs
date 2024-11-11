using System.Reflection.Metadata;

namespace Employee
{

    public class Employee
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public float Salary = 0;

        public Employee(string name, int id)
        {

            Name = name;
            Id = id;
            

        }

        public float ApplyBonus(float threshold, float bonus)
        {
            

            if (Salary > threshold)
            {
                Salary += bonus;
            }

            return Salary;
        }
    }

    public class RegularEmployee : Employee
    {
        const float FixedRate = 3000f;

        public RegularEmployee(string name, int id) : base(name, id)
        {
            
        }

        public float CalculateSalary()
        {
            Salary = FixedRate;
            return Salary;
            
        }
    }

    public class HourlyEmployee : Employee
    {
        public float HoursWorked { get; set; }
        public float HourlyRate { get; set; }


        public HourlyEmployee(string name, int id, float hoursworked, float hourlyrate) : base(name, id)
        {
            HoursWorked = hoursworked;
            HourlyRate = hourlyrate;
        }


        public float CalculateSalary()
        {
            Salary = HoursWorked * HourlyRate;
            return Salary;
        }
    }

    public class CommissionEmployee : Employee
    {
        public float SalesAmount { get; set; }
        public float CommissionRate { get; set; }

        public CommissionEmployee(string name, int id, float salesamount, float commissionrate) : base(name, id)
        {
            SalesAmount = salesamount;
            CommissionRate = commissionrate;
        }

        public float CalculateSalary()
        {
            Salary = SalesAmount * CommissionRate;
            return Salary;
        }
    }



    class Program
    {
        static void Main(string[] args)

        {
            Console.WriteLine("Employee Salaries(before bonus):");
            RegularEmployee rEmployee = new ("Alice", 1);
            rEmployee.CalculateSalary();

            Console.WriteLine($"Name: {rEmployee.Name}, ID: {rEmployee.Id}, Salary: {rEmployee.Salary}");

            HourlyEmployee hEmployee = new ("Bob", 2, 160, 20.5f);
            hEmployee.CalculateSalary();
            Console.WriteLine($"Name: {hEmployee.Name}, ID: {hEmployee.Id}, Salary: {hEmployee.Salary}");

            CommissionEmployee cEmployee = new ("Charlie", 3, 50000, 0.10f);
            cEmployee.CalculateSalary();
            Console.WriteLine($"Name: {cEmployee.Name}, ID: {cEmployee.Id}, Salary: {cEmployee.Salary}");

            

            Console.WriteLine();
            float threshold = 4000;
            float bonus = 1000.0f;

            rEmployee.ApplyBonus( threshold, bonus );
            hEmployee.ApplyBonus( threshold, bonus );
            cEmployee.ApplyBonus( threshold, bonus );   

            Console.WriteLine("Employee Salaries(after bonus):");
            

            Console.WriteLine($"Name: {rEmployee.Name}, ID: {rEmployee.Id}, Salary: {rEmployee.Salary}");

            Console.WriteLine($"Name: {hEmployee.Name}, ID: {hEmployee.Id}, Salary: {hEmployee.Salary}");

            Console.WriteLine($"Name: {cEmployee.Name}, ID: {cEmployee.Id}, Salary: {cEmployee.Salary}");

            Console.WriteLine();
            double total = cEmployee.Salary + rEmployee.Salary + hEmployee.Salary;
            Console.WriteLine($"Total Payroll: {total}");
         







        }
    }
}
