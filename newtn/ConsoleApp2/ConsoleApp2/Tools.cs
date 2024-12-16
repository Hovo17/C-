using Newtonsoft.Json;


public class Tools
{
   
    public static void AddUniversity(List<University> universities)
    {
        Console.WriteLine("Enter university name:");
        string universityName = Console.ReadLine()!;

        
        University existingUniversity = universities.Find(u => u.Name.Equals(universityName, StringComparison.OrdinalIgnoreCase));

        if (existingUniversity != null)
        {
            Console.WriteLine("University already exists.");
            return;
        }

        
        University newUniversity = new University(universityName);
        universities.Add(newUniversity);
        Console.WriteLine($"University '{universityName}' added successfully.");
    }


    public static void AddStudent(List<Student> students, List<University> universities)
    {
        Console.WriteLine("Enter student's name:");
        string studentName = Console.ReadLine()!;

        Console.WriteLine("Enter university name:");
        string universityName = Console.ReadLine()!;

        
        University university = universities.Find(u => u.Name.Equals(universityName, StringComparison.OrdinalIgnoreCase));

        if (university == null)
        {
            Console.WriteLine("University not found. Please add the university .");
            return;
        }

        
        Student student = new Student(studentName, university);
        students.Add(student);
    }

    
    public static void SearchStudentByName(List<Student> students)
    {
        Console.WriteLine("Enter student's name to search:");
        string studentName = Console.ReadLine();

        var student = students.Find(s => s.Name?.ToLower() == studentName.ToLower());

        if (student != null)
        {
            Console.WriteLine($"Student: {student.Name}");
            Console.WriteLine($"University: {student.University.Name}");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }

    
    public static void SaveData(string FileName, List<Student> students, List<University> universities)
    {
        var allData = new
        {
            Students = students,
            Universities = universities
        };

        string json = JsonConvert.SerializeObject(allData, Formatting.Indented);
        File.WriteAllText(FileName, json);
    }

    
    public static void LoadData(string FileName, out List<Student> students, out List<University> universities)
    {
        students = new List<Student>();
        universities = new List<University>();

        
        if (File.Exists(FileName))
        {
            string json = File.ReadAllText(FileName);

            
            var data = JsonConvert.DeserializeObject<dynamic>(json);

            if (data != null)
            {
                
                students = data.Students != null ? JsonConvert.DeserializeObject<List<Student>>(data.Students.ToString()) : new List<Student>();
                universities = data.Universities != null ? JsonConvert.DeserializeObject<List<University>>(data.Universities.ToString()) : new List<University>();
            }
        }
    }
}
