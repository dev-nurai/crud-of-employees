using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Employees
{
    public class EmployeeRepository
    {
        private List<Employee> _employees = null;
        public EmployeeRepository()
        {
            _employees = new List<Employee>();
        }
        
        public void LoadDummyData()
        {
            
            Employee employee1 = new Employee() { EmployeeId = Guid.NewGuid(), Name = "Nurai", Salary = 30000, DateOfJoining = "6/1/2023" };
            Employee employee2 = new Employee() { EmployeeId = Guid.NewGuid(), Name = "Indu", Salary = 45000, DateOfJoining = "9/2/2020" };
            Employee employee3 = new Employee() { EmployeeId = Guid.NewGuid(), Name = "Kamlesh", Salary = 23000, DateOfJoining = "6/19/2018" };
            Employee employee4 = new Employee() { EmployeeId = Guid.NewGuid(), Name = "Rahul", Salary = 21000, DateOfJoining = "6/21/2021" };

            _employees.Add(employee1);
            _employees.Add(employee2);
            _employees.Add(employee3);
            _employees.Add(employee4);

        }

        public List<Employee> GetAll()
        {            
            return _employees;
        }

        public Employee AddEmployee(Employee employee)
        {

            employee.EmployeeId = Guid.NewGuid();
            _employees.Add(employee);
            return employee;
        }
        
        //public void UpdateEmployee()
        //{
        //    Console.WriteLine("Enter Employee Id");
        //    int UpdateEmployeeId = int.Parse(Console.ReadLine());

        //    //This is wrong??
        //    EmployeeRepository employeeRepository = new EmployeeRepository();
        //    employeeRepository.LoadDummyData(); //Load existing data [Dynamically added data?]
        //    List<Employee> employees = employeeRepository.GetAll();
            
            
        //    //LoadDummyData();
        //    //List<Employee> employees1 = GetAll();

        //    Employee updateEmployee = employees.Find(x=> x.EmployeeId == UpdateEmployeeId);
        //    if(updateEmployee != null)
        //    {
        //        Console.WriteLine("Enter Employee Name");
        //        string UpdateEmployeeName = Console.ReadLine();
        //        updateEmployee.Name = UpdateEmployeeName;

        //        Console.WriteLine("Enter Employee Salary");
        //        int UpdateEmployeeSalary = int.Parse(Console.ReadLine());
        //        updateEmployee.Salary = UpdateEmployeeSalary;

        //        Console.WriteLine("Enter Employee Date of Joining");
        //        string UpdateEmployeeDateOfJoining = Console.ReadLine();
        //        updateEmployee.DateOfJoining = UpdateEmployeeDateOfJoining;
        //    }
        //    else
        //    {
        //        Console.WriteLine("Employee not found.");
        //    }

        //    var indexOfEmployee = _employees.FindIndex(x=> x.EmployeeId == UpdateEmployeeId);
        //    _employees[indexOfEmployee] = updateEmployee;
            
        //}


    }


}
