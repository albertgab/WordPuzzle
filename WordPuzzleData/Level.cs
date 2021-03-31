using System;
using System.Collections.Generic;

#nullable disable

namespace WordPuzzleBusiness
{
    public partial class Level
    {
        public Level()
        {
            Histories = new HashSet<History>();
            Solutions = new HashSet<Solution>();
        }

        public int LevelId { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public string Letters { get; set; }

        public virtual ICollection<History> Histories { get; set; }
        public virtual ICollection<Solution> Solutions { get; set; }
    }
}
