using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OLA7_LinqToList
{

    class Program
    { 

        static void Main(string[] args) { 

            try  
            {

                    List<Student> students = File.ReadAllLines(@"./csvDBData.txt")
                                               .Skip(1)                         // skip the header line
                                               .Select(s => Student.FromCsv(s))
                                               .ToList();

                // loop through list and print them out.
                /**
                foreach (Student student in students)
                {
                    Console.WriteLine(student.ToString());
                }
                **/

                // sort the students by GPA
                students.Sort((x, y) => x.gpa.CompareTo(y.gpa));

                // print out the top 10 students in the list
                // for (int i = 0; i < students.Count; i++)
                for (int i = 0; i < 9; i++)
                {
                    Console.WriteLine(students[i].ToString());
                }


            }
            catch(FileNotFoundException e)
            {
                Console.WriteLine("csvDBData.txt not found");
                Console.WriteLine(e.ToString());
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

    }

}


