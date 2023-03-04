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

        public Employee Get(Guid guid)
        {
            return _employees.FirstOrDefault(x => x.EmployeeId == guid);
        }

        public Employee AddEmployee(Employee employee)
        {

            employee.EmployeeId = Guid.NewGuid();            
            _employees.Add(employee);
            return employee;
        }

        public Employee UpdateEmployee(Employee employee)
        {

            var oldEmployee = _employees.FirstOrDefault(x => x.EmployeeId == employee.EmployeeId);
            oldEmployee.Name = employee.Name;
            oldEmployee.Salary = employee.Salary;
            oldEmployee.DateOfJoining = employee.DateOfJoining;
            return oldEmployee;
        }

        public void DeleteEmployee(Guid employeeId)
        {
            Employee deleteEmp = _employees.Find(x => x.EmployeeId == employeeId);
            if(deleteEmp != null)
            {
                _employees.Remove(deleteEmp);
            };
        }

    }


}
