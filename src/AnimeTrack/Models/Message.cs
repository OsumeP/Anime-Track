namespace AnimeTrack.Models;

public class Message
{
    public bool processed;
    public string msg;
    public string? info;

    public Message(bool processed, string msg)
    {
        this.processed = processed;
        this.msg = msg;
    }

    public Message(bool processed, string msg, string info)
    {
        this.processed = processed;
        this.msg = msg;
        this.info = info;
    }
}
