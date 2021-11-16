namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    using Data;
    using System.Text;
    using System.Xml.Serialization;
    using TeisterMask.DataProcessor.ImportDto;
    using System.IO;
    using TeisterMask.Data.Models;
    using System.Globalization;
    using TeisterMask.Data.Models.Enums;
    using Newtonsoft.Json;
    using System.Linq;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            //with XML
            StringBuilder sb = new StringBuilder();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportProjectDto[]),
                new XmlRootAttribute("Projects"));

            List<Project> projects = new List<Project>();

            using (StringReader stringReader = new StringReader(xmlString))
            {
                ImportProjectDto[] projectDtos = (ImportProjectDto[])xmlSerializer.Deserialize(stringReader);

              
                //Validate Project
                foreach (var projectDto in projectDtos)
                {
                    if (!IsValid(projectDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    //validadion of OpenDate
                    DateTime projectOpenDate;
                    bool isProjectOpenDateValid = DateTime.TryParseExact(projectDto.OpenDate,
                        "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out projectOpenDate);

                    if (!isProjectOpenDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    //validadion of DueDate
                    DateTime? projectDueDate;
                    if (!String.IsNullOrEmpty(projectDto.DueDate))
                    {
                        DateTime projectDueDateValue;
                        bool isProjectDueDateValid = DateTime.TryParseExact(projectDto.DueDate,
                            "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out projectDueDateValue);

                        if (!isProjectDueDateValid)
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }

                        projectDueDate = projectDueDateValue;
                    }
                    else
                    {
                        //if I do not receve DueDate inXML
                        projectDueDate = null;
                    }

                    Project pr = new Project()
                    {
                        Name = projectDto.Name,
                        OpenDate = projectOpenDate,
                        DueDate = projectDueDate
                    };

                    //validate Tasks
                    foreach (var taskDto in projectDto.Tasks)
                    {
                        //Invalid name, open or due date, invalid enumeration values
                        if (!IsValid(taskDto))
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }

                        //validate correct DateTime Format
                        DateTime taskOpenDate;
                        bool isTaskOpenDateValid = DateTime.TryParseExact(taskDto.OpenDate,
                        "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out taskOpenDate);

                        if (!isTaskOpenDateValid)
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }

                        DateTime taskDueDate;
                        bool isTaskDueDateValid = DateTime.TryParseExact(taskDto.DueDate,
                        "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out taskDueDate);

                        if (!isTaskDueDateValid)
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }

                        if (taskOpenDate < projectOpenDate)
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }

                        if (projectDueDate.HasValue)  //because nullable type
                        {
                            if (taskDueDate > projectDueDate.Value)
                            {
                                sb.AppendLine(ErrorMessage);
                                continue;
                            }
                        }

                        pr.Tasks.Add(new Task()
                        {
                            Name = taskDto.Name,
                            OpenDate = taskOpenDate,
                            DueDate = taskDueDate,
                            ExecutionType = (ExecutionType)taskDto.ExecutionType,
                            LabelType = (LabelType)taskDto.LabelType
                        });
                       
                    }

                    projects.Add(pr);
                    sb.AppendLine(String.Format(SuccessfullyImportedProject, pr.Name, pr.Tasks.Count));
                }

                context.Projects.AddRange(projects);
                context.SaveChanges();

            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            //json
            StringBuilder sb = new StringBuilder();

            ImportEmployeeDto[] employeeDtos = JsonConvert.DeserializeObject<ImportEmployeeDto[]>(jsonString);

            List<Employee> employees = new List<Employee>();

            foreach (var employeeDto in employeeDtos)
            {
                if (!IsValid(employeeDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (!IsUsernameValid(employeeDto.Username))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                Employee employee = new Employee
                {
                    Username = employeeDto.Username,
                    Email = employeeDto.Email,
                    Phone = employeeDto.Phone
                };

                foreach (var taskId in employeeDto.Tasks.Distinct())  //Distinct()  to take unique
                {
                    //if there is no of this task return NULL
                    Task task = context
                        .Tasks
                        .FirstOrDefault(t => t.Id == taskId);

                    if (task == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    // add new mapping
                    employee.EmployeesTasks.Add(new EmployeeTask() 
                    {
                         Employee= employee,
                         Task = task
                    });
                }

                employees.Add(employee);
                sb.AppendLine(String.Format(SuccessfullyImportedEmployee, employee.Username, employee.EmployeesTasks.Count));

            }

            context.Employees.AddRange(employees); // Automatically will add new EmployeeTasks
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        //Validation of Username
        private static bool IsUsernameValid(string username)
        {
            foreach (char ch in username)
            {
                if (!Char.IsLetterOrDigit(ch))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}