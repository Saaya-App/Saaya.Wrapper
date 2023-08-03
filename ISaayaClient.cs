﻿using Saaya.Wrapper.Model;

namespace Saaya.Wrapper
{
    public interface ISaayaClient
    {
        /// <summary>
        /// Returns all songs for user.
        /// </summary>
        /// <param name="token">User token.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation. The result of the task contains an <see cref="IEnumerable{T}"/> of <see cref="Song"/> objects.</returns>
        Task<IEnumerable<Song>> GetSongsAsync(string token);

        /// <summary>
        /// Returns songs by playlist ID.
        /// </summary>
        /// <param name="token">User token.</param>
        /// <param name="playlistId">Playlist ID, integer.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation. The result of the task contains an <see cref="IEnumerable{T}"/> of <see cref="Song"/> objects.</returns>
        Task<IEnumerable<Song>> GetSongsForPlaylist(string token, string playlistId);

        /// <summary>
        /// Returns all playlist for user.
        /// </summary>
        /// <param name="token">User token.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation. The result of the task contains an <see cref="IEnumerable{T}"/> of <see cref="Playlist"/> objects.</returns>
        Task<IEnumerable<Playlist>> GetPlaylistsAsync(string token);
    }
}