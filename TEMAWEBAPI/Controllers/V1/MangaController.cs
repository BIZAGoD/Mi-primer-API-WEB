using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]

public class MangaController : Controller
{
    private readonly MangaService _mangaService;

    public MangaController(MangaService mangaService)
    {
        this._mangaService = mangaService;
    }

    [HttpGet]

    public IActionResult GetAll()
    {
        return Ok(_mangaService.GetAll());
    }

    [HttpGet("{id:int}")]

    public IActionResult GetById([FromRoute] int id)
    {
        var manga = _mangaService.GetById(id);
        if (manga == null)
        return NotFound();
        return Ok(manga);
    }

    [HttpPost]

    public IActionResult Add([FromBody]Manga manga)
    {
        _mangaService.Add(manga);
        return CreatedAtAction(nameof(GetById), new {id = manga.id}, manga);
    }

    [HttpPut("{id}")]

    public IActionResult Update(int id, Manga manga)
    {
        if (id != manga.id)
        return BadRequest();

        _mangaService.update(manga);
        return NoContent();
    }

    [HttpDelete("{id}")]

    public IActionResult Delete(int id)
    {
        _mangaService.Delete(id);
        return NoContent();
    }

    

}