using System;
namespace Euro_Song.Controllers.Models
{
    public class Song
    {
        public int ID { get; private set; }// get the set private so you cant modify/set it
        public int Artist { get; set; }
        public string Title { get; set; }
        public string Spotify { get; set; }

    }
}

