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
            return $"{LevelId}. {Size/100}x{Size%100} {Name}";
            //using (var db = new WordPuzzleContext())
            {
                //return $"{db.Levels.LevelId}";
            }
        }
    }
}
