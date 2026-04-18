namespace Application.Topics.Queries.GetTopics;

public record GetTopicsQuery(CancellationToken Ct) : IQuery<GetTopicsResult>;
public record GetTopicsResult(List<TopicResponseDto> Topics);
