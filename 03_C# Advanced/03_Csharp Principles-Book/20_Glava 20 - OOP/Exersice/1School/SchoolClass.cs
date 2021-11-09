using System;
using System.Collections.Generic;
using System.Text;

namespace _1School
{
    public class SchoolClass
    {
        private string identification;
        private List<Student> studentList;
        private List<Teacher> teacherList;

        public SchoolClass()
        {
        }
        public SchoolClass(string itentification)
        {
            this.Itentification = itentification;

            this.studentList = new List<Student>();
           this.teacherList = new List<Teacher>();
        }

        public string Itentification
        {
            get { return identification; }
            set { identification = value; }
        }

    }
}
