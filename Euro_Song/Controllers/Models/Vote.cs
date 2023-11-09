namespace Euro_Song.Controllers.Models;

public class Vote
{
    public int ID { get; private set; }
    public int Song { get; set; }
    public int Points { get; set; }
    public string IP { get; set; }
}