#nullable disable
using System.ComponentModel.DataAnnotations;

namespace Saaya.Wrapper.Model
{
    public class Song
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Thumbnail { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public TimeSpan Length { get; set; }

        [Required]
        public string Url { get; set; }

        public long DateCreated { get; set; } = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
    }
}