public class Adress
{
    public string? Street { get; set; }
    public string? City { get; set; }
    public string? Postcode { get; set; }

    public Adress(string street,string city,string postcode)
    {
        Street = street;
        City = city;
        Postcode = postcode;
    }
}

