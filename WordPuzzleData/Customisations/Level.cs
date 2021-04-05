using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using WordPuzzleBusiness;
//using WordPuzzleData;

namespace WordPuzzleData
{
    public partial class Level
    {
        public override string ToString()
        {
            return $"{LevelId}. {SizeX}x{SizeY} {Name}";
        }
    }
}
