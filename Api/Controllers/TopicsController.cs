namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TopicsController(IMediator mediator)
    : ControllerBase
{
    [HttpGet]
    public async Task<IResult> GetTopics(CancellationToken ct)
    {
        return Results.Ok(await mediator.Send(new GetTopicsQuery(ct)));
    }

    [HttpGet("{id}")]
    public async Task<IResult> GetTopic(Guid id, CancellationToken ct)
    {
        return Results.Ok(await mediator.Send(new GetTopicQuery(id, ct)));
    }

    [HttpPost]
    public async Task<IResult> CreateTopic(CreateTopicDto dto, CancellationToken ct)
    {
        var response = await mediator.Send(new CreateTopicCommand(dto, ct));
        return Results.Created($"/topics/{response.Result.Id}", response.Result);
    }

    [HttpPut("{id}")]
    public async Task<IResult> UpdateTopic(Guid id, [FromBody] UpdateTopicDto dto, CancellationToken ct)
    {
        var response = await mediator.Send(new UpdateTopicCommand(id, dto, ct));
        return Results.Ok(response.Result);
    }

    [HttpDelete("{id}")]
    public async Task<IResult> DeleteTopic(Guid id, CancellationToken ct)
    {
        return Results.Ok(await mediator.Send(new DeleteTopicCommand(id, ct)));
    }
}
