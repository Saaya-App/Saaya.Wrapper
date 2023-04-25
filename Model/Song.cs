using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saaya.Wrapper.Model
{
    public class Song
    {
        public int? SongId { get; set; }

        public string? Thumbnail { get; set; }

        public string? SongTitle { get; set; }

        public string? SongAuthor { get; set; }

        public TimeSpan? SongLength { get; set; }

        public string? Link { get; set; }

        public string? PlaylistId { get; set; }

        public string? DeviceId { get; set; }
    }
}