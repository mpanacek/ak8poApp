using SecretaryApp.Domain.Models;
using SecretaryApp.Domain.Services;
using SecretaryApp.EntityFramework.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            IDataService<Employee> employeeService = new GenericDataService<Employee>(new SecretaryApp.EntityFramework.SecretaryAppDbContextFactory());
            List<Employee> employees = employeeService.GetAll().Result.ToList();
            Console.WriteLine(employees.First<Employee>().FullName);
            
        }
    }
}
