
using BuffaloBillsPlayersCRUD.Models;
namespace BuffaloBillsPlayersCRUD.Services
{
    public interface IBuffaloBillsPlayerService
    {
        List<BuffaloBillsPlayer> GetAllPlayers(bool? isActive);
        BuffaloBillsPlayer? GetPlayerByNumber(int playerNumber);
        BuffaloBillsPlayer AddPlayer(AddUpdateDeleteOurPlayer obj);
        BuffaloBillsPlayer? UpdatePlayer(int playerNumber, AddUpdateDeleteOurPlayer obj);
        bool DeletePlayerByNumber(int  playerNumber);
    }
}
