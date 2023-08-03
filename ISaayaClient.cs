using Saaya.Wrapper.Model;

namespace Saaya.Wrapper
{
    public interface ISaayaClient
    {
        /// <summary>
        /// Returns all songs for user.
        /// </summary>
        /// <param name="token">User token.</param>
        /// <returns></returns>
        Task<IEnumerable<Song>> GetSongsAsync(string token);

        /// <summary>
        /// Returns songs by playlist ID.
        /// </summary>
        /// <param name="token">User token.</param>
        /// <param name="playlistId">Playlist ID, integer.</param>
        /// <returns></returns>
        /// <exception cref="Response"></exception>
        Task<IEnumerable<Song>> GetSongsForPlaylist(string token, string playlistId);

        /// <summary>
        /// Returns all playlist for user.
        /// </summary>
        /// <param name="token">User token.</param>
        /// <returns></returns>
        Task<IEnumerable<Playlist>> GetPlaylistsAsync(string token);
    }
}