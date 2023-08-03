# Saaya.Wrapper

API wrapper for Saaya app's API.

---

Examples:

```cs
using Saaya.Wrapper;

// Class code

private ISaayaClient saaya;

public MyClass()
{
	saaya = new SaayaClient();
}

public async Task GetSongs()
{
	var songs = await saaya.GetSongsAsync("token");
	// Consume the songs
}

public async Task GetPlaylistSongs()
{
	// Playlist ID: 3
	var songs = await saaya.GetSongsAsync("token", 3);
	// Consume the songs
}
```