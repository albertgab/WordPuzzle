using System;
using System.Collections.Generic;

#nullable disable

namespace WordPuzzleData
{
    public partial class Solution
    {
        public int SolutionId { get; set; }
        public int LevelId { get; set; }
        public string Word { get; set; }

        public virtual Level Level { get; set; }
    }
}
