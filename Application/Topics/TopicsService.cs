using Application.Data.DataBaseContext;
using Application.Exceptions;
using Application.Extensions;
using Domain.ValueObjects;
using Microsoft.Extensions.Logging;

namespace Application.Topics;

public class TopicsService(IApplicationDbContext dbContext, 
    ILogger<TopicsService> logger) : ITopicsService
{
    public async Task<TopicResponseDto> CreateTopicAsync(CreateTopicDto dto, CancellationToken ct)
    {
        try
        {
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

            return newTopic.ToTopicResponseDto();
        }
        catch (Exception ex) 
        {
            logger.LogInformation($"Произошла ошибка при вызове CreateTopicAsync: {ex.Message}");
            throw;
        }
    }

    public Task DeleteTopicAsync(Guid id, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public async Task<TopicResponseDto> GetTopicAsync(Guid id, CancellationToken ct)
    {
        try
        {
            var topicID = TopicId.Of(id);
            var topic = await dbContext.Topics
                .FirstOrDefaultAsync(t => t.Id == topicID, ct);

            if (topic is null)
            {
                throw new TopicNotFoundException(id);
            }

            return topic.ToTopicResponseDto();
        }
        catch (Exception ex)
        {
            logger.LogInformation($"Произошла ошибка при вызове GetTopicAsync: {ex.Message}");
            throw;
        }
    }

    public async Task<List<TopicResponseDto>> GetTopicsAsync(CancellationToken ct)
    {
        try
        {
            var topics = await dbContext.Topics
                .AsNoTracking()
                .ToListAsync(ct);
            return topics.ToTopicResponseDtoList();
        }
        catch (Exception ex) 
        {
            logger.LogInformation($"Произошла ошибка при вызове GetTopicsAsync: {ex.Message}");
            return new List<TopicResponseDto>();
        }
    }

    public Task<TopicResponseDto> UpdateTopicAsync(Guid id, UpdateTopicDto dto, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
