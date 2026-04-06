using Domain.ValueObjects;

namespace Application.Topics;

public interface ITopicsService
{
    Task<List<Topic>> GetTopicsAsync(CancellationToken ct);
    Task<Topic> GetTopicAsync(Guid id, CancellationToken ct);
    Task<Topic> CreateTopicAsync(Topic topicRequestDto, CancellationToken ct);
    Task<Topic> UpdateTopicAsync(Guid id, Topic topicRequestDto, CancellationToken ct);
    Task DeleteTopicAsync(Guid id, CancellationToken ct);
}
