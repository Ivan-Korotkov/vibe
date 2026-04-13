using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TopicsController(ITopicsService topicsService)
    : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<TopicResponseDto>>> GetTopics(CancellationToken ct)
    {
        return Ok(await topicsService.GetTopicsAsync(ct));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TopicResponseDto>> GetTopic(Guid id, CancellationToken ct)
    {
        return Ok(await topicsService.GetTopicAsync(id, ct));
    }

    [HttpPost]
    public async Task<ActionResult<TopicResponseDto>> CreateTopic(CreateTopicDto dto, CancellationToken ct)
    {
        return Ok(await topicsService.CreateTopicAsync(dto, ct));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<TopicResponseDto>> UpdateTopic(Guid id, [FromBody] UpdateTopicDto dto, CancellationToken ct)
    {
        return Ok(await topicsService.UpdateTopicAsync(id, dto, ct));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<TopicResponseDto>> DeleteTopic(Guid id, CancellationToken ct)
    {
        await topicsService.DeleteTopicAsync(id, ct);

        return NoContent();

    }
}
