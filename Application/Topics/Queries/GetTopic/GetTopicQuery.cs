namespace Application.Topics.Queries.GetTopic;

public record GetTopicQuery(Guid id, CancellationToken ct) : IQuery<GetTopicResult>;

public record GetTopicResult(TopicResponseDto TopicResponseDto); 