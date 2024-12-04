using System.Net.NetworkInformation;

public class Employee
    {
    public string EmployeeName { get; set; }
    public int EmployeeId { get; set; }
    public string EmployeeStatus { get; set; }

    public string ToFileFormat()
    {
        return $"Employee {EmployeeId} {EmployeeName} {EmployeeStatus}";
    }

    public static Employee FromFileFormat(string data)
    {
        var parts = data.Split(' ');
        return new Employee
        {
           
            EmployeeId = int.Parse(parts[1]),
            EmployeeName = parts[2],
            EmployeeStatus = parts[3]
        };
    }
}

