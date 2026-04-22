namespace Application.Topics.Commands.CreateTopic;

public class CreateTopicHandler(
    IApplicationDbContext dbContext, 
    ILogger<CreateTopicHandler> logger, 
    IMapper mapper) 
    : ICommandHandler<CreateTopicCommand, CreateTopicResult>
{
    public async Task<CreateTopicResult> Handle(CreateTopicCommand request, CancellationToken ct)
    {
        try
        {
            Topic newTopic = mapper.Map<Topic>(request.Dto);
            dbContext.Topics.Add(newTopic);

            await dbContext.SaveChangesAsync(ct);
            return new CreateTopicResult(newTopic.ToTopicResponseDto());
        }
        catch (Exception ex)
        {
            logger.LogInformation($"Произошла ошибка при вызове CreateTopicHandler: {ex.Message}");
            throw;
        }
    }
}
