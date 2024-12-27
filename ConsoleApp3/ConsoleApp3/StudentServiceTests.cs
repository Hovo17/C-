
using Xunit;

public class StudentServiceTests
{
    private readonly string _fileName = "students.json";
    private readonly StudentService _studentService;

    public StudentServiceTests()
    {
        _studentService = new StudentService(_fileName);
    }

    [Fact]
    public async Task AddStudentAsync_ShouldAddStudentToFile()
    {
        // Arrange
        var student = new Student("Alice", 22, "B");

        // Act
        await _studentService.AddStudentAsync(student);
        var students = await _studentService.ReadFromFileAsync();

        // Assert
        Assert.Contains(students, s => s.Name == "Alice" && s.Age == 22 && s.Grade == "B");
    }

    [Fact]
    public async Task ReadFromFileAsync_ShouldReturnStudentsFromFile()
    {
        // Arrange
        var student1 = new Student("Alice", 22, "B");
        var student2 = new Student("Bob", 23, "A");
        await _studentService.WriteToFileAsync(new List<Student> { student1, student2 });

        // Act
        var students = await _studentService.ReadFromFileAsync();

        // Assert
        Assert.Equal(2, students.Count);
        Assert.Contains(students, s => s.Name == "Alice");
        Assert.Contains(students, s => s.Name == "Bob");
    }

    [Fact]
    public async Task WriteToFileAsync_ShouldOverwriteFile()
    {
        // Arrange
        var student1 = new Student("Alice", 22, "B");
        var student2 = new Student("Bob", 23, "A");
        await _studentService.WriteToFileAsync(new List<Student> { student1 });

        // Act
        await _studentService.WriteToFileAsync(new List<Student> { student2 });
        var students = await _studentService.ReadFromFileAsync();

        // Assert
        Assert.Single(students);
        Assert.Contains(students, s => s.Name == "Bob");
    }
}
