using Euro_Song.Controllers.Models;
using Euro_Song.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Euro_Song.Controllers;

[ApiController]
[Route("[controller]")]
public class SongController : ControllerBase
{
    private IDataContext _dataContext;

    public SongController(IDataContext data)
    {
        _dataContext = data;
    }
    
    [HttpPost]
    [Authorize(Policy = "BasicAuthentication")]
    public ActionResult Post(Song song)
    {
        _dataContext.AddSong(song);
        return Ok("Hooray!");
    }

    [HttpGet]
    public ActionResult<List<Song>> Get()
    {
        return Ok(_dataContext.GetSongs());
    }
    
    // Get song by artist name
    [HttpGet("ArtistSong")]
    public ActionResult<IEnumerable<Song>> GetArtistSong(string name)
    {
        return Ok(_dataContext.GetArtistSong(name));
    }

    [HttpGet("{id}")]
    public ActionResult<Song> Get(int id)
    {
        Song song = _dataContext.GetSong(id);
        if (song == null) return NotFound("Wrong ID");
        return Ok(song);
    }
    
    // You should normally require admin privileges to delete from databases (security)
    [HttpDelete]
    [Authorize(Policy = "BasicAuthentication", Roles = "admin")]
    public ActionResult DeleteSong(int id)
    {
        if (_dataContext.GetSong(id) == null)
        {
            return NotFound();
        }
        else
        {
            _dataContext.DeleteSong(id);
            return Ok();
        }
    }
}

