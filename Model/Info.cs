using System.ComponentModel.DataAnnotations;

namespace Saaya.Wrapper.Model
{
    public class Info
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public string? Platform { get; set; }
    }
}