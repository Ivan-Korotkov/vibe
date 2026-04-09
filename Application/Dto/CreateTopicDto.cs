namespace Application.Dto;

public record CreateTopicDto(
    string Title,
    string Summary,
    string TopicType,
    LocationDto Location,
    DateTime EventStart
);
