﻿#nullable disable
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

        public SaayaClient()
        {
            _rest = new RestClient();
            CancellationTokenSource = new CancellationTokenSource();
        }

        public async Task<IEnumerable<Song>> GetSongsAsync(string token)
        {
            RestRequest Request = new RestRequest($"https://api.saaya.dev/songs", Method.Get);
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
            RestRequest Request = new RestRequest($"https://api.saaya.dev/playlists", Method.Get);
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
            RestRequest Request = new RestRequest($"https://api.saaya.dev/playlists", Method.Get);
            Request.AddHeader("Authorization", $"Bearer {token}");

            RestResponse Response = await _rest.ExecuteAsync(Request);

            if (Response.IsSuccessStatusCode)
            {
                List<Playlist> playlists = JsonConvert.DeserializeObject<List<Playlist>>(Response.Content);
                return playlists;
            }

            return new List<Playlist>();
        }

        public async Task<(User user, bool IsSuccess)> GetProfileAsync(string token)
        {
            RestRequest Request = new RestRequest($"https://api.saaya.dev/users/me", Method.Get);
            Request.AddHeader("Authorization", $"Bearer {token}");

            RestResponse Response = await _rest.ExecuteAsync(Request);

            if (Response.IsSuccessStatusCode)
            {
                User user = JsonConvert.DeserializeObject<User>(Response.Content);
                return (user, true);
            }

            return (new User(), false);
        }

        public async Task<IEnumerable<Info>> GetNewsAsync(string platform)
        {
            RestRequest Request = new RestRequest($"https://api.saaya.dev/news", Method.Get);

            RestResponse Response = await _rest.ExecuteAsync(Request);

            if (Response.IsSuccessStatusCode)
            {
                List<Info> news = JsonConvert.DeserializeObject<List<Info>>(Response.Content);
                return news;
            }

            return new List<Info>();
        }
    }
}