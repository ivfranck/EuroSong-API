using Euro_Song.Controllers.Models;
using Euro_Song.Data;
using Microsoft.AspNetCore.Mvc;

namespace Euro_Song.Controllers;

[ApiController]
[Route("[controller]")]
public class ArtistController : ControllerBase
{
    private IDataContext _dataContext;

    public ArtistController(IDataContext data)
    {
        _dataContext = data;
    }
    
    [HttpPost]
    public ActionResult Post(Artist artist)
    {
        _dataContext.AddArtist(artist);
        return Ok("Hooray!");
    }

    [HttpGet]
    public ActionResult<List<Artist>> Get()
    {
        return Ok(_dataContext.GetArtist());
    }

}