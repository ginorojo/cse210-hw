using System;
using System.Collections.Generic;
class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Duration { get; set; } // Duration in seconds
    private List<Comment> Comments { get; set; }

    public Video(string title, string author, int duration)
    {
        Title = title;
        Author = author;
        Duration = duration;
        Comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    public int CommentCount()
    {
        return Comments.Count;
    }

    public override string ToString()
    {
        return $"Title: {Title}\nAuthor: {Author}\nDuration: {Duration} seconds\nComments: {CommentCount()}";
    }

    public List<Comment> GetComments()
    {
        return Comments;
    }
}