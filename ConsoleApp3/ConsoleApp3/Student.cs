using System;
using Newtonsoft.Json;

public class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Grade { get; set; }

    public Student(string name, int age, string grade)
    {
        Name = name;
        Age = age;
        Grade = grade;
    }

    public static Student FromJson(string json)
    {
        return JsonConvert.DeserializeObject<Student>(json);
    }

    public string ToJson()
    {
        return JsonConvert.SerializeObject(this);
    }
}
