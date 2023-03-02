using System.Security.Cryptography.X509Certificates;
using System.Xml;

namespace CRUD_Employees
{
    internal class Program
    {
        static void Main()
        {

            EmployeeRepository repository = new EmployeeRepository();
            repository.LoadDummyData();
            List<Employee> employees = repository.GetAll();

            foreach (Employee employee in employees)
            {
                employee.PrintToConsole();
                
            }

            
            
           


        }//Main Class

        public void AddEmployees()
        {
            EmployeeRepository repository = new EmployeeRepository();
            
            Console.WriteLine("Enter Employee Name");
            string AddNewName = Console.ReadLine();

            Console.WriteLine("Enter Employee Salary");
            int AddNewSalary = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Employee Date of Joining");
            string AddNewDateOfJoining = Console.ReadLine();

            Employee addEmployee = new Employee()
            {
                
                Name = AddNewName,
                Salary = AddNewSalary,
                DateOfJoining = AddNewDateOfJoining
            };

            var printNew = repository.AddEmployee(addEmployee);

            //printNew.PrintToConsole(); Just to check the add function;

        }

        


    }
}