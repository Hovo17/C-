var students = new  List<Student>()
{
    new Student {Id = 1, Name = "Hovo",Age = 19  },
    new Student {Id = 2, Name = "Ruben",  Age = 20 }
};

var employees = new List<Employee>()
{
    new Employee {EmployeeId = 1,EmployeeName = "Vigen", EmployeeStatus = "Injiner" },
    new Employee {EmployeeId = 2,EmployeeName = "Martin",  EmployeeStatus = "banvor"}
};

var universities = new List<University>()
{
    new University{UniversityId = 1,UniversityName = "Eph", UniversityLocation = "AleqManukyan" },
    new University{ UniversityId = 2,UniversityName = "NPUA", UniversityLocation = "Teryan"}
};

string filePath = "data.txt";
WriteToFile(filePath, students, employees, universities);
ReadFromFile(filePath);

static void  WriteToFile(string filePath, List<Student>students, List<Employee>employees,List<University> universities)
{
    using (StreamWriter writer = new StreamWriter(filePath))
    {
        foreach (var student in students)
        {
            writer.WriteLine(student.ToFileFormat());
        }
        foreach (var employee in employees)
        {
            writer.WriteLine(employee.ToFileFormat());
        }
        foreach (var univer in universities)
        {
            writer.WriteLine(univer.ToFileFormat());
        }
    }
}

    static void ReadFromFile(string filePath)
    {
        using (StreamReader reader = new StreamReader(filePath))
        {
            string ?line;
            while ((line = reader.ReadLine()) != null)
            {
                if (line.StartsWith("S"))
                {
                    var student = Student.FromFileFormat(line);
                    Console.WriteLine($"Read Student: {student.Name}, Age: {student.Age}");
                }
                else if (line.StartsWith("E"))
                {
                    var employee = Employee.FromFileFormat(line);
                    Console.WriteLine($"Read Employee: {employee.EmployeeName}, Position: {employee.EmployeeStatus}");
                }
                else if (line.StartsWith("U"))
                {
                    var university = University.FromFileFormat(line);
                    Console.WriteLine($"Read University: {university.UniversityName}, Location: {university.UniversityLocation}");
                }
            }
        }
    }

