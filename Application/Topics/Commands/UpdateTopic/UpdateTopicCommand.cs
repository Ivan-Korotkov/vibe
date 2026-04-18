namespace Application.Topics.Commands.UpdateTopic;

public record UpdateTopicCommand(Guid Id, UpdateTopicDto UpdateTopicDto, CancellationToken Ct) : ICommand<UpdateTopicResult>;

public record UpdateTopicResult(TopicResponseDto Result);