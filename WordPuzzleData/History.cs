﻿using System;

#nullable disable

namespace WordPuzzleData
{
    public partial class History
    {
        public int HistoryId { get; set; }
        public int UserId { get; set; }
        public int LevelId { get; set; }
        public TimeSpan Time { get; set; }
        public int Score { get; set; }
        public DateTime DateTime { get; set; }

        public virtual Level Level { get; set; }
        public virtual User User { get; set; }
    }
}
