#nullable disable
using System.ComponentModel.DataAnnotations;

namespace Saaya.Wrapper.Model
{
    public class Playlist
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public long DateCreated { get; set; } = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
    }
}
