using System;
using System.Collections.Generic;
using System.IO;

namespace MusicPlaylist
{
    public static class PlaylistLoader
    {
        private static int NumItemsInRow = 8;
        public static List<Playlist> Load(string musicPlaylistFilePath)
        {
            List<Playlist> playlist2 = new List<Playlist>();
            try{
                using (var reader = new StreamReader(musicPlaylistFilePath))
                {
                    int lineNumber = 0;
                    while(!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        lineNumber++;
                        if (lineNumber == 1) continue;
                        var values = line.Split('\t');
                        if (values.Length != NumItemsInRow)
                        {
                            throw new Exception($"Row {lineNumber} contains {values.Length} values. It should contain {NumItemsInRow}.");
                        }
                        try
                        {
                            string name = values[0];
                            string artist = values[1];
                            string album = values[2];
                            string genre = values[3];
                            int size = Int32.Parse(values[4]);
                            int time = Int32.Parse(values[5]);
                            int year = Int32.Parse(values[6]);
                            int plays = Int32.Parse(values[7]);
                            Playlist playlist = new Playlist(name, artist, album, genre, size, time, year, plays);
                            playlist2.Add(playlist);
                        }
                        catch (FormatException e)
                        {
                            throw new Exception($"Row {lineNumber} contains invalid data. ({e.Message})");
                        }



                    }
                }
            }
            catch (Exception e)

            { 
                throw new Exception($"Unable to open {musicPlaylistFilePath} ({e.Message}).");
            }

            return playlist2;

        }


    }
}



