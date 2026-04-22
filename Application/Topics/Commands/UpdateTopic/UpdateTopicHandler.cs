namespace Application.Topics.Commands.UpdateTopic;

public class UpdateTopicHandler(
    IApplicationDbContext dbContext, 
    ILogger<UpdateTopicHandler> logger, 
    IMapper mapper) 
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

            mapper.Map(request.UpdateTopicDto, topic);

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
