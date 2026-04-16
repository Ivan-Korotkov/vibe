namespace Application.Topics.Queries.GetTopics;

public record GetTopicsQuery(CancellationToken ct) : IQuery<GetTopicsResult>;
public record GetTopicsResult(List<TopicResponseDto> Topics);
