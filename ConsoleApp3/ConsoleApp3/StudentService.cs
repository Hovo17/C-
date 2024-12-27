using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class StudentService
{

    private string _fileName;

    public StudentService(string fileName)
    {
        _fileName = fileName;
    }

    public async Task WriteToFileAsync(List<Student> students)
    {
        var jsonData = JsonConvert.SerializeObject(students, Formatting.Indented);
        await File.WriteAllTextAsync(_fileName, jsonData);
    }


    public async Task<List<Student>> ReadFromFileAsync()
    {
        if (!File.Exists(_fileName))
            return new List<Student>();

        var jsonData = await File.ReadAllTextAsync(_fileName);
        return JsonConvert.DeserializeObject<List<Student>>(jsonData);
    }


    public async Task AddStudentAsync(Student student)
    {
        var students = await ReadFromFileAsync();
        students.Add(student);
        await WriteToFileAsync(students);
    }
}
