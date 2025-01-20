using System;

public class Entry
{
    public string Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Mood { get; set; } 

    public override string ToString()
    {
        return $"{Date} | {Prompt} | {Response} | {Mood}";
    }
}

