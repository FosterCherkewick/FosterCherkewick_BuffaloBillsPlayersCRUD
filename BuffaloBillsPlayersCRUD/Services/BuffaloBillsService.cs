using BuffaloBillsPlayersCRUD.Models;
namespace BuffaloBillsPlayersCRUD.Services
{
    public class BuffaloBillsService : IBuffaloBillsPlayerService
    {
        private readonly List<BuffaloBillsPlayer> _billsPlayerList;
        public BuffaloBillsService()
        {
            _billsPlayerList = new List<BuffaloBillsPlayer>()
            {
                new BuffaloBillsPlayer()
                {
                    PlayerNumber = 17,
                    FirstName = "Josh",
                    LastName = "Allen",
                    isActive = true
                }
            };
        }
        //getting all the players who are active
        public List<BuffaloBillsPlayer> GetAllPlayers(bool? isActive)
        {
            return isActive == null? _billsPlayerList : _billsPlayerList.Where(player => player.isActive == isActive).ToList();
        }
        //getting the player by their number
        public BuffaloBillsPlayer? GetPlayerByNumber(int playerNumber)
        {

            return _billsPlayerList.FirstOrDefault(player => player.PlayerNumber == playerNumber);
        }

        //adding a player
        public BuffaloBillsPlayer AddPlayer(AddUpdateDeleteOurPlayer obj)
        {
            var addPlayer = new BuffaloBillsPlayer()
            {
                PlayerNumber = _billsPlayerList.Max(player => player.PlayerNumber),
                FirstName = obj.FirstName,
                LastName = obj.LastName,
                isActive = obj.isActive
            };
            _billsPlayerList.Add(addPlayer);
            return addPlayer;

        }

        public BuffaloBillsPlayer? UpdatePlayer(int playerNumber, AddUpdateDeleteOurPlayer obj)
        {
            var ourPlayerIndex = _billsPlayerList.FindIndex(index  => index.PlayerNumber == playerNumber);

            if (ourPlayerIndex > 0)
            {
                var player = _billsPlayerList[ourPlayerIndex];

                player.FirstName = obj.FirstName;
                player.LastName = obj.LastName;
                player.isActive = obj.isActive;

                _billsPlayerList[ourPlayerIndex] = player;
                return player;
            }
            else
            {
                return null;
            }
        }

        public bool DeletePlayerByNumber(int playerNumber)
        {
            var ourPlayerIndex = _billsPlayerList.FindIndex(Index => Index.PlayerNumber == playerNumber);
            if (ourPlayerIndex >= 0)
            {
                _billsPlayerList.RemoveAt(ourPlayerIndex);

            }
            return ourPlayerIndex >= 0;
        }
    }
}
