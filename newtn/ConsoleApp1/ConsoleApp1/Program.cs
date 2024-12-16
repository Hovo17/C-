using Newtonsoft.Json;


     List<Student> students = new List<Student>();
     List<Worker> workers = new List<Worker>();
     List<University> universities = new List<University>();

    
        string fileName = "data.json";

       
        LoadData(fileName);

        
        while (true)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Add Worker");
            Console.WriteLine("3. Add University");
            Console.WriteLine("4. Save Data");
            Console.WriteLine("5. Exit");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddStudent();
                    break;
                case "2":
                    AddWorker();
                    break;
                case "3":
                    AddUniversity();
                    break;
                case "4":
                    SaveData(fileName);
                    Console.WriteLine("Data saved to file.");
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    

     void AddStudent()
    {
        Console.WriteLine("Enter student's name:");
        string studentName = Console.ReadLine();

        Console.WriteLine("Enter university name:");
        string universityName = Console.ReadLine();

        Console.WriteLine("Enter university department:");
        string department = Console.ReadLine();
        University university = new University(universityName, department);

        Adress address = GetAddress();

        Student student = new Student(studentName, university, address);
        students.Add(student);
    }

     void AddWorker()
    {
        Console.WriteLine("Enter worker's name:");
        string workerName = Console.ReadLine();

        Console.WriteLine("Enter worker's position:");
        string position = Console.ReadLine();

        Adress address = GetAddress();

        Worker worker = new Worker(workerName, position, address);
        workers.Add(worker);
    }

     void AddUniversity()
    {
        Console.WriteLine("Enter university name:");
        string universityName = Console.ReadLine();

        Console.WriteLine("Enter university department:");
        string department = Console.ReadLine();

        University university = new University(universityName, department);
        universities.Add(university);
    }

     Adress GetAddress()
    {
        Console.WriteLine("Enter street:");
        string street = Console.ReadLine();

        Console.WriteLine("Enter city:");
        string city = Console.ReadLine();

        Console.WriteLine("Enter postcode:");
        string postcode = Console.ReadLine();

        return new Adress(street, city, postcode);
    }

     void SaveData(string fileName)
    {
        var allData = new
        {
            Students = students,
            Workers = workers,
            Universities = universities
        };

        string json = JsonConvert.SerializeObject(allData);
        File.WriteAllText(fileName, json);
    }

     void LoadData(string fileName)
    {
        if (File.Exists(fileName))
        {
            string json = File.ReadAllText(fileName);
            var data = JsonConvert.DeserializeObject<dynamic>(json);

            students = JsonConvert.DeserializeObject<List<Student>>(data.Students.ToString());
            workers = JsonConvert.DeserializeObject<List<Worker>>(data.Workers.ToString());
            universities = JsonConvert.DeserializeObject<List<University>>(data.Universities.ToString());
        }
    }

