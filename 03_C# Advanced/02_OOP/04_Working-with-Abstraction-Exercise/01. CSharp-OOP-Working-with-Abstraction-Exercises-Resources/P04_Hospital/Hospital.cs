namespace P04_Hospital
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;

    public class Hospital
    {
        public Hospital()
        {
            this.Doctors = new List<Doctor>();
            this.Departments = new List<Department>();
        }

        public List<Doctor> Doctors { get; set; }
        public List<Department> Departments { get; set; }

        public void AddDoctor(string firstName, string lastName)
        {
            if (!this.Doctors.Any(d => d.FirstName == firstName && d.LastName == lastName))
            {
                var doctor = new Doctor(firstName, lastName);
                this.Doctors.Add(doctor);
            }
        }

        public void AddDepartment(string name)
        {
            if (!this.Departments.Any(de => de.Name == name))
            {
                var deparment = new Department(name);
                this.Departments.Add(deparment);
            }
        }

        public void AddPatient(string departmentName, string doctorName, string patientName)
        {
            var department = this.Departments.FirstOrDefault(de => de.Name == departmentName);
            var doctor = this.Doctors.FirstOrDefault(d => d.FullName == doctorName);

            Patient patient = new Patient(patientName);

            if (department.AddPatientToRoom(patient))
            {
                doctor.Patients.Add(patient);
            }
        }
    }
}
