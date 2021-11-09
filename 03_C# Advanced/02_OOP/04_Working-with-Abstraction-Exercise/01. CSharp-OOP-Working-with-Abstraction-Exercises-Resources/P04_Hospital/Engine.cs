namespace P04_Hospital
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;

    public class Engine
    {
        private Hospital hospital;

        public Engine()
        {
            this.hospital = new Hospital();
        }
        public void Run()
        {

            string command = Console.ReadLine();
            while (command != "Output")
            {
                string[] inputInfo = command.Split();

                var departament = inputInfo[0];

                var firstName = inputInfo[1];
                var lastName = inputInfo[2];

                var patient = inputInfo[3];

                var fullName = firstName + " " + lastName;

                this.hospital.AddDoctor(firstName, lastName);
                this.hospital.AddDepartment(departament);
                this.hospital.AddPatient(departament, fullName, patient);

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                string[] arguments = command.Split();

                if (arguments.Length == 1)
                {
                    var departmentName = arguments[0];
                    var department = this.hospital.Departments.FirstOrDefault(de => de.Name == departmentName);
                    Console.WriteLine(department);
                }
                else  
                {
                    bool isRoom = int.TryParse(arguments[1], out int resultRoom);
                    if (isRoom)
                    {
                        var departmentName = arguments[0];
                        var department = this.hospital.Departments.FirstOrDefault(de => de.Name == departmentName);
                        var currentRoom = department.Rooms[resultRoom - 1];

                        Console.WriteLine(currentRoom);
                    }
                    else
                    {
                        string firstName = arguments[0];
                        string lastName = arguments[1];
                        string fullName = firstName + " " + lastName;
                        var doctor = this.hospital.Doctors.FirstOrDefault(d => d.FullName == fullName);

                        Console.WriteLine(doctor);
                    }                  
                }

                command = Console.ReadLine();
            }             
        }
    }
}
