using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Employees
{
    public class Employee
    {
        public Guid EmployeeId { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public string DateOfJoining { get; set; }

        public void PrintToConsole()
        {           
                Console.WriteLine($"Id = {this.EmployeeId}, Name = {this.Name}, Salary = {this.Salary}," +
                    $" Date of Joining = {this.DateOfJoining}");

            //Every Employee object has their own property and method.

        }
    }   
}
