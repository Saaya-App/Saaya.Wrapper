#nullable disable
using Saaya.Wrapper.Model;
using Saaya.Wrapper.Services;
using RestSharp;
using Newtonsoft.Json;

namespace Saaya.Wrapper
{
    public class SaayaClient : ISaayaClient
    {
        private RestClient _rest;
        private readonly JsonHandler _json;
        private readonly CancellationTokenSource CancellationTokenSource;

        private const string BaseUrl = "https://aisys.dev/api/saaya";
        private const string Songs = "https://aisys.dev/api/saaya/song";
        private const string Playlists = "https://aisys.dev/api/saaya/playlist";

        public SaayaClient()
        {
            _rest = new RestClient();
            _json = new JsonHandler();
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
        /// Returns all songs by device ID.
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Song>> GetSongsForDevice(string deviceId)
        {
            RestRequest Request = new RestRequest($"{Songs}/device", Method.Get);
            Request.AddParameter("id", deviceId);

            RestResponse Response = await _rest.ExecuteAsync(Request);

            if (Response.IsSuccessStatusCode)
            {
                List<Song> songs = JsonConvert.DeserializeObject<List<Song>>(Response.Content);
                return songs;
            }

            return new List<Song>();
        }

        /// <summary>
        /// Returns songs by playlist ID.
        /// </summary>
        /// <param name="playlistId"></param>
        /// <returns></returns>
        /// <exception cref="Response"></exception>
        public async Task<IEnumerable<Song>> GetSongsForPlaylist(string playlistId)
        {
            return new List<Song>();
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
            throw new Response() { ResponseCode = 600, ResponseContent = "Endpoint not found" };
        }

        /// <summary>
        /// Adds a new playlist with a YouTube playlist link an device ID.
        /// </summary>
        /// <param name="playlistLink"></param>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        public async Task AddPlaylist(string playlistLink, string deviceId)
        {
            //var uri = $"https://aisys.dev/saaya/playlists/";
            //var postUri = $"/add?link={playlistLink}&device={deviceId}";

            //_rest = new RestClient(uri);
            //var request = new RestRequest(postUri);

            //var response = await _rest.ExecutePostAsync(request);

            //if (!(response.IsSuccessStatusCode))
            //    return;
            throw new Response() { ResponseCode = 600, ResponseContent = "Endpoint not found" };
        }
    }
}