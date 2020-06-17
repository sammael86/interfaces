namespace ConsoleApp1
{
    public interface ISerializer
    {
        string Serialize<T>(T item);
        T Deserialize<T>(string data);
    }
}
