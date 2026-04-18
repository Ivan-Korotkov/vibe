namespace Application.Topics.Queries.GetTopic;

public record GetTopicQuery(Guid Id, CancellationToken Ct) : IQuery<GetTopicResult>;

public record GetTopicResult(TopicResponseDto TopicResponseDto); 