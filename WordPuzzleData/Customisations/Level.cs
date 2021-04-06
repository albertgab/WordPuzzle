
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
