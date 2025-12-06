using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers;

[ApiController]
[Route("api/entities")]
public class SomeEntityApiController : ControllerBase
{
    private readonly SomeEntityController _controller;

    public SomeEntityApiController(SomeEntityController controller)
    {
        _controller = controller;
    }

    [HttpPost]
    public ActionResult<SomeEntity> Create([FromBody] SomeEntity entity)
    {
        var created = _controller.Create(entity);
        return CreatedAtAction(nameof(GetOne), new { id = created.Id }, created);
    }

    [HttpGet]
    public ActionResult<List<SomeEntity>> GetMany()
    {
        return _controller.GetMany();
    }

    [HttpGet("{id:int}")]
    public ActionResult<SomeEntity> GetOne(int id)
    {
        var entity = _controller.GetOne(id);
        if (entity == null) return NotFound();
        return entity;
    }

    [HttpPut("{id:int}")]
    public IActionResult Update(int id, [FromBody] SomeEntity entity)
    {
        entity.Id = id;
        _controller.Update(entity);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        _controller.Delete(id);
        return NoContent();
    }
}