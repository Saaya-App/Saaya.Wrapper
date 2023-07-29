#nullable disable
using System.ComponentModel.DataAnnotations;

namespace Saaya.Wrapper.Model
{
    public class Song
    {
        [Key]
        public int Id { get; set; }

        public string? Thumbnail { get; set; }

        public string? Title { get; set; }

        public string? Author { get; set; }

        public TimeSpan? Length { get; set; }

        public string? Link { get; set; }

        public string? PlaylistId { get; set; }

        public string? DeviceId { get; set; }
    }
}