using System;

namespace _04._Hospital
{
    class Program
    {
        static void Main()
        {
            int period = int.Parse(Console.ReadLine());
            int doctors = 7;
            int examinedPatient = 0;
            int noExaminedPatient = 0;

            for (int i = 1; i <= period; i++)
            {

                int patients = int.Parse(Console.ReadLine());

                if (i % 3 == 0)
                {
                    if (examinedPatient < noExaminedPatient)
                    {
                        doctors++;
                    }
                }

                if (patients >7)
                {
                    examinedPatient += doctors;
                    noExaminedPatient += patients - doctors;
                }
                else
                {
                    examinedPatient += patients;
                   
                }

            }
            Console.WriteLine($"Treated patients: {examinedPatient}.");
            Console.WriteLine($"Untreated patients: {noExaminedPatient}.");
        }
    }
}
