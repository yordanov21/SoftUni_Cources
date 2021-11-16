using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Data.SqlTypes;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext context = new SoftUniContext();

            //print problem 3
            //string resultProblem3 = GetEmployeesFullInformation(context);
            //Console.WriteLine(resultProblem3);
            //Console.WriteLine(new string('-', 100));
            //Console.WriteLine();

            //print problem 4
            //string resultProblem4 = GetEmployeesWithSalaryOver50000(context);
            //Console.WriteLine(resultProblem4);
            //Console.WriteLine(new string('-', 100));
            //Console.WriteLine();

            //print problem 5
            //string resultProblem5 = GetEmployeesFromResearchAndDevelopment(context);
            //Console.WriteLine(resultProblem5);
            //Console.WriteLine(new string('-', 100));
            //Console.WriteLine();

            //print problem 6
            //string resultProblem6 = AddNewAddressToEmployee(context);
            //Console.WriteLine(resultProblem6);
            //Console.WriteLine(new string('-', 100));
            //Console.WriteLine();

            //print problem 7
            //string resultProblem7 = GetEmployeesInPeriod(context);
            //Console.WriteLine(resultProblem7);
            //Console.WriteLine(new string('-', 100));
            //Console.WriteLine();

            //print problem 8
            //string resultProblem8 = GetAddressesByTown(context);
            //Console.WriteLine(resultProblem8);
            //Console.WriteLine(new string('-', 100));
            //Console.WriteLine();

            //print problem 9
            //string resultProblem9 = GetEmployee147(context);
            //Console.WriteLine(resultProblem9);
            //Console.WriteLine(new string('-', 100));
            //Console.WriteLine();

            //print problem 10
            //string resultProblem10 = GetDepartmentsWithMoreThan5Employees(context);
            //Console.WriteLine(resultProblem10);
            //Console.WriteLine(new string('-', 100));
            //Console.WriteLine();

            //print problem 11
            //string resultProblem11 = GetLatestProjects(context);
            //Console.WriteLine(resultProblem11);
            //Console.WriteLine(new string('-', 100));
            //Console.WriteLine();

            //print problem 12
            //string resultProblem12 = IncreaseSalaries(context);
            //Console.WriteLine(resultProblem12);
            //Console.WriteLine(new string('-', 100));
            //Console.WriteLine();

            //print problem 13
            //string resultProblem13 = GetEmployeesByFirstNameStartingWithSa(context);
            //Console.WriteLine(resultProblem13);
            //Console.WriteLine(new string('-', 100));
            //Console.WriteLine();

            //print problem 14
            string resultProblem14 = DeleteProjectById(context);
            Console.WriteLine(resultProblem14);
            Console.WriteLine(new string('-', 100));
            Console.WriteLine();
        }

        //problem 03
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var employees = context
                .Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.MiddleName,
                    e.JobTitle,
                    e.Salary
                })
                .ToList();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:f2}");
            }
            return sb.ToString().TrimEnd();
        }

        //problem 04
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var employees = context
                .Employees
                .Where(e => e.Salary > 50000)
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ToList();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //problem 5
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context
                .Employees
                .Where(e => e.Department.Name == "Research and Development")
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    DepartmentName = e.Department.Name,
                    e.Salary
                })
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .ToList();
            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.DepartmentName} - ${employee.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //problem 6
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            //create new address, it is a local object at the momment.
            Address newAddress = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            Employee employeeNakov = context
                .Employees
                .First(e => e.LastName == "Nakov");

            context.Addresses.Add(newAddress); //Can be omitted, EF will create it!
            employeeNakov.Address = newAddress;

            context.SaveChanges(); //Save the changes in the DB 

            var addreses = context
                .Employees
                .OrderByDescending(e => e.AddressId)  //order before select because I don't  want to take AddresID
                .Take(10)                             // take 10, because I don't want to take all Addresses. I need only first 10
                .Select(e => e.Address.AddressText)
                .ToList();


            foreach (var address in addreses)
            {
                sb.AppendLine(address);
            }

            return sb.ToString().TrimEnd();
        }

        //problem 7
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context
                .Employees
                .Where(e => e.EmployeesProjects
                    .Any(ep => ep.Project.StartDate.Year >= 2001 &&
                               ep.Project.StartDate.Year <= 2003))
                .Take(10)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    ManagerFirstName = e.Manager.FirstName,
                    ManagerLastName = e.Manager.LastName,
                    Projects = e.EmployeesProjects
                    .Select(ep => new
                    {
                        ProjectName = ep.Project.Name,
                        StartDate = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt",
                        CultureInfo.InvariantCulture),
                        EndDate = ep.Project.EndDate.HasValue ?
                        ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt",
                         CultureInfo.InvariantCulture) : "not finished"
                    })
                    .ToList()
                })
                .ToList();

            foreach (var empl in employees)
            {
                sb.AppendLine($"{empl.FirstName} {empl.LastName} - Manager: {empl.ManagerFirstName} {empl.ManagerLastName}");

                foreach (var project in empl.Projects)
                {
                    sb.AppendLine($"--{project.ProjectName} - {project.StartDate} - {project.EndDate}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        //problem 8
        public static string GetAddressesByTown(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var addreses = context
                .Addresses
                .Select(a => new
                {
                    addresseText = a.AddressText,
                    townName = a.Town.Name,
                    employeesCount = a.Employees.Count()
                })
                .OrderByDescending(a => a.employeesCount)
                .ThenBy(a => a.townName)
                .ThenBy(a => a.addresseText)
                .Take(10)
                .ToList(); ;

            foreach (var address in addreses)
            {
                sb.AppendLine($"{address.addresseText}, {address.townName} - {address.employeesCount} employees");
            }
            return sb.ToString().TrimEnd();
        }

        //problem 9
        public static string GetEmployee147(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employee147 = context
                .Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    Projects = e.EmployeesProjects
                        .Select(ep => ep.Project.Name)
                        .OrderBy(pn => pn)
                        .ToList()
                })
                .Single();

            sb.AppendLine($"{employee147.FirstName} {employee147.LastName} - {employee147.JobTitle}");
            foreach (string projectName in employee147.Projects)
            {
                sb.AppendLine(projectName);
            }

            return sb.ToString().TrimEnd();
        }

        //problem 10
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var departments = context
                .Departments
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .ThenBy(d => d.Name)
                .Select(d => new
                {
                    name = d.Name,
                    managerFirsName = d.Manager.FirstName,
                    managerLastname = d.Manager.LastName,
                    employees = d.Employees
                        .Select(e => new
                        {
                            employeeFirstname = e.FirstName,
                            employeeLastname = e.LastName,
                            employeeJobTitle = e.JobTitle
                        }
                            )
                        .OrderBy(e => e.employeeFirstname)
                        .ThenBy(e => e.employeeLastname)
                        .ToList()
                })
                .ToList();

            foreach (var deparment in departments)
            {
                sb.AppendLine($"{deparment.name} - {deparment.managerFirsName}  {deparment.managerLastname}");

                foreach (var employee in deparment.employees)
                {
                    sb.AppendLine($"{employee.employeeFirstname} {employee.employeeLastname} - {employee.employeeJobTitle}");
                }
            }


            return sb.ToString().TrimEnd();
        }

        //problem 11
        public static string GetLatestProjects(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var projects = context.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .Select(p => new
                {
                    p.Name,
                    p.Description,
                    startdate = p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                })
                .OrderBy(p => p.Name)
                .ToList();

            foreach (var project in projects)
            {
                sb.AppendLine(project.Name);
                sb.AppendLine(project.Description);
                sb.AppendLine(project.startdate);
            }

            return sb.ToString().TrimEnd();
        }

        //problem 12
        public static string IncreaseSalaries(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
                .Where(e => e.Department.Name == "Engineering" ||
                            e.Department.Name == "Tool Design" ||
                            e.Department.Name == "Marketing" ||
                            e.Department.Name == "Information Services")
                .ToList();

            foreach (var employee in employees)
            {
                employee.Salary *= 1.12m;
                context.SaveChanges();
            }

            employees=  employees
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:f2})");
            }

            return sb.ToString().TrimEnd();
        }

        //problem 13
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employees = context
                .Employees
                .Where(e => e.FirstName.StartsWith("Sa"))
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();

            var sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary:F2})");
            }

            return sb.ToString().TrimEnd();
        }

        //problem 14
        public static string DeleteProjectById(SoftUniContext context)
        {
            var targetProject = context.Projects.FirstOrDefault(p => p.ProjectId == 2);
            var targetEmployeeProject = context.EmployeesProjects.FirstOrDefault(ep => ep.ProjectId == 2);

            context.EmployeesProjects.Remove(targetEmployeeProject);
            context.Projects.Remove(targetProject);

            context.SaveChanges();

            var projects = context.Projects
                .Select(e => new
                {
                    e.Name
                })
                .Take(10)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var project in projects)
            {
                sb.AppendLine(project.Name);
            }

            return sb.ToString().TrimEnd();

        }

        //problem 15
        public static string RemoveTown(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.Address.Town.Name == "Seattle")
                .ToList();

            foreach (var employee in employees)
            {
                employee.AddressId = null;
                context.SaveChanges();
            }

            var addresses = context.Addresses
                .Where(a => a.Town.Name == "Seattle")
                .ToList();

            int count = addresses.Count();

            foreach (var address in addresses)
            {
                context.Addresses.Remove(address);
                context.SaveChanges();
            }

            var towns = context.Towns
                .Where(t => t.Name == "Seattle")
                .ToList();

            foreach (var town in towns)
            {
                context.Towns.Remove(town);
                context.SaveChanges();
            }

            return $"{count} addresses in Seattle were deleted";
        }
    }
}
