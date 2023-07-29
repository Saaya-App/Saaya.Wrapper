#nullable disable
using System.ComponentModel.DataAnnotations;

namespace Saaya.Wrapper.Model
{
    public class Playlist
    {
        [Key]
        public string PlaylistId { get; set; }

        public string? PlaylistName { get; set; }

        public string? DeviceId { get; set; }
    }
}
