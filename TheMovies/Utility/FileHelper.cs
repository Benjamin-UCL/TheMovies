using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TheMovies.Utility
{
    public static class FileHelper
    {
        public static void EnsureFileExists(string filePath)
        {
            if (!File.Exists(filePath)) 
            {
                using (File.Create(filePath)) ;
                // brug using i stedet for File.Create, fordi using automatisk bruge Dispose() korrekt
                //File.Create(filePath).Dispose();
                // can også bruge File.Create(filePath).Close(); men anbefales at bruge Dispose(): "har ikke bruge mere for dette, så ryd op"

            }
        }
    }
}
