namespace Module_7;

public struct Worker
{
    public int Id { get; set; }
    public DateTime DateAdded { get; set; }
    public string FIO { get; set; }
    public int Age { get; set; }
    public int Height { get; set; }
    public DateTime BirthDate { get; set; }
    public string BirthPlace { get; set; }

    public Worker(int id, DateTime dateAdded, string fio, int age, int height, DateTime birthDate, string birthPlace)
    {
        Id = id;
        DateAdded = dateAdded;
        FIO = fio;
        Age = age;
        Height = height;
        BirthDate = birthDate;
        BirthPlace = birthPlace;
    }

    public override string ToString()
    {
        return $"{Id}#{DateAdded:dd.MM.yyyy HH:mm}#{FIO}#{Age}#{Height}#{BirthDate:dd.MM.yyyy}#{BirthPlace}";
    }
}