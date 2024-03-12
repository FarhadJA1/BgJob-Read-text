namespace B.Service.Models;
public class Settings
{
    public int CheckInterval { get; set; }
    public string FilePath { get; set; }


    public Settings(int interval, string path)
    {
        CheckInterval = interval;
        FilePath = path;
    }

    //For Deserialization
    public Settings()
    {
        
    }
}
