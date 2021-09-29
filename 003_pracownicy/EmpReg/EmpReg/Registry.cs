using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpReg
{
    public class Registry
    {
        private Dictionary<int, Employee> _employees = new Dictionary<int, Employee>();

        private IEmployeeValidator[] _validators;

        public Registry(params IEmployeeValidator[] validators)
        {
            _validators = validators;
        }
        private void _validateEmployee(Employee employee)
        {
            foreach (var validator in _validators)
            {
                validator.BeforeAddition(employee);
            }
        }
        private void _postCreationValidate(Employee employee)
        {
            foreach (var validator in _validators)
            {
                validator.PostAddition(employee);
            }
        }
        private void _postDeletionValidate(Employee employee)
        {
            foreach (var validator in _validators)
            {
                validator.PostDeletion(employee);
            }
        }
        public List<Employee> GetEmployeeList()
        {
            var employees = _employees.Values.ToList();
            employees.Sort();
            return employees;
        }
        public List<Employee> GetEmployeeListByCity(string city)
        {
            return _employees.Values.ToList().Where(employee => employee.Address.City.Equals(city)).ToList();
        }
        public void AddEmployees(params Employee[] employees)
        {
            foreach (var employee in employees)
            {
                _validateEmployee(employee);
                _employees.Add(employee.EmployeeId, employee);
                _postCreationValidate(employee);
            }
        }
        public void DeleteEmployee(int employeeId)
        {
            if (_employees.ContainsKey(employeeId))
            {
                var employee = _employees[employeeId];
                _employees.Remove(employeeId);
                _postDeletionValidate(employee);
            }
            else
            {
                throw new Exception("Employee not found");
            }
        }
        
    }
}
