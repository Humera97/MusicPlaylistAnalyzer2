
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MusicPlaylist
{
    public static class Questions
    {

        public static string GenerateText(List<Playlist> playlist2)
        {
            string questions = "Music Playlist Questions\n\n";

            if (playlist2.Count() < 1)
            {

                questions += "No data is available.\n";

                return questions;
            }

            questions += "Number of songs that recieved 200 plays or more: ";
            int i = 0;
            var numberofsongs = from playlist in playlist2 where playlist.Plays >= 200 select playlist;
            foreach (Playlist playlist in numberofsongs)
            {
                i++;
            }
            questions += " {i}. \n";

           int a = 0;
            var numberofalternative = from playlist in playlist2 where playlist.Genre == "Alternative" select playlist.Name;
            foreach ( string name in numberofalternative ) 
            {
                a++;
            }
            questions += "Number of Alternative songs: {a}. \n";

            int b = 0;
            var numberofhiphop = from playlist in playlist2 where playlist.Genre == "Hip-Hop/Rap" select playlist.Name;
            foreach ( string name in numberofhiphop)
            {
                b++;
            }
            questions += "Number of Hip-Hop and Rap: {b}. \n";

            questions += "Songs in Album- Welcome to the Fishbowl: ";
            var fishbowl = from playlist in playlist2 where playlist.Album == "Welcome to the Fishbowl" select playlist.Name;
            foreach (string name in fishbowl)
            {
                questions += name + ", ";
            }

            questions += "\n";

            questions += "Songs in playlist before 1970: ";
            var before1970 = from playlist in playlist2 where playlist.Year < 1970 select playlist.Name;
            foreach (string name in before1970)
            {
                questions += name + ",";
            }
            questions += "\n";

            questions += "Songs that are longer than 85 characters:";
            var characters85 = from playlist in playlist2 where playlist.Name.Length > 85 select playlist.Name;
            foreach (string name in characters85)
            {
                questions += name + ", ";

            }
            questions += "\n";

            questions += "Song with the longest time: ";
            var longestsong = from playlist in playlist2 orderby playlist.Time descending select playlist.Name;
            questions += longestsong.First();

            return questions;

        }
    }
}

