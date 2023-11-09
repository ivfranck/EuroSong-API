using Euro_Song.Controllers.Models;

namespace Euro_Song.Data;

public class DataList : IDataContext
{
    private List<Song> _songs = new List<Song>();
    private List<Artist> _artists = new List<Artist>();
    private List<Vote> _votes = new List<Vote>();
    
    private List<Song> _Artistsongs = new List<Song>();

    public void AddSong(Song song)
    {
        _songs.Add(song);
    }

    public IEnumerable<Song> GetSongs()
    {
        return _songs;
    }

    public Song GetSong(int id)
    {
        throw new System.NotImplementedException();
    }

    public void DeleteSong(int id)
    {
        throw new NotImplementedException();
    }


    public void AddArtist(Artist artist)
    {
        _artists.Add(artist);
    }

    public IEnumerable<Artist> GetArtist()
    {
        return _artists;
    }

    public void AddVote(Vote vote)
    {
        _votes.Add(vote);
    }

    public IEnumerable<Vote> GetVote()
    {
        return _votes;
    }

    public IEnumerable<Song> GetArtistSong(string name)
    {
        throw new NotImplementedException();
    }

    /*public IEnumerable<Song> GetArtistSong(string name)
    {
        foreach (var song in _songs)
        {
            if (song.Artist == name)
            {
                _Artistsongs.Add(song);
            }
        }

        return _Artistsongs;
        
        
    }*/
}