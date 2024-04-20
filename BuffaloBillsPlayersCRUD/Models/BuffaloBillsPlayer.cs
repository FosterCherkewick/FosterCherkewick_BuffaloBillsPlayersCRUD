//BuffaloBillsPlayer.cs
namespace BuffaloBillsPlayersCRUD.Models
{
    public class BuffaloBillsPlayer
    {
        public int Number {  get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; } = string.Empty;
        public bool isActive { get; set; } = true;
    }
}
