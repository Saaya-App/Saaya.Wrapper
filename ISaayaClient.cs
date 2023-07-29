using Saaya.Wrapper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saaya.Wrapper
{
    public interface ISaayaClient
    {
        IEnumerable<Song> GetSongs();
        Task<IEnumerable<Song>> GetSongsForDevice(string deviceId);
        Task<IEnumerable<Song>> GetSongsForPlaylist(string playlistId);

        IEnumerable<Playlist> GetPlaylists();
        Task<IEnumerable<Playlist>> GetPlaylistForDevice(string deviceId);
        Task AddPlaylist(string playlistLink, string deviceId);
    }
}