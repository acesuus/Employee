using System;

namespace Employee
{
    public class Employee
    {
       
        private string name;
        private int id;
        private float salary;


        public string Name
        {
            get => name;
            set => name = value ?? throw new ArgumentNullException(nameof(value), "Name cannot be null.");
        }

        public int Id
        {
            get => id;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("ID must be positive.");
                id = value;
            }
        }

        public float Salary
        {
            get => salary;
            protected set => salary = value;
        }

        public Employee(string name, int id)
        {
            Name = name;
            Id = id;
            Salary = 0;
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
        private const float FixedRate = 3000f;

        public RegularEmployee(string name, int id) : base(name, id) { }

        public float CalculateSalary()
        {
            Salary = FixedRate;
            return Salary;
        }
    }

    public class HourlyEmployee : Employee
    {
        private float hoursWorked;
        private float hourlyRate;

        public float HoursWorked
        {
            get => hoursWorked;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Hours worked must be positive.");
                hoursWorked = value;
            }
        }

        public float HourlyRate
        {
            get => hourlyRate;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Hourly rate must be positive.");
                hourlyRate = value;
            }
        }

        public HourlyEmployee(string name, int id, float hoursWorked, float hourlyRate) : base(name, id)
        {
            HoursWorked = hoursWorked;
            HourlyRate = hourlyRate;
        }

        public float CalculateSalary()
        {
            Salary = HoursWorked * HourlyRate;
            return Salary;
        }
    }

    public class CommissionEmployee : Employee
    {
        private float salesAmount;
        private float commissionRate;

        public float SalesAmount
        {
            get => salesAmount;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Sales amount must be positive.");
                salesAmount = value;
            }
        }

        public float CommissionRate
        {
            get => commissionRate;
            set
            {
                if (value < 0) 
                    throw new ArgumentException("Commission rate must be positive.");
                commissionRate = value;
            }
        }

        public CommissionEmployee(string name, int id, float salesAmount, float commissionRate) : base(name, id)
        {
            SalesAmount = salesAmount;
            CommissionRate = commissionRate;
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
            Console.WriteLine("Employee Salaries (before bonus):");

            RegularEmployee rEmployee = new("Alice", 1);
            rEmployee.CalculateSalary();
            Console.WriteLine($"Name: {rEmployee.Name}, ID: {rEmployee.Id}, Salary: {rEmployee.Salary}");

            HourlyEmployee hEmployee = new("Bob", 2, 160, 20.5f);
            hEmployee.CalculateSalary();
            Console.WriteLine($"Name: {hEmployee.Name}, ID: {hEmployee.Id}, Salary: {hEmployee.Salary}");

            CommissionEmployee cEmployee = new("Charlie", 3, 50000, 0.10f);
            cEmployee.CalculateSalary();
            Console.WriteLine($"Name: {cEmployee.Name}, ID: {cEmployee.Id}, Salary: {cEmployee.Salary}");

            Console.WriteLine();

            float threshold = 4000;
            float bonus = 1000.0f;

            rEmployee.ApplyBonus(threshold, bonus);
            hEmployee.ApplyBonus(threshold, bonus);
            cEmployee.ApplyBonus(threshold, bonus);

            Console.WriteLine("Employee Salaries (after bonus):");

            Console.WriteLine($"Name: {rEmployee.Name}, ID: {rEmployee.Id}, Salary: {rEmployee.Salary}");
            Console.WriteLine($"Name: {hEmployee.Name}, ID: {hEmployee.Id}, Salary: {hEmployee.Salary}");
            Console.WriteLine($"Name: {cEmployee.Name}, ID: {cEmployee.Id}, Salary: {cEmployee.Salary}");

            Console.WriteLine();

            float totalPayroll = rEmployee.Salary + hEmployee.Salary + cEmployee.Salary;
            Console.WriteLine($"Total Payroll: {totalPayroll}");
        }
    }
}
