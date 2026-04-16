using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TopicsController()
    : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<TopicResponseDto>>> GetTopics(CancellationToken ct)
    {
        return Ok(null);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TopicResponseDto>> GetTopic(Guid id, CancellationToken ct)
    {
        return Ok(null);
    }

    [HttpPost]
    public async Task<ActionResult<TopicResponseDto>> CreateTopic(CreateTopicDto dto, CancellationToken ct)
    {
        return Ok(null);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<TopicResponseDto>> UpdateTopic(Guid id, [FromBody] UpdateTopicDto dto, CancellationToken ct)
    {
        return Ok(null);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<TopicResponseDto>> DeleteTopic(Guid id, CancellationToken ct)
    {
        return NoContent();

    }
}
