
class Program
{
    static async Task Main(string[] args)
    {
        var studentService = new StudentService("students.json");

        
        var student1 = new Student("Alice", 22, "B");
        var student2 = new Student("Bob", 23, "A");
        var student3 = new Student("Charlie", 21, "C");
        var student4 = new Student("David", 24, "B+");
        var student5 = new Student("Eva", 22, "A-");

        
        await studentService.AddStudentAsync(student1);
        await studentService.AddStudentAsync(student2);
        await studentService.AddStudentAsync(student3);
        await studentService.AddStudentAsync(student4);
        await studentService.AddStudentAsync(student5);

        
        var students = await studentService.ReadFromFileAsync();

        
        foreach (var student in students)
        {
            Console.WriteLine($"Name: {student.Name}, Age: {student.Age}, Grade: {student.Grade}");
        }
    }
}
