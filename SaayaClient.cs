using Saaya.Wrapper.Model;
using Saaya.Wrapper.Services;
using RestSharp;

namespace Saaya.Wrapper
{
    public class SaayaClient : ISaayaClient
    {
        private RestClient? _rest;
        private readonly JsonHandler _json = new();
        private readonly CancellationTokenSource CancellationTokenSource;

        public SaayaClient()
        {
            CancellationTokenSource = new CancellationTokenSource();
        }

        /// <summary>
        /// Return all songs.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Response"></exception>
        public IEnumerable<Song> GetSongs()
        {
            throw new Response() { ResponseCode = 600, ResponseContent = "Endpoint not found" };
        }

        /// <summary>
        /// Returns songs by device ID.
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Song>> GetSongsForDevice(string deviceId)
        {
            List<Song> songList = new List<Song>();

            var uri = $"https://aisys.dev/saaya/songs/list?device={deviceId}";

            _rest = new RestClient(uri);
            var response = await _rest.ExecuteAsync(new RestRequest(), CancellationTokenSource.Token);

            var parsed = _json.ParsedJson(response.Content);

            for (int i = 0; i < parsed.Count; i++)
            {
                songList.Add(new Song
                {
                    SongId = Int32.Parse(parsed[i]["id"]?.ToString()),
                    Thumbnail = parsed[i]["thumbnail"]?.ToString(),
                    SongTitle = parsed[i]["title"]?.ToString(),
                    SongAuthor = parsed[i]["author"]?.ToString(),
                    SongLength = TimeSpan.Parse(parsed[i]["length"].ToString()),
                    Link = parsed[i]["link"]?.ToString(),
                    PlaylistId = parsed[i]["playlistId"]?.ToString(),
                    DeviceId = parsed[i]["deviceId"]?.ToString()
                });
            }

            return songList;
        }

        /// <summary>
        /// Returns songs by playlist ID.
        /// </summary>
        /// <param name="playlistId"></param>
        /// <returns></returns>
        /// <exception cref="Response"></exception>
        public async Task<IEnumerable<Song>> GetSongsForPlaylist(string playlistId)
        {
            List<Song> songsForPlaylist = new List<Song>();

            var uri = $"https://aisys.dev/saaya/songs/playlist?id={playlistId}";

            _rest = new RestClient(uri);
            var response = await _rest.ExecuteAsync(new RestRequest(), CancellationTokenSource.Token);

            var parsed = _json.ParsedJson(response.Content);

            for (int i = 0; i < parsed.Count; i++)
            {
                songsForPlaylist.Add(new Song
                {
                    SongId = Int32.Parse(parsed[i]["songId"]?.ToString()),
                    Thumbnail = parsed[i]["thumbnail"]?.ToString(),
                    SongTitle = parsed[i]["title"]?.ToString(),
                    SongAuthor = parsed[i]["author"]?.ToString(),
                    SongLength = TimeSpan.Parse(parsed[i]["length"].ToString()),
                    Link = parsed[i]["link"]?.ToString(),
                    PlaylistId = parsed[i]["playlistId"]?.ToString(),
                    DeviceId = parsed[i]["deviceId"]?.ToString()
                });
            }

            return songsForPlaylist;
        }

        /// <summary>
        /// Returns all playlists
        /// </summary>
        /// <param name="playlistId"></param>
        /// <returns></returns>
        /// <exception cref="Response"></exception>
        public IEnumerable<Playlist> GetPlaylists()
        {
            throw new Response() { ResponseCode = 600, ResponseContent = "Endpoint not found" };
        }

        /// <summary>
        /// Returns all playlists by device ID.
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Playlist>> GetPlaylistForDevice(string deviceId)
        {
            List<Playlist> playlistList = new List<Playlist>();

            var uri = $"https://aisys.dev/saaya/playlists/device?id={deviceId}";

            _rest = new RestClient(uri);
            var response = await _rest.ExecuteAsync(new RestRequest(), CancellationTokenSource.Token);

            var parsed = _json.ParsedJson(response.Content);

            for (int i = 0; i < parsed.Count; i++)
            {
                playlistList.Add(new Playlist
                {
                    PlaylistId_ = parsed[i]["playlistId_"]?.ToString(),
                    PlaylistName = parsed[i]["playlistName"]?.ToString(),
                    DeviceId = parsed[i]["deviceId"]?.ToString()
                });
            }

            return playlistList;
        }

        /// <summary>
        /// Adds a new playlist with a YouTube playlist link an device ID.
        /// </summary>
        /// <param name="playlistLink"></param>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        public async Task AddPlaylist(string playlistLink, string deviceId)
        {
            var uri = $"https://aisys.dev/saaya/playlists/";
            var postUri = $"/add?link={playlistLink}&device={deviceId}";

            _rest = new RestClient(uri);
            var request = new RestRequest(postUri);

            var response = await _rest.ExecutePostAsync(request);

            if (!(response.IsSuccessStatusCode))
                return;
        }
    }
}