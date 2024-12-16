internal class Worker
{
    public string? Name {  get; set; }
    public string? Position { get; set; }
    public Adress Adress { get; set; }

    public Worker(string name, string position, Adress adress)
    {
        Name = name;
        Position = position;
        Adress = adress;
    }
}

