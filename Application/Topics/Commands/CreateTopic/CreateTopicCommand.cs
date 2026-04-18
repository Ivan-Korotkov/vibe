namespace Application.Topics.Commands.CreateTopic;

public record CreateTopicCommand(CreateTopicDto Dto, CancellationToken Ct) 
    : ICommand<CreateTopicResult>;
public record CreateTopicResult(TopicResponseDto Result);