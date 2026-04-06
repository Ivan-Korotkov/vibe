namespace Application.Topics;

public interface ITopicsService
{
    Task<List<TopicResponseDto>> GetTopicsAsync(CancellationToken ct);
    Task<TopicResponseDto> GetTopicAsync(Guid id, CancellationToken ct);
    Task<TopicResponseDto> CreateTopicAsync(CreateTopicDto topicRequestDto, CancellationToken ct);
    Task<TopicResponseDto> UpdateTopicAsync(Guid id, UpdateTopicDto topicRequestDto, CancellationToken ct);
    Task DeleteTopicAsync(Guid id, CancellationToken ct);
}
