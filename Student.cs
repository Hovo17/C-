public class Student
{
    public string? Name { get; set; }
    public int Id { get; set; }
    public int Age { get; set; }

    public string ToFileFormat()
    {
        return $"Student {Id} {Name} {Age}";
    }

    public static Student FromFileFormat(string data)
    {
        var parts = data.Split(' ');
        return new Student
        {
            
            Id = int.Parse(parts[1]),
            Name = parts[2],
            Age = int.Parse(parts[3]),

        };
    }

}

