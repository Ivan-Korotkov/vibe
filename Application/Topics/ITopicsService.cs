namespace Application.Topics;

public interface ITopicsService
{
    Task<List<TopicResponseDto>> GetTopicsAsync(CancellationToken ct);
    Task<TopicResponseDto> GetTopicAsync(Guid id, CancellationToken ct);
    Task<TopicResponseDto> CreateTopicAsync(CreateTopicDto dto, CancellationToken ct);
    Task<TopicResponseDto> UpdateTopicAsync(Guid id, UpdateTopicDto dto, CancellationToken ct);
    Task DeleteTopicAsync(Guid id, CancellationToken ct);
}
