using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARC.Classes
{
    public class ArcContainer
    {
        public static readonly string[] FUI =
        {
            "skin",
            "skinGraphics",
            "skinGraphicsInGame",
            "skinGraphicsHud",
            "skinPS3",
            "Intro720",
            "Intro480",
        };
        public static readonly string[] Data =
        {
            "languages.loc",
            "splashes.txt",
            "HTMLColours.col"
        };
        public static readonly string[] Dirs =
        {
            "Graphics",
            "Structures"
        };
        public ArcContainer(string filename)
        {

        }
    }
}
