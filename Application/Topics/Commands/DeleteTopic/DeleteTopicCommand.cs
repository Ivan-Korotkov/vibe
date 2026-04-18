namespace Application.Topics.Commands.DeleteTopic;

public record DeleteTopicCommand(Guid Id, CancellationToken Ct) : ICommand<DeleteTopicResult>;

public record DeleteTopicResult(bool IsSuccess);