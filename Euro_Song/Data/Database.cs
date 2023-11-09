using Euro_Song.Controllers.Models;
using LiteDB;

namespace Euro_Song.Data;

public class Database : IDataContext
{
    public LiteDatabase data = new LiteDatabase("data.db");
    public void AddSong(Song song)
    {
        data.GetCollection<Song>("Songs").Insert(song);
    }

    public IEnumerable<Song> GetSongs()
    {
        return data.GetCollection<Song>("Songs").FindAll();
    }

    public Song GetSong(int id)
    {
        return data.GetCollection<Song>("Songs").FindById(id);
    }

    public void DeleteSong(int id)
    {
        data.GetCollection<Song>("Songs").Delete(id);
    }

    public void AddArtist(Artist artist)
    {
        data.GetCollection<Artist>("Artists").Insert(artist);
    }

    public IEnumerable<Artist> GetArtist()
    {
        return data.GetCollection<Artist>("Artists").FindAll();
    }

    public void AddVote(Vote vote)
    {
        data.GetCollection<Vote>("Votes").Insert(vote);
    }

    public IEnumerable<Vote> GetVote()
    {
        return data.GetCollection<Vote>("Votes").FindAll();
    }

    public IEnumerable<Song> GetArtistSong(string name)
    {
        int id = data.GetCollection<Artist>("Artists").FindOne(x => x.Name.Equals(name)).ID;
        return data.GetCollection<Song>("Songs").FindAll().Where(x => x.Artist.Equals(id));
    }
}