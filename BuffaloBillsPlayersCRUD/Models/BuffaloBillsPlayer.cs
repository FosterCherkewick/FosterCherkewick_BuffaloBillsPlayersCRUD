//BuffaloBillsPlayer.cs
namespace BuffaloBillsPlayersCRUD.Models
{
    public class BuffaloBillsPlayer
    {
        public int PlayerNumber {  get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public bool isActive { get; set; } = true;
    }
}
