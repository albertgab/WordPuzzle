using WordPuzzleData.Services;

namespace WordPuzzleData
{
    public partial class History
    {
        private readonly IGameService _service;
        public History(IGameService service)
        {
            _service = service;
        }
        public History()
        {
            _service = new GameService();
        }
        public override string ToString()
        {
            User = _service.GetUserById(UserId);
            return $"{Score}   {User.Username}   {Time}   {DateTime}";
        }
        public string ToStringUser()
        {
            Level = _service.GetLevelById(LevelId);
            return $"{Level.Name}   {Score}   {Time}   {DateTime}";
        }
    }
}
