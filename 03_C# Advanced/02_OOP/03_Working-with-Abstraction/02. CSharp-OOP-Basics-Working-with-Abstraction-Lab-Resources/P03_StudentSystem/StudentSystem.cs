namespace P03_StudentSystem
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class StudentSystem
    {
        private Dictionary<string, Student> studentRepository;

        public StudentSystem()
        {
            this.studentRepository = new Dictionary<string, Student>();
        }
 
        public void ConsoleInput()
        {
            string[] arguments = Console.ReadLine().Split();

            if (arguments[0] == "Create")
            {
                var name = arguments[1];
                var age = int.Parse(arguments[2]);
                var grade = double.Parse(arguments[3]);

                if (!studentRepository.ContainsKey(name))
                {
                    var student = new Student(name, age, grade);
                    studentRepository[name] = student;
                }
            }
            else if (arguments[0] == "Show")
            {
                PrintOutput(arguments);
            }
            else if (arguments[0] == "Exit")
            {
                Environment.Exit(0);
            }
        }

        private void PrintOutput(string[] arguments)
        {
            var studetName = arguments[1];

            Console.WriteLine(GetStudentInfo(studetName)); 
        }

        private string  GetStudentInfo (string studentName)
        {
            if (studentRepository.ContainsKey(studentName))
            {
                var student = studentRepository[studentName];
                string studentInfo = $"{student.Name} is {student.Age} years old.";

                if (student.Grade >= 5.00)
                {
                    studentInfo += " Excellent student.";                  
                }
                else if (student.Grade < 5.00 && student.Grade >= 3.50)
                {
                    studentInfo += " Average student.";                   
                }
                else
                {
                    studentInfo += " Very nice person.";                  
                }
                return studentInfo;

            }

            return null;
        }
    }
}
