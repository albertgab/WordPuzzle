using System;
using System.Collections.Generic;

#nullable disable

namespace WordPuzzle
{
    public partial class Solution
    {
        public int LevelId { get; set; }
        public string Word { get; set; }

        public virtual Level Level { get; set; }
    }
}
