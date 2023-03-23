public class Halfling
{
    public Halfling(LTree pathFromPatriarch, string name, int? yearOfBirth = null)
    {
        PathFromPatriarch = pathFromPatriarch;
        Name = name;
        YearOfBirth = yearOfBirth;
    }

    public int Id { get; private set; }
    public LTree PathFromPatriarch { get; set; }
    public string Name { get; set; }
    public int? YearOfBirth { get; set; }
}