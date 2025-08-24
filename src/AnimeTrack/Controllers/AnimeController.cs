using System.Threading.Tasks;
using AnimeTrack.Models;
using AnimeTrack.Services;
using Microsoft.AspNetCore.Mvc;

namespace AnimeTrack.Controllers;

[ApiController]
[Route("[controller]")]
public class AnimeController : ControllerBase
{
    private readonly IAnimeService _animeService;

    public AnimeController(IAnimeService service)
    {
        _animeService = service;
    }

    [HttpGet]
    [Route("GetAnimes")]
    public IActionResult GetAnimes()
    {
        return Ok(_animeService.getAnimes());
    }

    [HttpGet]
    [Route("GetById")]
    public IActionResult GetAnimeId(Guid id)
    {
        return Ok(_animeService.getAnimeId(id));
    }

    [HttpDelete]
    [Route("Delete")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var objResult = await _animeService.deleteAnime(id);
        if (!objResult.processed) throw new Exception(objResult.msg);
        return Ok();
    }

    [HttpPut]
    [Route("update")]
    public async Task<IActionResult> Update(Guid id, [FromBody] Anime obj)
    {
        var objResult = await _animeService.updateAnime(id, obj);
        if (!objResult.processed) throw new Exception(objResult.msg);
        return Ok();
    }

    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> Create([FromBody] Anime obj)
    {
        var objResult = await _animeService.createAnime(obj);
        if (!objResult.processed) throw new Exception(objResult.msg);
        return Ok();
    }
}
