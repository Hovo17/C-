List<Student> students = new List<Student>();
List<University> universities = new List<University>();

string fileName = "data2.json";


Tools.LoadData(fileName, out students, out universities);


while (true)
{
    Console.WriteLine("Choose an option:");
    Console.WriteLine("1. Add Student");
    Console.WriteLine("2. Search Student by Name");
    Console.WriteLine("3. Add University");
    Console.WriteLine("4. Save Data");
    Console.WriteLine("5. Exit");
    var choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            Tools.AddStudent(students, universities); 
            break;
        case "2":
            Tools.SearchStudentByName(students); 
            break;
        case "3":
            Tools.AddUniversity(universities); 
            break;
        case "4":
            Tools.SaveData(fileName, students, universities); 
            Console.WriteLine("Data saved to file.");
            break;
        case "5":
            return; 
        default:
            Console.WriteLine("Invalid option. Try again.");
            break;
    }
}