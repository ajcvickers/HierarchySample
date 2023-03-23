public class Interest
{
    private Interest()
    {
    }

    public Interest(string path)
    {
        Id = new LTree(path);
    }

    public LTree Id { get; private set; }
    public string? Comments { get; set; }
}