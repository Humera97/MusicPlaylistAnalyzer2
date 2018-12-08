using System;
namespace MusicPlaylist
{
    public class Playlist
    {
        public string Name;
        public string Artist;
        public string Album;
        public string Genre;
        public int Size;
        public int Time;
        public int Year;
        public int Plays;

        public Playlist(string name, string artist, string album, string genre, int size, int time, int year, int plays)
        {
            Name = name; 
            Artist = artist;
            Album= album;
            Genre = genre;
            Size = size;
            Time = time;
            Year = year;
            Plays = plays;
        }
    }
}



