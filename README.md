# Saaya.Wrapper

API wrapper for Saaya app's API.

---

Fetching songs for user ("token" input). (Outputs a List<Song>)
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
}
```