using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Server
{
    public class ZodiacIntervals
    {
        public static string[] lines;
        public static void readTextFile(string fileName)
        {
            lines = File.ReadAllLines(fileName);
        }
    }
}
