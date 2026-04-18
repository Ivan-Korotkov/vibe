namespace Application.Topics.Commands.UpdateTopic;

public class UpdateTopicHandler(IApplicationDbContext dbContext,  ILogger<UpdateTopicHandler> logger) 
    : ICommandHandler<UpdateTopicCommand, UpdateTopicResult>
{
    public async Task<UpdateTopicResult> Handle(UpdateTopicCommand request, CancellationToken ct)
    {
        try
        {
            var topicID = TopicId.Of(request.Id);
            var topic = await dbContext.Topics.FindAsync([topicID], ct);
            if (topic is null || topic.IsDeleted)
            {
                throw new TopicNotFoundException(request.Id);
            }

            var dto = request.UpdateTopicDto;
            topic.Update(dto.Title, dto.TopicType, dto.Summary,
                dto.EventStart, dto.Location.City, dto.Location.Street);

            await dbContext.SaveChangesAsync(ct);

            return new UpdateTopicResult(topic.ToTopicResponseDto());
        }
        catch (Exception ex) 
        {
            logger.LogInformation($"Произошла ошибка при вызове UpdateTopicHandler: {ex.Message}");
            throw;
        }
    }
}
