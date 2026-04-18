namespace Application.Topics.Commands.CreateTopic;

public class CreateTopicHandler(IApplicationDbContext dbContext, ILogger<CreateTopicHandler> logger) 
    : ICommandHandler<CreateTopicCommand, CreateTopicResult>
{
    public async Task<CreateTopicResult> Handle(CreateTopicCommand request, CancellationToken ct)
    {
        try
        {
            var dto = request.Dto;
            Topic newTopic = Topic.Create(
                TopicId.Of(Guid.NewGuid()),
                dto.Title,
                dto.EventStart,
                dto.Summary,
                dto.TopicType,
                Location.Of(dto.Location.City, dto.Location.Street)
            );

            dbContext.Topics.Add(newTopic);
            await dbContext.SaveChangesAsync(ct);
            return new CreateTopicResult(newTopic.ToTopicResponseDto());
        }
        catch (Exception ex)
        {
            logger.LogInformation($"Произошла ошибка при вызове CreateTopicHandler: {ex.Message}");
            throw;
        }
    }
}
