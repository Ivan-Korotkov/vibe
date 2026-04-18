namespace Application.Topics.Commands.DeleteTopic;

public class DeleteTopicHandler(IApplicationDbContext dbContext, ILogger<DeleteTopicHandler> logger)
    : ICommandHandler<DeleteTopicCommand, DeleteTopicResult>
{
    public async Task<DeleteTopicResult> Handle(DeleteTopicCommand request, CancellationToken ct)
    {
        try
        {
            var topicId = TopicId.Of(request.Id);
            var topic = await dbContext.Topics
                .Where(t => t.Id == topicId && !t.IsDeleted)
                .FirstOrDefaultAsync(ct);

            if (topic == null)
            {
                throw new TopicNotFoundException(request.Id);
            }

            topic.IsDeleted = true;
            topic.DeletedAt = DateTimeOffset.UtcNow;

            await dbContext.SaveChangesAsync(ct);

            return new DeleteTopicResult(true);
        }
        catch (Exception ex) 
        {
            logger.LogInformation($"Произошла ошибка при вызове DeleteTopicHandler: {ex.Message}");
            throw;
        }
    }
}
