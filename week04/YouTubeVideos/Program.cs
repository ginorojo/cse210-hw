using System;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    {
        // Create a list to store videos
        List<Video> videos = new List<Video>();

        // Create 3-4 Video objects with appropriate values
        Video video1 = new Video("Learning C#", "Alice", 600);
        Video video2 = new Video("Data Science Tutorial", "Bob", 1200);
        Video video3 = new Video("Introduction to AI", "Charlie", 900);

        // Add the videos to the list
        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        // Add comments to each video
        video1.AddComment(new Comment("John", "Great explanation!"));
        video1.AddComment(new Comment("Emma", "Very helpful, thanks!"));
        video1.AddComment(new Comment("Sophia", "Loved the examples."));

        video2.AddComment(new Comment("Michael", "This was super detailed."));
        video2.AddComment(new Comment("Sarah", "Thanks for the insights."));

        video3.AddComment(new Comment("Chris", "AI is fascinating!"));
        video3.AddComment(new Comment("Taylor", "Looking forward to more content."));
        video3.AddComment(new Comment("Jordan", "Awesome video!"));

        // Display video details and their comments
        foreach (Video video in videos)
        {
            Console.WriteLine(video);
            Console.WriteLine("Comments:");
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  - {comment}");
            }
            Console.WriteLine("\n----------------------------------------\n");
        }
    }
}
