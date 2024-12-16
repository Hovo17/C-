public class Student
{
    public string? Name { get; set; }
    public University University { get; set; }
    

    public Student(string name, University university)
    {
        Name = name;
        University = university;
        
    }
}