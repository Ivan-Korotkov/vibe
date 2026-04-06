using Application.Data.DataBaseContext;
using Domain.ValueObjects;
using Microsoft.Extensions.Logging;

namespace Application.Topics;

public class TopicsService(IApplicationDbContext dbContext, 
    ILogger<TopicsService> logger) : ITopicsService
{
    public Task<Topic> CreateTopicAsync(Topic topicRequestDto, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task DeleteTopicAsync(Guid id, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<Topic> GetTopicAsync(Guid id, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Topic>> GetTopicsAsync(CancellationToken ct)
    {
        try
        {
            var topics = await dbContext.Topics
                .AsNoTracking()
                .ToListAsync(ct);
            return topics;
        }
        catch (Exception ex) 
        {
            logger.LogInformation($"Произошла ошибка при вызове GetTopicsAsync: {ex.Message}");
            return new List<Topic>();
        }
    }

    public Task<Topic> UpdateTopicAsync(Guid id, Topic topicRequestDto, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
