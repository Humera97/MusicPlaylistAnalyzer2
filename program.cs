using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicPlaylist
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("MusicPlaylistAnalyzer <music_playlist_file_path> <report_file_path>");
                Environment.Exit(1);
            }
            string musicPlaylistFilePath = args[0];
            string reportFilePath = args[1];

            List<Playlist> playlist2 = null;
            try
            {
                playlist2 = PlaylistLoader.Load(musicPlaylistFilePath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(2);
            }
            var questions = Questions.GenerateText(playlist2);
            try
            {
                System.IO.File.WriteAllText(reportFilePath, questions);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(3);
            }
        }
    }
}

