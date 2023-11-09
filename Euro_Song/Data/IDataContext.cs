using Euro_Song.Controllers.Models;

namespace Euro_Song.Data;

public interface IDataContext
{
    // Songs
    void AddSong(Song song);
    IEnumerable<Song> GetSongs();
    Song GetSong(int id);
    // Delete Song
    void DeleteSong(int id);
    
    // Artists
    void AddArtist(Artist artist);
    IEnumerable<Artist> GetArtist();
    
    // Vote
    void AddVote(Vote vote);
    IEnumerable<Vote> GetVote();
    
    // Get All Songs form Artist
    IEnumerable<Song> GetArtistSong(string name);

}