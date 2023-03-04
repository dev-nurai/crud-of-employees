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

            Program program = new Program();
            
            //Print Employee List
            foreach (Employee employee in employees)
            {
                employee.PrintToConsole();

            }

            Console.WriteLine("What do you want to perfrom?" +
                "\n A - Add Employee" +
                "\n E - Edit Employee" +
                "\n D - Delete Employee");
            string takeUserInput = Console.ReadLine().ToUpper();

            switch (takeUserInput)
            {
                case "A":
                    program.AddEmployees(repository);
                    break;
                case "E":
                    program.EditEmployee(repository);
                    break;
                case "D":
                    program.DeleteEmployee(repository);
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }

            foreach (Employee employee in employees)
            {
                employee.PrintToConsole();

            }





        }//Main Class

        public void AddEmployees(EmployeeRepository repository)
        {
            

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

            Employee AddNewEmployee = repository.AddEmployee(addEmployee);

        }

        public void EditEmployee(EmployeeRepository repository)
        {

            Console.WriteLine("Enter Employee ID");
            string UpdateId = Console.ReadLine();

            Guid guidIdToUpdate = new Guid(UpdateId);

            Employee UpdateEmployeeDetails = repository.Get(guidIdToUpdate);

            if (UpdateEmployeeDetails != null)
            {

                Console.WriteLine("Enter Employee Name");
                string UpdateEmployeeName = Console.ReadLine();
                UpdateEmployeeDetails.Name = UpdateEmployeeName;

                Console.WriteLine("Enter Employee Salary");
                int UpdateEmployeeSalary = int.Parse(Console.ReadLine());
                UpdateEmployeeDetails.Salary = UpdateEmployeeSalary;

                Console.WriteLine("Enter Employee Date of Joining");
                string UpdateEmployeeDateOfJoining = Console.ReadLine();
                UpdateEmployeeDetails.DateOfJoining = UpdateEmployeeDateOfJoining;
            }
            else
            {
                Console.WriteLine("Employee not found");
            }

            Employee updateEmployee = repository.UpdateEmployee(UpdateEmployeeDetails);

        }

        public void DeleteEmployee(EmployeeRepository repository)
        {


            Console.WriteLine("Enter Employee ID");
            string DeleteId = Console.ReadLine();

            Guid guidIdToDelete = new Guid(DeleteId);

            List<Employee> empList = repository.GetAll();

            Employee deleteEmployee = empList.Find(x =>x.EmployeeId == guidIdToDelete);

            repository.DeleteEmployee(deleteEmployee.EmployeeId);

        }



    }
}