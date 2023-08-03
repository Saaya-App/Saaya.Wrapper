#nullable disable
using Saaya.Wrapper.Model;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Saaya.Wrapper
{
    public class SaayaClient : ISaayaClient
    {
        private RestClient _rest;
        private readonly CancellationTokenSource CancellationTokenSource;

        private const string Songs = "https://api.saaya.dev/songs";
        private const string Playlists = "https://api.saaya.dev/playlists";

        public SaayaClient()
        {
            _rest = new RestClient();
            CancellationTokenSource = new CancellationTokenSource();
        }

        public async Task<IEnumerable<Song>> GetSongsAsync(string token)
        {
            RestRequest Request = new RestRequest($"{Songs}", Method.Get);
            Request.AddHeader("Authorization", $"Bearer {token}");
            RestResponse Response = await _rest.ExecuteAsync(Request);

            if (Response.IsSuccessStatusCode)
            {
                List<Song> songs = JsonConvert.DeserializeObject<List<Song>>(Response.Content);
                return songs;
            }

            return new List<Song>();
        }

        public async Task<IEnumerable<Song>> GetSongsForPlaylist(string token, string playlistId)
        {
            RestRequest Request = new RestRequest($"{Songs}", Method.Get);
            Request.AddHeader("Authorization", $"Bearer {token}");
            Request.AddParameter("playlist", playlistId);

            RestResponse Response = await _rest.ExecuteAsync(Request);

            if (Response.IsSuccessStatusCode)
            {
                List<Song> songs = JsonConvert.DeserializeObject<List<Song>>(Response.Content);
                return songs;
            }

            return new List<Song>();
        }

        public async Task<IEnumerable<Playlist>> GetPlaylistsAsync(string token)
        {
            RestRequest Request = new RestRequest($"{Playlists}", Method.Get);
            Request.AddHeader("Authorization", $"Bearer {token}");

            RestResponse Response = await _rest.ExecuteAsync(Request);

            if (Response.IsSuccessStatusCode)
            {
                List<Playlist> playlists = JsonConvert.DeserializeObject<List<Playlist>>(Response.Content);
                return playlists;
            }

            return new List<Playlist>();
        }
    }
}