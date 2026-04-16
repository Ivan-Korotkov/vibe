namespace Application.Topics.Queries.GetTopic;

public class GetTopicHandler(IApplicationDbContext dbContext, ILogger<GetTopicHandler> logger)
    : IQueryHandler<GetTopicQuery, GetTopicResult>
{
    public async Task<GetTopicResult> Handle(GetTopicQuery request, CancellationToken ct)
    {
        try
        {
            var topicID = TopicId.Of(request.id);
            var topic = await dbContext.Topics
                .AsNoTracking()
                .Where(t => !t.IsDeleted && t.Id == topicID)
                .FirstOrDefaultAsync(ct);

            if (topic is null)
            {
                throw new TopicNotFoundException(request.id);
            }

            return new GetTopicResult(topic.ToTopicResponseDto());
        }
        catch (Exception ex) 
        {
            logger.LogInformation($"Произошла ошибка при вызове GetTopicHandler: {ex.Message}");
            throw;
        }

    }
}
