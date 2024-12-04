public class University
{
    public string UniversityName { get; set; }
    public string UniversityLocation { get; set; }
    public int UniversityId { get; set; }

    public string ToFileFormat()
    {
        return $"University {UniversityId} {UniversityName} {UniversityLocation}";
    }

    public static University FromFileFormat(string data)
    {
        var parts = data.Split(' ');
        return new University
        {
            
            UniversityId = int.Parse(parts[1]),
            UniversityName = parts[2],
            UniversityLocation = parts[3],
        };
    }
}

