    public class Student
    {
        public string? Name { get; set; }
        public University University { get; set; }
        public Adress Adress { get; set; }

        public Student(string name,University university, Adress adress)
        {
        Name = name;
        University = university;
        Adress = adress;
        }
    }

